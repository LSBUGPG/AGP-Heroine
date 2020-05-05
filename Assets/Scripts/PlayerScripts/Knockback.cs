using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{

    [SerializeField]
    private float thrust;
    [SerializeField]
    private float knockTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D NPC = other.collider.GetComponent<Rigidbody2D>();
            if (NPC != null)
            {
                
                Vector2 difference = NPC.transform.position - transform.position;
                difference = difference.normalized * thrust;
                NPC.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(NPC));

            } 
        }
    }

    private IEnumerator KnockCo(Rigidbody2D NPC)
    {
        if (NPC != null)
        {
            yield return new WaitForSeconds(knockTime);
            NPC.velocity = Vector2.zero;
            
        }
    }

}
