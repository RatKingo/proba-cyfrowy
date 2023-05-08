using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keydoor : MonoBehaviour
{
   [SerializeField] private key.KeyType keyType;

   public key.KeyType GetKeyType()
   {
    return keyType;
   }

   public void OpenDoor()
   {
    gameObject.SetActive(false);
   }

}
