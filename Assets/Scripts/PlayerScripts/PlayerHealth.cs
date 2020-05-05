using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public LevelManager levelManager;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
   
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
        if (playerStats.Health <= 0)
        {
           // LevelManager.KillPlayer(this);
            levelManager.RespawnPlayer();

        }
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
