using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

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
        Game.Instance.SetFinalTime();
        SceneManager.LoadScene("GameOverScene");
    }

    private IEnumerator InvulnerabilityCoroutine()
    {
        isInvulnerable = true; 
        yield return new WaitForSeconds(invulnerabilityTime); 
        isInvulnerable = false; 
    }
}

