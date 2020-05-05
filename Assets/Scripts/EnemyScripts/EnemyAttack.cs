using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public LayerMask whatIsEnemy;
    public Transform target;
    public Transform attackPos;
    public float attackRange;
    public int damage;
    private float lastAttackTime;
    public float attackDelay;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (target == null)
        {
            return;
        }
        //If player in range and not running animation, run an animation
        //Check the distance between enemy and player to see if player is close enough to attack
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);
        print(distanceToPlayer);
        if (distanceToPlayer < attackRange)
        {
            AttackAnim();
        }
    }

    // Update is called once per frame
    public void DoAttack()
    {
        //AttackingAI

       // AttackAnim();

       

        
        
        Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
        for (int i = 0; i < playerToDamage.Length; i++)
        {         
           playerToDamage[i].GetComponent<PlayerHealth2>().DamagePlayer(damage);
        }
    }

    public void AttackAnim()
    {
        print("Attack");
        anim.SetTrigger("Attack");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, target.position);
    }
}
