using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            an.SetBool("isRolling", true);
            PlayClip(rollClip);

        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
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
}
