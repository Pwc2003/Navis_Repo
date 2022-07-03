using System;
using System.Collections;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    private float rotVelo = 55f;
    private float rotZ = 1f;
    private float amountRot = 0f;
    private float moveVelo = 40f;
    private float scrollVelo = 1100f;

    private bool left;
    private bool right;
    private bool rotPlease;

    private Camera cam;
    private ButtonPresses bp;

    private Coroutine r;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        bp = GetComponent<ButtonPresses>();
    }

    // Update is called once per frame
    void Update()
    {
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
            left = true;
            StartCoroutine(stopPleasefortheLoveofGod());
            left = false;
        }

        if(bp.RiAr())
        {
            right = true;
            StartCoroutine(stopPleasefortheLoveofGod());
            right = false;
        }

        cam.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * scrollVelo * Time.deltaTime;
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, 50f, 100f);
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, 0f, 1060f);
        pos.z = Mathf.Clamp(transform.position.z, 0f, 1060f);
        transform.position = pos;
    }

    IEnumerator RotLeft()
    {
        rotPlease = true;
        while(rotPlease)
        {
            transform.Rotate(0f, 0f, 90f * Time.deltaTime);
            yield return null;
        }
        Debug.Log("Done");
    }

    IEnumerator RotRight()
    {
        rotPlease = true;
        while(rotPlease)
        {
            transform.Rotate(0f, 0f, -90f * Time.deltaTime);
            yield return null;
        }
        Debug.Log("Done");
    }

    IEnumerator stopPleasefortheLoveofGod()
    {
        if(left)
        {
            r = StartCoroutine(RotLeft());
        }
        else if(right)
        {
            r = StartCoroutine(RotRight());
        }
        Debug.Log("started");
        yield return new WaitForSeconds(1f);
        StopCoroutine(r);
        Debug.Log("stopped");
    }
}
