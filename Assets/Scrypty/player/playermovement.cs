using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
   public float moveSpeed = 4f;

   private bool isWalking;
   public static bool isRunning;

   public Rigidbody2D rb;
   private Animator anim;
   public Camera cam;
   
    
    Vector2 movement;
    Vector2 mousePos;

    void Start()
    {
        anim=GetComponent<Animator>();
    }
   
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 moveDir = new Vector3(movement.x, movement.y).normalized;
        transform.position += moveDir * moveSpeed * Time.fixedDeltaTime;

        if(isRunning == true)
        {
            moveSpeed = 4f;
        }

        if(isRunning == false)
        {
            moveSpeed = 3f;
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        
        if(movement.x ==0 && movement.y ==0)
        {
            isWalking = false;
        }
        else
        {
            isWalking = true;
        }

        
          UpdateAnimations();
    
    }
    
    private void UpdateAnimations()
    {
        anim.SetBool("isWalking", isWalking);

    }
}
