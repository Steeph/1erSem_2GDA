using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisp : MonoBehaviour {

	public Transform player;
	private float distance;
	private float speed;
	private Vector3 direction;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		direction = transform.position - player.position;
		direction = direction.normalized;

		distance = Vector3.Distance (transform.position, player.position);

		transform.position +=  -direction * speed * Time.deltaTime;


		if (distance < 20 && distance > 10) {
			Debug.Log ("loin");
			speed = 2;
		} else if (distance < 10 && distance > 5 ) {
			speed = 3;
			Debug.Log ("moyen");
		} else if (distance < 5) {
			speed = 5;
			Debug.Log ("coming");
		} else
		{
			speed = 0;
			Debug.Log ("trop loin");
	}


	}
}
