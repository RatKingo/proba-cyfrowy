using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersprint : MonoBehaviour
{
    public float totalStamina;
    public float stamina;

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            playermovement.isRunning = true;
        }
        else
        {
            playermovement.isRunning = false;
        }

    }
}

