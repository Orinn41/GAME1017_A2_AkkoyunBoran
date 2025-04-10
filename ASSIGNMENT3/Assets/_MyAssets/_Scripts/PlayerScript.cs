using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Transform groundDetect;
    [SerializeField] private bool isGrounded; // Just so we can see in Editor.
    [SerializeField] private float moveForce;
    [SerializeField] private float jumpForce;
    public LayerMask groundLayer;
    private float groundCheckWidth = 0.75f;
    private float groundCheckHeight = 0.1f;
    private Animator an;
    private Rigidbody2D rb;
    // TODO: Add the reference for CapsuleCollider2D.
    private CapsuleCollider2D capsule;
    private AudioSource audioSource;
    private AudioClip jumpClip;
    private AudioClip rollClip;
    private Vector2 NormalColliderSize;
    private Vector2 NormalColliderOffset;
    private float rollColliderHeight = 0.5f;
    public int maxHealth = 3;
    private int currentHealth;
    public Text healthText;

    void Start()
    {
        an = GetComponentInChildren<Animator>();
        isGrounded = false; // Always start in air.
        rb = GetComponent<Rigidbody2D>();
        // TODO: Set the reference for CapsuleCollider2D.
        capsule = GetComponent<CapsuleCollider2D>();
        audioSource = gameObject.AddComponent<AudioSource>();
        jumpClip = Resources.Load<AudioClip>("jump");
        rollClip = Resources.Load<AudioClip>("roll");
        NormalColliderSize = capsule.size;
        NormalColliderOffset = capsule.offset;
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void Update()
    {
        GroundedCheck();

        // Horizontal movement.
        float moveInput = Input.GetAxis("Horizontal");
        float moveInputRaw = Input.GetAxisRaw("Horizontal"); // Clamped to -1, 0, or 1.
        // bool isMoving = Mathf.Abs(moveInputRaw) > 0f;
        an.SetBool("isMoving", Mathf.Abs(moveInputRaw) > 0f);
        // Set horizontal force in player. Use current vertical velocity.
        rb.velocity = new Vector2(moveInput * moveForce * Time.fixedDeltaTime, rb.velocity.y);

        // TODO: Comment out flipping the player.
        // Flip the player. Could use down and up functions for not every frame.
        if (moveInputRaw != 0)
            transform.localScale = new Vector3(moveInputRaw, 1, 1);

        // TODO: Add to the trigger jump condition the new isRolling parameter from the animator.
        // Trigger jump. Use current horizontal velocity. Cannot jump in a roll.
        if (isGrounded && Input.GetButtonDown("Jump") && !an.GetBool("isRolling"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.fixedDeltaTime);
            an.SetTrigger("Jump");
            PlayClip(jumpClip);
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.S))
        {
            capsule.size = new Vector2(capsule.size.x, rollColliderHeight);
            capsule.offset = new Vector2(capsule.offset.x, -0.2f);
            an.SetBool("isRolling", true);
            PlayClip(rollClip);

        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            capsule.size = NormalColliderSize;
            capsule.offset = NormalColliderOffset;
            an.SetBool("isRolling", false);
            

        }
       

    }
    private void PlayClip(AudioClip clip)
    {
        if (clip != null)
            audioSource.PlayOneShot(clip);
    }
    private void GroundedCheck()
    {
        isGrounded = Physics2D.OverlapBox(groundDetect.position, 
            new Vector2(groundCheckWidth, groundCheckHeight), 0f, groundLayer);
        an.SetBool("isJumping", !isGrounded);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            UpdateHealthUI();
        }
    }
    private void Die()
    {
        // Logic for player death, restart, etc.
        Debug.Log("Player is dead!");
        // You can load a game over scene or restart the game.
    }
    private void UpdateHealthUI()
    {
        // Update the health UI Text component
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }
    }
}
