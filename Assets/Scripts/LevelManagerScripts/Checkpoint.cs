using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public LevelManager levelManager;
    private PlayerController player;


    // Use this for initialization
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update () {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            levelManager.currentCheckpoint = gameObject;
            Debug.Log("Activated Checkpoint " + transform.position);
            player.GetComponent<PlayerHealth2>().RestoreHealth();
        }
    }

}
