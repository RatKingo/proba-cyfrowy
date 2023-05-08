using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyholder : MonoBehaviour
{
    public event EventHandler OnKeysChanged;

    private List<key.KeyType> keyList;

    private void Awake()
    {
        keyList = new List<key.KeyType>();
    }

    public List<key.KeyType> GetKeyList()
    {
        return keyList;
    }

    public void AddKey(key.KeyType keyType)
    {
        Debug.Log("Added Key" + keyType);
        keyList.Add(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveKey(key.KeyType keyType)
    {
        keyList.Remove(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool ContainsKey(key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        key kei = collider.GetComponent<key>();
        if (kei != null)
        {
            AddKey(kei.GetKeyType());
            Destroy(kei.gameObject);
        }

        keydoor keiDoor = collider.GetComponent<keydoor>();
        if (keiDoor != null)
        {
            if (ContainsKey(keiDoor.GetKeyType()))
            {
                RemoveKey(keiDoor.GetKeyType());
                keiDoor.OpenDoor();
            }
        }
    }
}
