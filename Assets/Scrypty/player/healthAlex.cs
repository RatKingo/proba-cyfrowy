using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthAlex : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;


    public healthbar hpbar;

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
    }

    public void RemoveHealth (int amount)
    {
        currentHealth -=amount;

        hpbar.SetHealth(currentHealth);
    }

}
