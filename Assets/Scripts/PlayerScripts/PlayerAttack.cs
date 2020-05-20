using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int[] damage; //0 = Light attack, light weapon -- 1 = Heavy attack, heavy weapon
    bool currentWeapon; //If currentWeapon is false, the player is using the light weapons --- If currentWeapon is true, the player is using the heavy weapons
    public Animator playerAnim;

    [SerializeField]
    private float thrust;
    [SerializeField]
    private float knockTime;
    

    public string[] animName;

   


    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                
                if (!currentWeapon)
                {
                    AttackAnimLight();
                    FindObjectOfType<AudioManager>().Play("SwingLight");
                    //playerAnim.SetInteger("LightAnim", Random.Range(1, 4));
                   // DoAttack(0);
                }
                else
                {
                    AttackAnimHeavy();
                    //playerAnim.SetInteger("HeavyAnim", Random.Range(1, 4));
                   // DoAttack(1);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentWeapon = !currentWeapon;
        }

        timeBtwAttack -= Time.deltaTime;
    }

    public void AttackFinished()
    {
        playerAnim.SetInteger("LightAnim", 0);
        playerAnim.SetInteger("HeavyAnim", 0);
    }

    void DoAttack(int j)
    {
        //playerAnim.Play(animName[j]);
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemyHealth>().TakeDamage(damage[j]);
            if (enemiesToDamage[i].CompareTag("Enemy"))
            {
                Rigidbody2D Enemy = enemiesToDamage[i].GetComponent<Rigidbody2D>();
                if (Enemy != null)
                {
                    
                    Vector2 difference = Enemy.transform.position - transform.position;
                    difference = difference.normalized * thrust;
                    Enemy.AddForce(difference, ForceMode2D.Impulse);
                    StartCoroutine(KnockCo(Enemy));

                } 
            }
        }

        timeBtwAttack = startTimeBtwAttack;
    }

    private void AttackAnimLight()
    {
        playerAnim.SetInteger("LightAnim", Random.Range(1, 4));
    }

    private void AttackAnimHeavy()
    {
        playerAnim.SetInteger("HeavyAnim", Random.Range(1, 4));
    }

    private IEnumerator KnockCo(Rigidbody2D Enemy)
    {
        if (Enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
         //   Enemy.velocity = Vector2.zero;
            
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
