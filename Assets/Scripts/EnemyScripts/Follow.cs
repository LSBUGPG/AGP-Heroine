using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    public float speed;

    private Transform target;

    private bool canMove;

   // [SerializeField]
   // private int range;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) <= 10)
        {

            canMove = true;
        }

        else
        {
            canMove = false;
        }

        if (Vector2.Distance(transform.position, target.position) <= 1f)
        {
            canMove = false;
        }

        if (canMove)
        {
            if (target.position.x > transform.position.x)
                transform.eulerAngles = Vector3.up * 180;
            else if (target.position.x < transform.position.x)
                transform.eulerAngles = Vector3.zero;

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }

}

