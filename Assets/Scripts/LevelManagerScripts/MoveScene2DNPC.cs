using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene2DNPC : MonoBehaviour
{
    

       [SerializeField] private string newLevel;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("NPC"))
            {
                SceneManager.LoadScene(newLevel);
            }
        }

    
}
