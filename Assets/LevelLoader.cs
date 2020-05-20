using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;

    public Animator transition;

    public float transitionTime;


    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
       

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        // Play animation
        transition.SetTrigger("Start");

        //Wait for animation to stop playing
        yield return new WaitForSeconds(transitionTime);
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            
            yield return null;
        }
           
        

         //Load Scene
        SceneManager.LoadScene(sceneIndex);
    }



   
     
}
