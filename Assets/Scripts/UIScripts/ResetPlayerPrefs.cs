using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Application.isEditor){
            Debug.Log("Clear");
            PlayerPrefs.DeleteAll();
        }
        PlayerPrefs.SetInt("Page1", 0);
        PlayerPrefs.SetInt("Page2", 0);
    }

    // Update is called once per frame
    void ResetPrefs()
    {
        //PlayerPrefs.get();
    }
}
