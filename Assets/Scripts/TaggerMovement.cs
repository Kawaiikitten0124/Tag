using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tagger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private float speed = 20.0f;
    private float horizontalInput;
    private float forwardInput;
    public float xRange = 10.0f;
    public float zRange = 10.0f;
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        // Moves the cube forward basedf on virtical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Moves the cube left and right based on horizontal input
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right* horizontalInput * Time.deltaTime * speed);

        // keep cube in bounds left aand right

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime);
        
        // keep cube in bounds up and down

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("vertical");
        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime);
    }
}
