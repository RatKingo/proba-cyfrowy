using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1AI : MonoBehaviour
{
    private bool isWalking;

    public float moveSpeed = 2f;
    public float distanceBetween;

    private bool canAttack = true;
    public int attackDamage = 10;
    public float attackRange = 2f;
    public float attackCooldown = 2f;

    public GameObject player;
    private Animator anim;
    public float speed;

    private float distance;

    private healthAlex playerHealth;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<healthAlex>();
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        // Obliczanie odległości między przeciwnikiem a graczem
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= attackRange && canAttack)
        {
            Attack();
        }
    }

    private void Attack()
    {
        // Zadawanie obrażeń graczowi
        playerHealth.RemoveHealth((int)attackDamage);

        // Ustawienie czasu oczekiwania przed kolejnym atakiem
        canAttack = false;
        Invoke(nameof(ResetAttack), attackCooldown);
    }

    private void ResetAttack()
    {
        canAttack = true;
    }

    void FixedUpdate()
    {
        if (distance > distanceBetween)
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
   
