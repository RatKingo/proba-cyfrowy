using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puddle : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
   {
    if(collision.gameObject.CompareTag("Player"))
    {
        collision.gameObject.GetComponent<healthAlex>().RemoveHealth(10);
    }
   }
}
