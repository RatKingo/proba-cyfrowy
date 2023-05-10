using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constantrunenemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 4f;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;

    public float distanceBetween;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate() 
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
 
    
}