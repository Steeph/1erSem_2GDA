using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class absorb : MonoBehaviour {

	public List<Color> possibleColors;
	public GameObject source;

	Color color;

	Renderer playerRenderer;
	// Use this for initialization
	void Start () {

		playerRenderer = GetComponent<Renderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
	
		if (other.gameObject.tag == "source") {
			Debug.Log ("on se touche");
			//color = other.gameObject.GetComponent<Renderer> ().material.color;
			//playerRenderer.material.color = color;

			//GameObject source_ = (GameObject) Instantiate (source, transform.position, transform.rotation);
			GameObject source_ = other.gameObject;
			source_.transform.parent = transform;
			source_.transform.localPosition = Vector3.zero;
			source_.GetComponent<Light>().color =  possibleColors [Random.Range (0, possibleColors.Count - 1)];
			other.enabled = false;
			Destroy (source_.GetComponent<AI> ());

		
		}
	
	}
}
