using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapSystem : MonoBehaviour
{
    public GameObject parent;

    [HideInInspector] public GameObject snapObject;
    private GameObject snappedPoint;
    private GameObject thisObject;

    public List<GameObject> buildings;

    private int index;

    private bool canBuild;
    private bool built = false;
    [HideInInspector] public bool overSizeZ;
    [HideInInspector] public bool overSizeX;

    private bool selectedSomething;

    private Vector3 distance;
    private Vector3 selectDistance;
    private Vector3 range;
    private Vector3 worldPosition;

    private Vector3 rotation;

    private Vector3 mousePos;

    private Plane plane =  new Plane(Vector3.up, Vector3.zero);

    void Start()
    {
        thisObject = GameObject.Find("Check");

        buildings = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(snapObject == null)
        {
            built = false;
        }
        if(!built)
        {
            Check();
        }
        if(Input.GetMouseButtonDown(0) && !parent.GetComponent<MouseOnUI>().OnMouseOver())
        {
            Select();
            Build();
        }
        if(Input.GetMouseButtonDown(0) && built)
        {
            Select();
        }
        if(Input.GetMouseButtonDown(0) && built)
        {
            foreach(GameObject snapPoint in parent.GetComponent<GridSystem_Sander>().removedSnapPoints)
            {
                snapPoint.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    void Build()
    {
        if(snappedPoint != null && !parent.GetComponent<MouseOnUI>().OnMouseOver())
        {
            //for multi cell building
            if(canBuild && overSizeX)
            {
                snappedPoint.GetComponent<Renderer>().material.color = Color.red;
                
                parent.GetComponent<GridSystem_Sander>().availableSnapPoints.Remove(snappedPoint);
                parent.GetComponent<GridSystem_Sander>().removedSnapPoints.Add(snappedPoint);
                parent.GetComponent<GridSystem_Sander>().snapPoints[index + 51].GetComponent<Renderer>().material.color = Color.red; //Let's us see if it works

                parent.GetComponent<GridSystem_Sander>().removedSnapPoints.Add(parent.GetComponent<GridSystem_Sander>().snapPoints[index + 51]);
                parent.GetComponent<GridSystem_Sander>().availableSnapPoints.Remove(parent.GetComponent<GridSystem_Sander>().snapPoints[index + 51]);

                parent.GetComponent<GridSystem_Sander>().snapPoints[index - 51].GetComponent<Renderer>().material.color = Color.red;
                parent.GetComponent<GridSystem_Sander>().removedSnapPoints.Add(parent.GetComponent<GridSystem_Sander>().snapPoints[index - 51]);
                parent.GetComponent<GridSystem_Sander>().availableSnapPoints.Remove(parent.GetComponent<GridSystem_Sander>().snapPoints[index - 51]);
                snapObject.transform.position = snappedPoint.transform.position;
                buildings.Add(snapObject);
                built = true;
                snapObject = null;
            }
            
            //for multi cell building
            if(canBuild && overSizeZ)
            {
                snappedPoint.GetComponent<Renderer>().material.color = Color.red;
                parent.GetComponent<GridSystem_Sander>().availableSnapPoints.Remove(snappedPoint);
                parent.GetComponent<GridSystem_Sander>().removedSnapPoints.Add(snappedPoint);
                
                parent.GetComponent<GridSystem_Sander>().snapPoints[index + 1].GetComponent<Renderer>().material.color = Color.red; //Let's us see if it works
                parent.GetComponent<GridSystem_Sander>().removedSnapPoints.Add(parent.GetComponent<GridSystem_Sander>().snapPoints[index + 1]);
                parent.GetComponent<GridSystem_Sander>().availableSnapPoints.Remove(parent.GetComponent<GridSystem_Sander>().snapPoints[index + 1]);

                parent.GetComponent<GridSystem_Sander>().snapPoints[index - 1].GetComponent<Renderer>().material.color = Color.red;
                parent.GetComponent<GridSystem_Sander>().removedSnapPoints.Add(parent.GetComponent<GridSystem_Sander>().snapPoints[index - 1]);
                parent.GetComponent<GridSystem_Sander>().availableSnapPoints.Remove(parent.GetComponent<GridSystem_Sander>().snapPoints[index - 1]);

                snapObject.transform.position = snappedPoint.transform.position;
                buildings.Add(snapObject);
                built = true;
                snapObject = null;
            }

            //for single cell building
            if(!overSizeX && !overSizeZ && canBuild)
            {
                snappedPoint.GetComponent<Renderer>().material.color = Color.red;
                parent.GetComponent<GridSystem_Sander>().availableSnapPoints.Remove(snappedPoint);
                parent.GetComponent<GridSystem_Sander>().removedSnapPoints.Add(snappedPoint);

                snapObject.transform.position = snappedPoint.transform.position;
                buildings.Add(snapObject);
                built = true;
                snapObject = null;
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
            if(distance.magnitude < 10f && snapObject != null)
            {
                snapObject.transform.position = snapPoint.transform.position;
                snappedPoint = snapPoint;
                index = parent.GetComponent<GridSystem_Sander>().snapPoints.IndexOf(snappedPoint);
                CheckSize();
            }
        }
    }

    void Select()
    {
        float fDistance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out fDistance))
        {
            worldPosition = ray.GetPoint(fDistance);
        }

        transform.position = worldPosition;

        foreach(GameObject building in buildings)
        {
            selectDistance = building.transform.position - transform.position;
            Debug.Log(selectDistance.magnitude);

            if(selectDistance.magnitude < 10f)
            {
                building.GetComponent<Selected>().selected = true;
            }
            else
            {
                building.GetComponent<Selected>().selected = false;
            }
        }
    }

    public void CheckSize()
    {
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
            overSizeX = true;
        }
        else
        {
            overSizeX = false;
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
            overSizeZ = true;
        }
        else
        {
            overSizeZ = false;
        }
    }
}
