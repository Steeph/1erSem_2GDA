using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insideWhisp : MonoBehaviour {

    private float timer = 0f;
    private float speed = 2f;
    private float angle = 0f;
	
	// Update is called once per frame
	void Update () {
        float radius = playerMovement.playertransform.GetComponent<Collider>().bounds.size.x / 3;

        float z = playerMovement.playertransform.position.z + Mathf.Cos(angle) * radius;
        float y = playerMovement.playertransform.position.y + Mathf.Sin(angle) * radius;
        transform.position = new Vector3(0, y, z);

        angle += Time.deltaTime;
        if (angle >= 360f)
        {
            angle = 0f;
        }




       
	}
}
