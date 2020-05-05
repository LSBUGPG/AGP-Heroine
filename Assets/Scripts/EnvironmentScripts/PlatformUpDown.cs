using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUpDown : MonoBehaviour
{
    //points to travel to and from

    
    [SerializeField]
    public float speed;
    [SerializeField]
        Transform[] positions; 

    int index = 1; 

    // Start is called before the first frame update
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, positions[index].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, positions[index].position) <= 0.1f)
        {
            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {
        index += 1;
        if (index == 3)
        {
            index = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        } }
}
