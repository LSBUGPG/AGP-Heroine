using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PagesPanel : MonoBehaviour
{

    public Image page1;
    public Image page2;
    public Image page3;
    public Image page4;
    public Image page5;
    public Image page6;
   // public string 


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
      // int pickedUp = PlayerPrefs.GetInt(name, 0);
                      
        //   if (pickedUp == 0)
        //    {
        //      page1.sprite = null;
        //  }

        page1.enabled = PlayerPrefs.GetInt("Page1", 0) == 1;
        page2.enabled = PlayerPrefs.GetInt("Page2", 0) == 1;
        page3.enabled = PlayerPrefs.GetInt("Page3", 0) == 1;
        page4.enabled = PlayerPrefs.GetInt("Page4", 0) == 1;
        page5.enabled = PlayerPrefs.GetInt("Page5", 0) == 1;
        page6.enabled = PlayerPrefs.GetInt("Page6", 0) == 1;

    }


}
