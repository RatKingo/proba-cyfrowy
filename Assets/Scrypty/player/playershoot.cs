using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershoot : MonoBehaviour
{
   private float timeBtwAttack;
   public float startTimeBtwAttack;

   public Transform firePoint;
   public GameObject bulletPrefab;
   public Animator anim;
   public PickUp pickupsystem;
   private bool gun;
   public int currentClip, maxClipSize = 6, currentAmmo, maxAmmoSize = 48;

    void Update()
    {
        gun = pickupsystem.gun;
         if(timeBtwAttack <= 0)
        {
            if(Input.GetKey(KeyCode.Mouse1)&& gun)
            {
                Shoot();
            }
                timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

     }
            

    
    void Shoot ()
    {
        if(currentClip > 0)
        {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        anim.SetTrigger("isShooting");
        currentClip--;
        }
    }

    public void Reload()
    {
        int reloadAmount = maxClipSize - currentClip;
        reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount : currentAmmo;
        currentClip += reloadAmount;
        currentAmmo -= reloadAmount;
    }

    public void AddAmmo(int ammoAmount)
    {
        currentAmmo += ammoAmount;
        if(currentAmmo > maxAmmoSize)
        {
            currentAmmo = maxAmmoSize;
        }
    }

    
}
