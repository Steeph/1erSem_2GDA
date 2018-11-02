using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCompetences : MonoBehaviour {

    public GameObject Whisp;

    private Vector3 spawn;

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnWhisp();
        }
	}

    void SpawnWhisp()
    {
        spawn = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
        Instantiate(Whisp, spawn, transform.rotation);
    }
}
