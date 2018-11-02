using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    [Header("Déplacement")]
    public float speed = 10f;
    private  Vector3 movement;
    private Rigidbody rb;

    [Header("CameraRotation")]
    public float sensitivity = 5f;
    private float yRot;
    private float xRot;
    private Vector3 rotation = Vector3.zero;
    private Vector3 RotateCam = Vector3.zero;
    private float yRotationMin = -100f;
    private float yRotationMax = 100f;

    [SerializeField]
    private Camera cam;

    [Header("CameraZoom")]
    public float minFov = 15f;
    public float maxFov = 90f;
    public float zoomSensitivity = 10f;

    [Header("Collision")]
    int spawnIndicator = 0;
    public GameObject glow_blue;
    public GameObject glow_green;
    public GameObject glow_orange;
    public GameObject glow_purple;

    public static Transform playertransform;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        playertransform = transform;
        movement = Vector3.zero;
        
        // Player Movement with camera Rotation

        if (Input.GetKey(KeyCode.Q))
        {
            movement -= transform.right;
            //rb.MovePosition(transform.position - transform.right * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement += transform.right;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            movement += transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement -= transform.forward;
        }

        //  rb.MovePosition( movement * speed * Time.deltaTime);
        rb.MovePosition(transform.position + movement.normalized * speed * Time.deltaTime);
        
        // Camera Zoom

        float fov = Camera.main.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;

        // Camera Rotation Input
        yRot = Input.GetAxisRaw("Mouse X");
        xRot = Input.GetAxisRaw("Mouse Y"); 
        xRot = Mathf.Clamp(xRot, yRotationMin, yRotationMax);
    }

    private void FixedUpdate()
    {
       // Camera Rotation Apply
        rotation = new Vector3(0f, yRot, 0f) * sensitivity;
        RotateCam = new Vector3(xRot, 0f, 0f) * sensitivity;
       // cam.transform.Rotate(-RotateCam);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation)); 
    }

    /*  void OnCollisionEnter(Collision col)
      {
          if (col.gameObject.CompareTag("light"))
          {

              Destroy(col.gameObject);
          }
      }*/

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("light"))
        {
            Debug.Log(spawnIndicator);
            Whisp Whisp = col.gameObject.GetComponent<Whisp>();
            int colorIndicator = Whisp.indicator;
            Destroy(col.gameObject);
            spawnInsideWhisp(colorIndicator, spawnIndicator);
            spawnIndicator++;

        }
    }

    void spawnInsideWhisp(int colorIndicator, int spawnIndicator)
    {
        Transform spawn = transform.GetChild(1);
        switch (colorIndicator)
        {
            case 1:
                Instantiate(glow_blue, spawn.GetChild(spawnIndicator).position, spawn.GetChild(spawnIndicator).rotation, this.transform);
                break;

            case 2:
                Instantiate(glow_green, spawn.GetChild(spawnIndicator).position, spawn.GetChild(spawnIndicator).rotation, this.transform);
                break;

            case 3:
                Instantiate(glow_orange, spawn.GetChild(spawnIndicator).position, spawn.GetChild(spawnIndicator).rotation, this.transform);
                break;

            case 4:
                Instantiate(glow_purple, spawn.GetChild(spawnIndicator).position, spawn.GetChild(spawnIndicator).rotation, this.transform);
                break;

            default:
                break;
        }

    }

}
