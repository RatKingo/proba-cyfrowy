using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthAlex : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;


    public healthbar hpbar;

    private bool isDead;

    public DeathScreen gameManager;

    void Start()
    {
        currentHealth = maxHealth;
        hpbar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RemoveHealth(20);
        }

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            gameObject.SetActive(false);
            gameManager.gameOver();
        }
    }

    public void RemoveHealth (int amount)
    {
        currentHealth -=amount;

        hpbar.SetHealth(currentHealth);
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

    }

}
