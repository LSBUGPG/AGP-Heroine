using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NPCAI : MonoBehaviour
{

    public Transform target;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    //public Transform groundCheck;
   // public float checkRadius;
	//public LayerMask whatIsGround;
   // public float jumpForce;
    //private int jumps;
	//public int extraJumpsValue;

	//public Transform enemyGFX;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath()
    {
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p) //to signal path has been found
    {
     if(!p.error)
     {
         path = p;
         currentWaypoint = 0;
     }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        } else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        //bool isGrounded = Physics2D.OverlapCircle (groundCheck.position, checkRadius, whatIsGround);
        //bool jumpUp = direction.y > 0.1f;
        //if(!jumpUp)
       // {
       //     direction.y = 0f;
        //}
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);
        //if (isGrounded)
        //{
          //  jumps = 1 + extraJumpsValue;
        //}

        //if (jumpUp && (isGrounded || jumps > 0 && rb.velocity.y < 0.0f))
        //{
          //  Vector2 velocity = rb.velocity;
            //velocity.y = jumpForce;
            //rb.velocity = velocity;
            //jumps--;
       // }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

		//if (rb.velocity.x >= 0.01f)
		//{
		//	enemyGFX.localScale = new Vector3(-0.55f, 0.55f, 0.55f);
		//}
		//else if (rb.velocity.x <= -0.01f)
		//{
		//	enemyGFX.localScale = new Vector3(0.55f, 0.55f, 0.55f);
		//}

	}
    
}
