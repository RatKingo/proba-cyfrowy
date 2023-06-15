
using UnityEngine;


public class Apteczka : MonoBehaviour
{
    public int healAmount = 20;  
    public healthbar hpbar;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            Destroy(gameObject);


           
            healthAlex playerHealth = collision.GetComponent<healthAlex>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
                hpbar.SetHealth(playerHealth.currentHealth);
            }
        }
    }
}


