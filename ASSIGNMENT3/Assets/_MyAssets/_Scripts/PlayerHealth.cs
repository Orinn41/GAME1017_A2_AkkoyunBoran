using UnityEngine;
using UnityEngine.UI; // For UI components
using TMPro; // For TextMeshPro support
using System.Collections;
using System.Collections.Generic;
using System.Linq; // For TextMeshPro support

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public List<GameObject> HealthSprites= new List<GameObject>();
    // or
    public TMP_Text healthText;

    private bool isInvulnerable = false; 
    public float invulnerabilityTime = 10f; 
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    public void TakeDamage(int damageAmount)
    {
        if (isInvulnerable) return;
        var sprite = HealthSprites.LastOrDefault();
        if ( sprite != null)
        {
            HealthSprites.Remove(sprite);
            Destroy(sprite);
        }
        currentHealth -= damageAmount; 
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die(); 
        }

       
        StartCoroutine(InvulnerabilityCoroutine()); 
    }

    private void Die()
    {
        
        Debug.Log("Player has died!");
    }

    private IEnumerator InvulnerabilityCoroutine()
    {
        isInvulnerable = true; 
        yield return new WaitForSeconds(invulnerabilityTime); 
        isInvulnerable = false; 
    }
}

