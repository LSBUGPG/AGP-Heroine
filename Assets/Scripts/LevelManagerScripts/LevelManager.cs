using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour {

    public static LevelManager levelManager;

    public GameObject currentCheckpoint;

   // private PlayerController player;

	bool playerIsDead = false;

    public GameObject player;

    public Animator animator;

	public float respawnDelay = 1f;
    public Animator door1;
    public Animator door2;
    public Animator door3;
    public Animator door4;


    // Use this for initialization
    void Start () {

        if (levelManager == null)
        {
            levelManager = this;
        }

        //player = FindObjectOfType<PlayerController>();

		//Transform spawnPoint = currentCheckpoint;
	}
	
	// Update is called once per frame
	void Update () {
        //player = FindObjectOfType<PlayerController>();
    }


	public void RespawnPlayer()
	{
        animator.SetTrigger("End");
        player.SetActive(true);
        player.transform.position = currentCheckpoint.transform.position;
        player.GetComponent<PlayerHealth2>().RestoreHealth();
        door1.SetTrigger("DoorOpen");
        door2.SetTrigger("DoorOpen");
        door3.SetTrigger("DoorOpen");
        door4.SetTrigger("DoorOpen");
        playerIsDead = false;

    }

    public static void KillPlayer(PlayerHealth2 player)
    {
        //Destroy (player.gameObject);
    }

	public void EndGame()
	{
		if (playerIsDead == false)
		{
			Debug.Log("DEAD");
			playerIsDead = true;
			Invoke("RespawnPlayer", respawnDelay);
		}
	}

	//void LoadCheckpoint()
	//{

	//}

}
