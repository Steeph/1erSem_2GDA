using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;

	public Vector3 offset;
	public float camHSpeed = 5f;
	public float camVSpeed = 5f;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {


	}

	void FixedUpdate () {

		Vector3 targetCamPos;
		targetCamPos = target.position + offset;
		transform.LookAt (target.position);

		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
