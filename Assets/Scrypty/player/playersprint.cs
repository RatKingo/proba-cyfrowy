using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersprint : MonoBehaviour
{
    public float totalStamina;
    public float stamina;
    public staminabar stbar;

    

    void Awake()
    {
        stamina = totalStamina;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            playermovement.isRunning = true;
            stamina -= 1f;
        }
        else
        {
            playermovement.isRunning = false;
        }
        if(stamina < 100 |Input.GetKey(KeyCode.LeftShift))
        {
            stamina += 0.5f;
        }
       

        if(stbar =null)
        {
            stbar.transform.localScale = new Vector2(stamina / totalStamina, stbar.transform.localScale.y);
        }

        
    }
}

