using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	[Header ("Déplacement")]
	public float speed = 5f;
	public Vector3 moveDirection;
	Vector3 movement;
	Rigidbody rb;

	// Use this for initialization
	void Start ()
	{

		rb= GetComponent<Rigidbody> ();

	}

	void Update ()
	{
	
		if (Input.GetKey(KeyCode.Q))
			{
			rb.MovePosition(transform.position - transform.right * Time.deltaTime * speed);
			}
		
		if (Input.GetKey(KeyCode.D))
		{
			rb.MovePosition(transform.position + transform.right * Time.deltaTime * speed);
		}		

		if (Input.GetKey(KeyCode.Z))
		{
			rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
		}		

		if (Input.GetKey(KeyCode.S))
		{
			rb.MovePosition(transform.position - transform.forward * Time.deltaTime * speed);
		}			
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag("light")) {
			
			Destroy (col.gameObject);
		}
	}


		
}
