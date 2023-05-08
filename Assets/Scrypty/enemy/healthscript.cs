using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthscript: MonoBehaviour
{
    public int health = 100;
    public void RemoveHealth (int amount)
    {
        health -=amount;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}