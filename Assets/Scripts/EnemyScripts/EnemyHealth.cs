using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int health;
    public GameObject blood;
    public Animator Anim;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            
            Instantiate(blood, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

  
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("damage TAKEN !");
    }

    

}
