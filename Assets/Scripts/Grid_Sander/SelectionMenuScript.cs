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
        canvas = GameObject.Find("IDK");
        check = GameObject.Find("Check");
    }

    public void Destroy()
    {
        FindObject();
        Destroy(selectedBuilding);
    }

    public void RotateLeft()
    {
        FindObject();
        selectedBuilding.transform.Rotate(new Vector3(0, -90, 0));
        rotateLeft = true;
    }

    public void RotateRight()
    {
        FindObject();
        selectedBuilding.transform.Rotate(new Vector3(0, 90, 0));
        rotateRight = true;
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
