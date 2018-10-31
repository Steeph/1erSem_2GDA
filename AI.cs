using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

	[Header ("Déplacement")]
	public float speed = 1.5f;
	private Vector3 positionCible;
	Rigidbody rb;

	void Start ()
	{
		//rb = GetComponent<Rigidbody> ();
		//rb.AddForce ( new Vector3 (1,0,1), ForceMode.Impulse); 
		positionCible = new Vector3 (Random.Range (-5f,5f), 0 , Random.Range (-5f,5f));
	}

	void Update ()
	{
		
		Vector3 newPosition = Vector3.MoveTowards(transform.position, positionCible, speed * Time.deltaTime);

		transform.position = newPosition;

		if (transform.position == positionCible)
		{
			
			positionCible = new Vector3 (Random.Range (-5f,5f), 0 , Random.Range (-5f,5f)) * 2f;
		}

	
	}
}
