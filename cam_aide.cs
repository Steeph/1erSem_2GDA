﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour {
	public float sensitivity = 5f;
	private float yRot;
	private float xRot;
	private Rigidbody rb;
	private Vector3 rotation = Vector3.zero;
	private Vector3 RotateCam = Vector3.zero;

	[SerializeField]
	private Camera com;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		yRot = Input.GetAxisRaw ("Mouse X");
		xRot = Input.GetAxisRaw ("Mouse Y");
		
	}

	void FixedUpdate() 
	{
		rotation = new Vector3 (0f, yRot,0f) * sensitivity;
		RotateCam = new Vector3 (xRot, 0f, 0f) * sensitivity;
		com.transform.Rotate (-RotateCam);
		rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

	}
}
