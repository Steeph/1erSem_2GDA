using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whisp : MonoBehaviour {

    private Transform player;
    private float distance;
    private float speed;
    private float modificateur;
    private Vector3 direction;
    public int indicator;

    public GameObject glow_blue;
    public GameObject glow_green;
    public GameObject glow_orange;
    public GameObject glow_purple;
    // Use this for initialization
    void Start()
    {
        indicator = Random.Range(1, 4);

        switch (indicator)
        {
            case 1:
                 Instantiate(glow_blue, transform.position, transform.rotation, this.transform);
                break;

            case 2:
                Instantiate(glow_green, transform.position, transform.rotation, this.transform);
                break;

            case 3:
                Instantiate(glow_orange, transform.position, transform.rotation, this.transform);
                break;

            default:
                Instantiate(glow_purple, transform.position, transform.rotation, this.transform);
                break;
        }
    }

    private void Update()
    {
        player = playerMovement.playertransform;
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        distance = Vector3.Distance(transform.position, player.position);


        if (distance < 20 && distance > 10)
        {
            Debug.Log("loin");
            speed = 3;
            modificateur = -Random.Range(1, 10);
            direction = transform.position - player.position;
            direction.Set(direction.x, direction.y * modificateur, direction.z);
            direction = direction.normalized;
        }
        else if (distance < 10 && distance > 5)
        {
            speed = 5;
            Debug.Log("moyen");
            modificateur = -Random.Range(1, 10);
            direction = transform.position - player.position;
            direction.Set(direction.x, direction.y * modificateur, direction.z);
            direction = direction.normalized;
        }
        else if (distance < 5)
        {
            speed = 8;
            Debug.Log("coming");
            modificateur = -Random.Range(1, 10);
            direction = transform.position - player.position;
            direction.Set(direction.x, direction.y * modificateur, direction.z);
            direction = direction.normalized;
        }
        else
        {
            speed = 1;
            Debug.Log("trop loin");

            direction = new Vector3(Random.Range(1, 20), Random.Range(1, 20), Random.Range(1, 20));
            direction = direction.normalized;
        }

        transform.position += (direction * speed * Time.deltaTime);


    }
}
