using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	[Header ("Déplacement")]
	public float speed = 5f;
	public Vector3 moveDirection;
	Vector3 movement;
	Rigidbody playerRigidbody;

	// Use this for initialization
	void Start ()
	{

		playerRigidbody = GetComponent<Rigidbody> ();

	}

	void FixedUpdate ()
	{
	
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
			
	
	}

	void Update ()
	{
		
	}

	void Move (float h, float v)
	{
	
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition (transform.position + movement);

		Vector3 x = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		x.z = 0;
		transform.up = x - transform.position;
	}
}
