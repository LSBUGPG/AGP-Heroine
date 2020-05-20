using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PagePickUp : MonoBehaviour
{
  
public string name;
   

   void Awake()
   {

       // PlayerPrefs.SetInt(name, 0);
    }
   
    void Start()
    {
        
            //PlayerPrefs.SetInt(name, 0);
            int pickedUp = PlayerPrefs.GetInt(name, 1);
        if (pickedUp == 1)
        {
            gameObject.SetActive(false);
        }
      //  else
       // {
        //    gameObject.SetActive(true);
       // }
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
            PlayerPrefs.SetInt(name, 1);  // picked up
            gameObject.SetActive(false);  // hides object
            FindObjectOfType<AudioManager>().Play("Page");
        }

    }
}
