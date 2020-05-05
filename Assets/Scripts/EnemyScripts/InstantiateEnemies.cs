using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemies : MonoBehaviour
{
   
public Transform SpawnPoint;
public GameObject Prefab;

   void OnTriggerEnter2D(Collider2D other)
   {
    if (other.gameObject.tag == ("Player"))
    {
           Instantiate(Prefab, SpawnPoint.position, SpawnPoint.rotation);
           Destroy(gameObject);
    }
   }
}
