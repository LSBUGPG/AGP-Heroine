using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;

    public static bool GameIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
               Resume();
            }
            else 
            {
                 Pause();
            }
        }
    }

    
    
    public void Pause()
    {
        pauseMenuUI.SetActive(true); // shows menu
        Time.timeScale = 0f; //pauses game time
        GameIsPaused = true; //sets bool to true
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); //hides menu
        Time.timeScale = 1f; //resumes game time
        GameIsPaused = false; //sets bool to false
        optionsMenuUI.SetActive(false);
    }



}
