using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyattack : MonoBehaviour
{
   #region Public Variables
   public Transform rayCast;
   public LayerMask raycastMask;
   public float rayCastLength;
   public float attackDistance;
   public float moveSpeed;
   public float timer;
   #endregion

   #region Private Variables
   private RaycastHit2D hit;
   private GameObject target;
   private Animator anim;
   private float distance;
   private bool attackMode;
   private bool inRange;
   private bool cooling;
   private float intTimer;
   #endregion

   void Awake()
   {
    intTimer = timer;
    anim = GetComponent<Animator>();
   }

    void Update()
    {
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, raycastMask);
            RaycastDebugger();
        }
        if(hit.collider != null)
        {
            EnemyLogic();
        }
        else if(hit.collider == null)
        {
            inRange = false;
        }
        if(inRange == false)
        {
            anim.SetBool("isWalking", false);
            StopAttack();
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRange = true;
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if(distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if(attackDistance >= distance && cooling == false)
        {
            Attack();
        }
        
    }

    void Move()
    {
        anim.SetBool("isWalking", true);

        if(!anim.GetCurrentAnimatorStateInfo (0).IsName("attack baby"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, target.transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer;
        attackMode = true;
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", true);
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("isAttacking", false);
    }

    void RaycastDebugger()
    {
        if(distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
        }
        else if(attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }
    }
}
