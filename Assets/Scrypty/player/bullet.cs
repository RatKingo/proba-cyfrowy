using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 30;
    

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        enemyhp enemy = hitInfo.GetComponent<enemyhp>();
        if (enemy !=null)
        {
            enemy.TakeDamage(damage);
        }
    
        Destroy(gameObject);

    }


}
