using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	public LevelManager levelManager;
    private int damage = 5;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
		
	}
	

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "Player")
        { 
              FindObjectOfType<PlayerHealth2>().DamagePlayer(damage);    
        }

        //if (other.name == "Player")
        // {
        //    levelManager.RespawnPlayer();
        // }
    }
}
