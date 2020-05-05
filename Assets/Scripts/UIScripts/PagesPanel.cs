using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PagesPanel : MonoBehaviour
{

    public Image page1;
    public Image page2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnEnable()
    {
        int pickedUp = PlayerPrefs.GetInt("Page1", 0);
            if (pickedUp == 0)
            {
                page1.sprite = null;
            }    
    }
}
