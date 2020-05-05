using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public Animator gasPlant;

    public GameObject gas;

    [SerializeField]
    private int speed;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>
                ().AddForce(Vector3.up * speed);
            gasPlant.SetTrigger("Contact");
            Instantiate(gas, transform.position, transform.rotation);
        }
    }
}
