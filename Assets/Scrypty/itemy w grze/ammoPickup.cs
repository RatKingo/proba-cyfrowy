using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playershoot weapon = collision.gameObject.GetComponentInChildren<playershoot>();
        if (weapon)
        {
            weapon.AddAmmo(weapon.maxAmmoSize);
            Destroy(gameObject);


        }
    }
}
