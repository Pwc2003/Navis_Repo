using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMenuScript : MonoBehaviour
{
    private GameObject canvas;

    private GameObject check;

    private GameObject selectedBuilding;

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
