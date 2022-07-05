using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMenuScript : MonoBehaviour
{
    protected TotalOfEverything totalAmounts;
    private GameObject canvas;

    private GameObject check;

    private GameObject selectedBuilding;
    private GameObject spawnedBuilding;
    private GameObject buildingSnapPoint;


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
        canvas = GameObject.Find("HUD");
        totalAmounts = canvas.GetComponent<TotalOfEverything>();
    }
    void Update()
    {
        Debug.Log(totalAmounts.nonRenewableBuildingCost);
    }

    public void Destroy()
    {
        FindObject();
        FindSnapPoint();
        Destroy(selectedBuilding);
        buildingSnapPoint.GetComponent<Renderer>().material.color = Color.green;
        canvas.GetComponent<GridSystem_Sander>().removedSnapPoints.Remove(buildingSnapPoint);
        canvas.GetComponent<GridSystem_Sander>().availableSnapPoints.Add(buildingSnapPoint);
        check.GetComponent<SnapSystem>().buildings.Remove(selectedBuilding);
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
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(Flatbuilding1, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
        }
    }

    public void SpawnHouse()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(House1, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
        }
        
    }

    public void SpawnSchool()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(school1, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
        }
        
    }

    public void SpawnSocialBuilding()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(socialBuilding1, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
        }
        
    }

    public void SpawnHospital()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(Hospital1, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
        }
        
    }

    public void SpawnShop()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(Shop1, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
        }
        
    }

    public void SpawnProductionBuilding()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(productionBuilding1, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
        }
        
    }

    

    private void FindObject()
    {
        foreach(GameObject building in check.GetComponent<SnapSystem>().buildings)
        {
            if(building.GetComponent<Selected>().selected)
            {
                selectedBuilding = building;
            }
        }
    }

    private void FindSnapPoint()
    {
        foreach(GameObject snapPoint in canvas.GetComponent<GridSystem_Sander>().removedSnapPoints)
        {
            Debug.Log("first");
            if(snapPoint.transform.position == selectedBuilding.transform.position)
            {
                Debug.Log("second");
                buildingSnapPoint = snapPoint;
            }
        }
    }
}
