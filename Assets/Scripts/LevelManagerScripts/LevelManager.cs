using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;

    private PlayerController player;

	bool playerIsDead = false;

	public float respawnDelay = 1f;
    public Animator door1;
    public Animator door2;


    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RespawnPlayer()
	{
		Debug.Log ("Player Respawn");
        player.transform.position = currentCheckpoint.transform.position;
        player.GetComponent<PlayerHealth2>().RestoreHealth();
        door1.SetTrigger("DoorOpen");
        door2.SetTrigger("DoorOpen");
        playerIsDead = false;

    }

    public static void KillPlayer(PlayerHealth2 player)
    {
        Destroy (player.gameObject);
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
