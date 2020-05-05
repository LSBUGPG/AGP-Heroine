using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

        [SerializeField] private string newLevel;

    // Start is called before the first frame update
   public void PlayGame()
    {
        SceneManager.LoadScene (newLevel);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");

        Application.Quit();
    }

   
}
