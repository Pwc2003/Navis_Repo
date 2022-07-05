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

    public GameObject hospital1;

    public GameObject shop1;
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
        }
    }

    public void SpawnFlat2()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(Flatbuilding2, new Vector3(0, 0, 0), Quaternion.identity);
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

    public void SpawnHouse2()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(House2, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
        }
    }

    public void SpawnHouse3()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(House3, new Vector3(0, 0, 0), Quaternion.identity);
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

    public void SpawnSocialBuilding2()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(socialBuilding2, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
        }
    }

    public void SpawnSocialBuilding3()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(socialBuilding3, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
        }
    }

    public void SpawnSocialBuilding4()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(socialBuilding4, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
        }
    }

    public void SpawnHospital()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(hospital1, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
        }
    }

    public void SpawnShop()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(shop1, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
        }
    }

    public void SpawnShop2()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(shop2, new Vector3(0, 0, 0), Quaternion.identity);
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

    public void SpawnProductionBuilding2()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(productionBuilding2, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
        }
    }

    public void SpawnProductionBuilding3()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(productionBuilding3, new Vector3(0, 0, 0), Quaternion.identity);
            check.GetComponent<SnapSystem>().snapObject = spawnedBuilding;
        }
    }

    public void SpawnProductionBuilding4()
    {
        if (totalAmounts.totalNonRenewableAmount > totalAmounts.nonRenewableBuildingCost && totalAmounts.totalWoodAmount > totalAmounts.woodBuildingCost && totalAmounts.totalEnergyProduction > totalAmounts.electricityBuildingCost && totalAmounts.totalWaterProduction > totalAmounts.waterBuildingCost && totalAmounts.totalFoodAmount > totalAmounts.foodBuildingCost)
        {
            spawnedBuilding = Instantiate(productionBuilding4, new Vector3(0, 0, 0), Quaternion.identity);
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
            if(snapPoint.transform.position == selectedBuilding.transform.position)
            {
                buildingSnapPoint = snapPoint;
            }
        }
    }
}
