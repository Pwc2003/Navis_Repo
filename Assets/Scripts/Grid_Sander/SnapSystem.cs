using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapSystem : MonoBehaviour
{
    public GameObject parent;
    public GameObject snapObject;
    private GameObject snappedPoint;

    private Vector3 distance;
    private Vector3 range;
    public Vector3 worldPosition;

    private Vector3 mousePos;

    private Plane plane =  new Plane(Vector3.up, Vector3.zero);

    // Update is called once per frame
    void Update()
    {
        Check();
        if(Input.GetMouseButtonDown(0))
        {
            Build();
        }
    }

    void Build()
    {
        if(snappedPoint != null)
        {
            snappedPoint.GetComponent<Renderer>().material.color = Color.red;
            parent.GetComponent<GridSystem_Sander>().snapPoints.Remove(snappedPoint);
        }
    }

    void Check()
    {
        float fDistance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out fDistance))
        {
            worldPosition = ray.GetPoint(fDistance);
        }
        transform.position = worldPosition;
        foreach(GameObject snapPoint in parent.GetComponent<GridSystem_Sander>().snapPoints)
        {
            distance = snapPoint.transform.position - transform.position;

            if(distance.magnitude < 10f)
            {
                snapObject.transform.position = snapPoint.transform.position;
                snappedPoint = snapPoint;
            }
        }
    }
}
