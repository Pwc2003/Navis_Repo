using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMenuScript : MonoBehaviour
{
    private GameObject canvas;

    private GameObject check;

    private GameObject selectedBuilding;

    public bool rotateLeft;
    public bool rotateRight;

    void Start()
    {
        check = GameObject.Find("Check");
    }
    void Update()
    {
    }

    public void Destroy()
    {
        FindObject();
        Destroy(selectedBuilding);
    }

    public void RotateLeft()
    {
        FindObject();
        selectedBuilding.transform.Rotate(new Vector3(0, -90f, 0));
    }
    public void RotateRight()
    {
        FindObject();
        selectedBuilding.transform.Rotate(new Vector3(0, 90, 0));
    }

    private void FindObject()
    {
        foreach(GameObject building in check.GetComponent<SnapSystem>().buildings)
        {
            if(building.GetComponent<TestForSelection>().selected)
            {
                selectedBuilding = building;
            }
        }
    }
}
