using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttackTest : MonoBehaviour
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
        //Check the distance between enemy and player to see if player is close enough to attack
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        //If player in range and not running animation, run an animation
        //AttackingAI

        AttackAnim();
    }

    // Update is called once per frame
    public void DoAttack()
    {
        Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
        for (int i = 0; i < playerToDamage.Length; i++)
        {         
           playerToDamage[i].GetComponent<PlayerHealth2>().DamagePlayer(damage);
        }
    }

    public void AttackAnim()
    {
            print("Attck");
            anim.SetTrigger("Attack");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
    

