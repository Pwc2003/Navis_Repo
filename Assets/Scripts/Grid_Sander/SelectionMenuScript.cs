using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMenuScript : MonoBehaviour
{
    private GameObject canvas;

    private GameObject check;

    private GameObject selectedBuilding;
    private GameObject spawnedBuilding;


    [Header("Living Quarters")]
    public GameObject Flatbuilding1;
    public GameObject Flatbuilding2;

    public GameObject House1;
    public GameObject House2;
    public GameObject House3;

    [Header("Social Buildings")]
    public GameObject school1;
    public GameObject school2;

    public GameObject socialBuilding1;
    public GameObject socialBuilding2;
    public GameObject socialBuilding3;
    public GameObject socialBuilding4;

    public GameObject Hospital1;

    public GameObject Shop1;
    public GameObject shop2;

    [Header("Production Buildings")]
    public GameObject productionBuilding1;
    public GameObject productionBuilding2;
    public GameObject productionBuilding3;
    public GameObject productionBuilding4;


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
        if(check.GetComponent<SnapSystem>().snapObject != null)
        {
            check.GetComponent<SnapSystem>().snapObject.transform.Rotate(new Vector3(0, -90f, 0));
        }
    }
    public void RotateRight()
    {
        FindObject();
        if(check.GetComponent<SnapSystem>().snapObject != null)
        {
            check.GetComponent<SnapSystem>().snapObject.transform.Rotate(new Vector3(0, 90f, 0));
        }
    }

    public void SpawnFlat()
    {
        spawnedBuilding = Instantiate(Flatbuilding1, new Vector3(0, 0, 0), Quaternion.identity);
        check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
    }

    public void SpawnSchool()
    {
        spawnedBuilding = Instantiate(school1, new Vector3(0, 0, 0), Quaternion.identity);
        check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
    }

    public void SpawnSocialBuilding()
    {
        spawnedBuilding = Instantiate(socialBuilding1, new Vector3(0, 0, 0), Quaternion.identity);
        check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
    }

    public void SpawnHospital()
    {
        spawnedBuilding = Instantiate(Hospital1, new Vector3(0, 0, 0), Quaternion.identity);
        check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
    }

    public void SpawnShop()
    {
        spawnedBuilding = Instantiate(Shop1, new Vector3(0, 0, 0), Quaternion.identity);
        check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
    }

    public void SpawnProductionBuilding()
    {
        spawnedBuilding = Instantiate(productionBuilding1, new Vector3(0, 0, 0), Quaternion.identity);
        check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
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
