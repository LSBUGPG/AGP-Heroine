using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth2 : MonoBehaviour
{

    public LevelManager levelManager;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    private PlayerController player;
    bool playerIsDead = false;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    [System.Serializable]
    public class PlayerStats
    {
  
        public int Health = 5;
        
    }

    [SerializeField]
    private PlayerStats playerStats = new PlayerStats();

    public void DamagePlayer(int damage)
    {
        playerStats.Health -= damage;
        if (playerStats.Health <= 0 && playerIsDead == false)
        {
            FindObjectOfType<LevelManager>().EndGame();
            playerIsDead = true;
            //Destroy(gameObject);

        }
    }

    public void RestoreHealth()
    {
        playerStats.Health = 5;
        playerIsDead = false;
    }

     void Update()
    {

        if (playerStats.Health > numOfHearts)
        {
            playerStats.Health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < playerStats.Health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

}