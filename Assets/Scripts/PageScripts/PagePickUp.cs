using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PagePickUp : MonoBehaviour
{
  
public string name;
   

   void Awake()
   {
       
   }
   
    void Start()
    {
            int pickedUp = PlayerPrefs.GetInt(name, 0);
            if (pickedUp == 1)
            {
                gameObject.SetActive(false);
            }
        
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
            PlayerPrefs.SetInt(name, 1);  // picked up
            gameObject.SetActive(false);  // hides object
        }

    }
}
