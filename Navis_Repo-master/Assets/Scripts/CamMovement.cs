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
    private ButtonPresses bp;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        bp = GetComponent<ButtonPresses>();
    }

    // Update is called once per frame
    void Update()
    {
        //x = -Input.GetAxis("Mouse X") * velo * Time.deltaTime;
        //y = -Input.GetAxis("Mouse Y") * velo * Time.deltaTime;

        if(bp.W())
        {
            transform.position += transform.up * moveVelo * Time.deltaTime;
        }

        if(bp.S())
        {
            transform.position -= transform.up * moveVelo * Time.deltaTime;
        }

        if(bp.A())
        {
            transform.position -= transform.right * moveVelo * Time.deltaTime;
        }

        if(bp.D())
        {
            transform.position += transform.right * moveVelo * Time.deltaTime;
        }

        if(bp.Q())
        {
            transform.Rotate(0f, 0f, rotVelo * Time.deltaTime);
        }

        if(bp.E())
        {
            transform.Rotate(0f, 0f, -rotVelo * Time.deltaTime);
        }

        if(bp.Reset())
        {
            transform.rotation = Quaternion.Euler(90f, 0f, 0f); 
        }

        if(bp.LeAr())
        {
            transform.Rotate(0f, 0f, 90f);
        }

        if(bp.RiAr())
        {
            transform.Rotate(0f, 0f, -90f);
        }

        cam.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * scrollVelo * Time.deltaTime;
    }
}
