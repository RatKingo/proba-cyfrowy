using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1AI : MonoBehaviour
{
    private bool isWalking;

    public GameObject player;
    private Animator anim;
    public float speed;
    public float distanceBetween;
    

    private float distance;

    void Start()
    {
        anim=GetComponent<Animator>();
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        }
       
    }

    void FixedUpdate()
    {
          if(distance > distanceBetween)
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
   
