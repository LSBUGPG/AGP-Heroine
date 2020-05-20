using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jumpForce;
	private float moveInput;

	private Rigidbody2D rb;
	private Animator anim;

	private bool isGrounded;
    private bool inAir;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask whatIsGround;
    bool isMoving = false;
    AudioSource audioSrc;

	private int extraJumps;
	public int extraJumpsValue;


	List<string> keys = new List<string>();
    

	// Use this for initialization
	void Start () {
		extraJumps = extraJumpsValue;
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator>();
        audioSrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		isGrounded = Physics2D.OverlapCircle (groundCheck.position, checkRadius, whatIsGround);

		moveInput = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector2 (moveInput * speed, rb.velocity.y);

        anim.SetFloat("Sprint", Mathf.Abs(rb.velocity.x));
        //anim.SetInt("LightAnim",RandomRange(0,3));
		if (rb.velocity.x > 0)
		{
			//transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
			Vector3 transScale = transform.localScale;
			transScale.x = Mathf.Abs(transScale.x);
			transform.localScale = transScale;
           
        }


		else if (rb.velocity.x < 0)
		{
			//transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
			Vector3 transScale = transform.localScale;
			transScale.x = -Mathf.Abs(transScale.x);
			transform.localScale = transScale;
            
        }




    }


    public void Step1()
    {
        FindObjectOfType<AudioManager>().Play("Step1");
    }

    public void Step2()
    {
        FindObjectOfType<AudioManager>().Play("Step2");
    }

    void Update (){

        if (!inAir && !isGrounded)
        {
            inAir = true;
        }
        else if (inAir && isGrounded)
        {
            inAir = false;
			extraJumps = extraJumpsValue;
            FindObjectOfType<AudioManager>().Play("Land");
        }
        anim.SetBool("InAir", inAir);

        if (Input.GetKeyDown(KeyCode.UpArrow) && inAir)
        {
            anim.SetTrigger("ExtraJump");
        }

		if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps >= 0)
		{
			rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            anim.SetBool("InAir", true);
            FindObjectOfType<AudioManager>().Play("Jump");
        } else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
		{   
			rb.velocity = Vector2.up * jumpForce;
            anim.SetBool("InAir", true);
            FindObjectOfType<AudioManager>().Play("Jump");
        }

       


    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Key")) {
			keys.Add(other.name);
			Destroy (other.gameObject);
		}
        if (other.gameObject.CompareTag("Door"))
        {
            if (keys.Contains(other.name))
            {
                keys.Remove(other.name);
                Animator door = other.GetComponent<Animator>();
                door.SetTrigger("Destroy");
            }
        }
    }

    public void DestroyDoor()
    { 
    
    }
}
