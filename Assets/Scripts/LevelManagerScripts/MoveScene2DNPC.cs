using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene2DNPC : MonoBehaviour
{


         public int level = 0;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("NPC"))
            {
                FindObjectOfType<LevelLoader>().LoadLevel(level);
            }
        }

    
}
