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
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask whatIsGround;

	private int extraJumps;
	public int extraJumpsValue;


	List<string> keys = new List<string>();

	// Use this for initialization
	void Start () {
		extraJumps = extraJumpsValue;
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator>();
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

	void Update (){

		if (isGrounded == true) {
			extraJumps = extraJumpsValue;
            anim.SetBool("InAir", false);
        }

		if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
		{
			rb.velocity = Vector2.up * jumpForce;
			extraJumps--;
            anim.SetBool("InAir", true);
		} else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
		{
			rb.velocity = Vector2.up * jumpForce;
            anim.SetBool("InAir", true);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Key")) {
			keys.Add(other.name);
			Destroy (other.gameObject);
		}
		if (other.gameObject.CompareTag ("Door")) {
			if(keys.Contains(other.name)){
				keys.Remove(other.name);
				Destroy (other.gameObject);
			}
			
		}
	}
}
