using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhp : MonoBehaviour
{
    public int damage;
    private int health;
    public healthscript hpscript;

    void Start()
    {
        health = hpscript.health;
    }

     public void TakeDamage(int damage)
   {

    
        health -= damage;
        Debug.Log("damage TAKEN");

        if(health <= 0)
        {
            Destroy(gameObject);
        }

    
}
}
