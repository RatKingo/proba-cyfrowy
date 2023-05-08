using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public Animator anim;
    public float attackRange;
    public int damage;
    public PickUp pickupsystem;
    private bool rura;

    
    


    void Update()
    {
        rura = pickupsystem.rura;

        if(timeBtwAttack <= 0)
        {
            if(Input.GetKey(KeyCode.Mouse0)&& rura){
                Attack();
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++){
                    enemiesToDamage[i].GetComponent<enemyhp>().TakeDamage(damage);
                }
            }
        
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public void Attack()
    {
        anim.SetTrigger("isAttackingMelee");
    }
}


