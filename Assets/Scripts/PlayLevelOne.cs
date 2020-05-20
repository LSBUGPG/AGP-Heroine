using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayLevelOne : MonoBehaviour
{
    [SerializeField] private string newLevel;

    public void LevelOne()
    {
        SceneManager.LoadScene(newLevel);
    }

   
}
