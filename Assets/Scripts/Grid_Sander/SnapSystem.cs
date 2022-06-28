using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapSystem : MonoBehaviour
{
    public GameObject parent;
    public GameObject snapObject;
    private GameObject snappedPoint;

    private int index;

    private bool canBuild;

    private Vector3 distance;
    private Vector3 range;
    public Vector3 worldPosition;

    private Vector3 mousePos;

    private Plane plane =  new Plane(Vector3.up, Vector3.zero);

    // Update is called once per frame
    void Update()
    {
        Check();
        Debug.Log(parent.GetComponent<GridSystem_Sander>().removedSnapPoints.Count);
        if(Input.GetMouseButtonDown(0))
        {
            Build();
        }
    }

    void Build()
    {
        if(snappedPoint != null)
        {
            Debug.Log(snapObject.GetComponentInChildren<Renderer>().bounds.size.x);
            if(snapObject.GetComponentInChildren<Renderer>().bounds.size.x/2 > 10f)
            {
                //checking if the object can be placed on the grid with the available snap points on the x-axis
                if(parent.GetComponent<GridSystem_Sander>().availableSnapPoints.Contains(parent.GetComponent<GridSystem_Sander>().snapPoints[index + 51]) && parent.GetComponent<GridSystem_Sander>().availableSnapPoints.Contains(parent.GetComponent<GridSystem_Sander>().snapPoints[index - 51]))
                {
                    canBuild = true;
                }
                else
                {
                    canBuild = false;
                }
                //for multi cell building
                if(canBuild)
                {
                    snappedPoint.GetComponent<Renderer>().material.color = Color.red;
                    parent.GetComponent<GridSystem_Sander>().availableSnapPoints.Remove(snappedPoint);

                    parent.GetComponent<GridSystem_Sander>().snapPoints[index + 51].GetComponent<Renderer>().material.color = Color.green; //Let's us see if it works

                    parent.GetComponent<GridSystem_Sander>().removedSnapPoints.Add(parent.GetComponent<GridSystem_Sander>().snapPoints[index + 51]);
                    parent.GetComponent<GridSystem_Sander>().availableSnapPoints.Remove(parent.GetComponent<GridSystem_Sander>().snapPoints[index + 51]);

                    parent.GetComponent<GridSystem_Sander>().snapPoints[index - 51].GetComponent<Renderer>().material.color = Color.green;

                    parent.GetComponent<GridSystem_Sander>().removedSnapPoints.Add(parent.GetComponent<GridSystem_Sander>().snapPoints[index - 51]);
                    parent.GetComponent<GridSystem_Sander>().availableSnapPoints.Remove(parent.GetComponent<GridSystem_Sander>().snapPoints[index - 51]);
                }
            }
            if(snapObject.GetComponentInChildren<Renderer>().bounds.size.z/2 > 10f)
            {
                //checking if the object can be placed on the grid with the available snap points on the z-axis
                if(parent.GetComponent<GridSystem_Sander>().availableSnapPoints.Contains(parent.GetComponent<GridSystem_Sander>().snapPoints[index + 1]) && parent.GetComponent<GridSystem_Sander>().availableSnapPoints.Contains(parent.GetComponent<GridSystem_Sander>().snapPoints[index - 1]))
                {
                    canBuild = true;
                }
                else
                {
                    canBuild = false;
                }
                //for multi cell building
                if(canBuild)
                {
                    snappedPoint.GetComponent<Renderer>().material.color = Color.red;
                    parent.GetComponent<GridSystem_Sander>().availableSnapPoints.Remove(snappedPoint);
                    
                    parent.GetComponent<GridSystem_Sander>().snapPoints[index + 1].GetComponent<Renderer>().material.color = Color.green; //Let's us see if it works

                    parent.GetComponent<GridSystem_Sander>().removedSnapPoints.Add(parent.GetComponent<GridSystem_Sander>().snapPoints[index + 1]);
                    parent.GetComponent<GridSystem_Sander>().availableSnapPoints.Remove(parent.GetComponent<GridSystem_Sander>().snapPoints[index + 1]);

                    parent.GetComponent<GridSystem_Sander>().snapPoints[index - 1].GetComponent<Renderer>().material.color = Color.green;

                    parent.GetComponent<GridSystem_Sander>().removedSnapPoints.Add(parent.GetComponent<GridSystem_Sander>().snapPoints[index - 1]);
                    parent.GetComponent<GridSystem_Sander>().availableSnapPoints.Remove(parent.GetComponent<GridSystem_Sander>().snapPoints[index - 1]);
                }
            }
        }
    }

    //checking which available snap point is closest to the mouse position
    void Check()
    {
        float fDistance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out fDistance))
        {
            worldPosition = ray.GetPoint(fDistance);
        }
        transform.position = worldPosition;
        foreach(GameObject snapPoint in parent.GetComponent<GridSystem_Sander>().availableSnapPoints)
        {
            distance = snapPoint.transform.position - transform.position;

            if(distance.magnitude < 10f)
            {
                snapObject.transform.position = snapPoint.transform.position;
                snappedPoint = snapPoint;
                index = parent.GetComponent<GridSystem_Sander>().snapPoints.IndexOf(snappedPoint);
            }
        }
    }
}
