using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCJumpPad : MonoBehaviour
{
	[SerializeField]
	private int speed;

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("NPC"))
		{
			other.gameObject.GetComponent<Rigidbody2D>
				().AddForce(Vector3.up * speed);
		}
	}
}
