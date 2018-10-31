using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_source : MonoBehaviour {

	public GameObject source_go;
	public List<Color> possibleColors;
	public float cool_down = 5f;
	Renderer rend;
	float compteur =0f;
	// Use this for initialization
	void Start () {




	}
	
	// Update is called once per frame
	void Update () {
		
		if (compteur <= 0) {
		
			GameObject source = (GameObject)Instantiate (source_go, transform.position, transform.rotation);
			source.GetComponent<Light> ().color = possibleColors [Random.Range (0, possibleColors.Count - 1)];
			source.GetComponent<Renderer>().material.color = source.GetComponent<Light>().color;

			compteur = cool_down;
		}
		compteur -= Time.deltaTime;

		
	}


}
