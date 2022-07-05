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
    }

    public void Destroy()
    {
        FindObject();
        FindSnapPoint();
        buildingSnapPoint.GetComponent<Renderer>().material.color = Color.gray;
        buildingSnapPoint.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;
        Destroy(selectedBuilding);
        Debug.Log("Before " + canvas.GetComponent<GridSystem_Sander>().removedSnapPoints.Count);
        Debug.Log("Before " + canvas.GetComponent<GridSystem_Sander>().availableSnapPoints.Count);
        canvas.GetComponent<GridSystem_Sander>().removedSnapPoints.Remove(buildingSnapPoint);
        canvas.GetComponent<GridSystem_Sander>().availableSnapPoints.Add(buildingSnapPoint);
        Debug.Log("After " + canvas.GetComponent<GridSystem_Sander>().removedSnapPoints.Count);
        Debug.Log("After " + canvas.GetComponent<GridSystem_Sander>().availableSnapPoints.Count);
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
            spawnedBuilding.GetComponent<PopulationProduction>().RetractCosts();
        }
    }

    public void SpawnHouse()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(House1, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
            spawnedBuilding.GetComponent<PopulationProduction>().RetractCosts();
        }
        
    }

    public void SpawnSchool()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(school1, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
            spawnedBuilding.GetComponent<PopulationProduction>().RetractCosts();
        }
        
    }

    public void SpawnSocialBuilding()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(socialBuilding1, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
            spawnedBuilding.GetComponent<PopulationProduction>().RetractCosts();
        }
        
    }

    public void SpawnHospital()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(Hospital1, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
            spawnedBuilding.GetComponent<PopulationProduction>().RetractCosts();
        }
        
    }

    public void SpawnShop()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(Shop1, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
            spawnedBuilding.GetComponent<PopulationProduction>().RetractCosts();
        }
        
    }

    public void SpawnWoodProductionBuilding()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(woodProductionBuilding1, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
            spawnedBuilding.GetComponent<PopulationProduction>().RetractCosts();
        }
    }

    public void SpawnWaterProductionBuilding()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(waterProductionBuilding1, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
            spawnedBuilding.GetComponent<PopulationProduction>().RetractCosts();
        }
    }

    public void SpawnElectricityProductionBuilding()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(electricityProductionBuilding1, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
            spawnedBuilding.GetComponent<PopulationProduction>().RetractCosts();
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
            if(snapPoint.transform.position == selectedBuilding.transform.position)
            {
                buildingSnapPoint = snapPoint;
            }
        }
    }
}
