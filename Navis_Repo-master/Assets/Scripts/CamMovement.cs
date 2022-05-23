using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    private float rotVelo = 30f;
    private float moveVelo = 10f;
    private float scrollVelo = 1000f;

    private float x = 0f;
    private float y = 0f;

    private Camera cam;
    private ButtonPresses buttonPresses;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        buttonPresses = GetComponent<ButtonPresses>();
    }

    // Update is called once per frame
    void Update()
    {
        //x = -Input.GetAxis("Mouse X") * velo * Time.deltaTime;
        //y = -Input.GetAxis("Mouse Y") * velo * Time.deltaTime;

        if(buttonPresses.Up())
        {
            transform.position += transform.up * moveVelo * Time.deltaTime;
        }

        if(buttonPresses.Down())
        {
            transform.position -= transform.up * moveVelo * Time.deltaTime;
        }

        if(buttonPresses.Left())
        {
            transform.position -= transform.right * moveVelo * Time.deltaTime;
        }

        if(buttonPresses.Right())
        {
            transform.position += transform.right * moveVelo * Time.deltaTime;
        }

        if(buttonPresses.RotLeft())
        {
            transform.Rotate(0f, 0f, rotVelo * Time.deltaTime);
        }

        if(buttonPresses.RotRight())
        {
            transform.Rotate(0f, 0f, -rotVelo * Time.deltaTime);
        }

        if(buttonPresses.Reset())
        {
            transform.rotation = Quaternion.Euler(90f, 0f, 0f); 
        }

        cam.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * scrollVelo * Time.deltaTime;
    }
}
