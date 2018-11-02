using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camRotation : MonoBehaviour {

    [Header("Parameters")]
    private float distance = 15f;
    private float currentX = 0.01f;
    private float currentY = 0.01f;
    public float xSensitvity = 4.0f;
    public float ySensitvity = 4.0f;

    // settings
    private float yRotationMin = -60f;
    private float yRotationMax = 30f;



    public Transform player;

    private Camera cam;
	// Use this for initialization
	void Start () {
        cam = Camera.main;
	}

    private void Update()
    {
        currentY += Input.GetAxisRaw("Mouse X") * xSensitvity;
        currentX += Input.GetAxisRaw("Mouse Y") * ySensitvity;
        currentX = Mathf.Clamp(currentX, yRotationMin, yRotationMax);
    }
    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(-currentX, currentY, 0);
       transform.position = player.position + rotation * dir;
        transform.LookAt(player.position);

    }
}
