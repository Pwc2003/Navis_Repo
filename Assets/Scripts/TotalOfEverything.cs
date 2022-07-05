using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalOfEverything : MonoBehaviour
{
    private List<GameObject> woodBuildings;
    private List<GameObject> waterBuildings;
    private List<GameObject> foodBuildings;
    private List<GameObject> nonRenewableBuildings;
    private List<GameObject> energyBuildings;
    private List<GameObject> housingBuildings;
    private List<GameObject> expeditions;
    private List<GameObject> specialBuildings;
    private List<GameObject> planten;
    private List<GameObject> greenHousing;
    
    private GameObject woodBuilding;
    private GameObject waterBuilding;
    private GameObject foodBuilding;
    private GameObject nonRenewableBuilding;
    private GameObject energyBuilding;
    private GameObject housingBuilding;
    private GameObject expedition;
    private GameObject specialBuilding;
    private GameObject plant;
    private GameObject greenhouse;

    
    [HideInInspector]public float totalWoodAmount = 0;
    [HideInInspector]public float totalWaterProduction = 0;
    [HideInInspector]public float totalFoodAmount = 0;
    [HideInInspector]public float totalNonRenewableAmount = 0;
    [HideInInspector]public float totalEnergyProduction = 0;
    [HideInInspector]public float totalPopulationAmount = 0;
    [HideInInspector]public float totalExpeditions = 0;
    [HideInInspector]public float totalPopulationCap = 0;
    [HideInInspector]public float woodBuildingCost = 0;
    [HideInInspector]public float waterBuildingCost = 0;
    [HideInInspector]public float foodBuildingCost = 0;
    [HideInInspector]public float nonRenewableBuildingCost = 0;
    [HideInInspector]public float electricityBuildingCost = 0;


    private float timer = 0;
    private int iWo = 0;
    private int iWa = 0;
    private int iF = 0;
    private int iE = 0;
    private int iNR = 0;
    private int iP = 0;
    private int iExp = 0;
    private int happiness = 0;
    private int ecologie = 0;
    private int plants = 0;
    private int greenHousings = 0;

    public Text woodText;
    public Text waterText;
    public Text foodText;
    public Text nonRenewableText;
    public Text energyText;
    public Text populationText;
    public Text populationCapText;
    public Text ecologieText;

    

    // Start is called before the first frame update
    void Start()
    {
        woodBuildings = new List<GameObject>();
        waterBuildings = new List<GameObject>();
        foodBuildings = new List<GameObject>();
        nonRenewableBuildings = new List<GameObject>();
        energyBuildings = new List<GameObject>();
        housingBuildings = new List<GameObject>();
        expeditions = new List<GameObject>();
        specialBuildings = new List<GameObject>();
        planten = new List<GameObject>();
        greenHousing = new List<GameObject>();

        SetStartResources();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        HowManyBuildings();
        UpdateResources();

        woodText.text = " " + totalWoodAmount;
        waterText.text = " " + totalWaterProduction;
        foodText.text = " " + totalFoodAmount;
        nonRenewableText.text = " " + totalNonRenewableAmount;
        energyText.text = " " + totalEnergyProduction;
        populationText.text = " " + totalPopulationAmount;
        populationCapText.text = "/ " + totalPopulationCap;

    }

    void HowManyBuildings()
    {
        foreach (GameObject building in GameObject.FindGameObjectsWithTag("WoodBuilding"))
        {
            if(!woodBuildings.Contains(building))
            {
                woodBuildings.Add(building);
            }
        }
        foreach (GameObject building in GameObject.FindGameObjectsWithTag("WaterBuilding"))
        {
            if(!waterBuildings.Contains(building))
            {
                waterBuildings.Add(building);
            }
        }
        foreach (GameObject building in GameObject.FindGameObjectsWithTag("FoodBuilding"))
        {
            if(!foodBuildings.Contains(building))
            {
                foodBuildings.Add(building);
            }
        }
        foreach (GameObject building in GameObject.FindGameObjectsWithTag("NonRenewableBuilding"))
        {
            if(!nonRenewableBuildings.Contains(building))
            {
                nonRenewableBuildings.Add(building);
            }
        }
        foreach (GameObject building in GameObject.FindGameObjectsWithTag("Energy"))
        {
            if(!energyBuildings.Contains(building))
            {
                energyBuildings.Add(building);
            }
        }
        foreach (GameObject building in GameObject.FindGameObjectsWithTag("HousingBuilding"))
        {
            if(!housingBuildings.Contains(building))
            {
                housingBuildings.Add(building);
            }
        }
        foreach (GameObject building in GameObject.FindGameObjectsWithTag("Expedition"))
        {
            if(!expeditions.Contains(building))
            {
                expeditions.Add(building);
            }
        }
        foreach (GameObject building in GameObject.FindGameObjectsWithTag("SpecialBuilding"))
        {
            if(!specialBuildings.Contains(building))
            {
                specialBuildings.Add(building);
            }
        }
        foreach (GameObject building in GameObject.FindGameObjectsWithTag("GreenHousing"))
        {
            if(!greenHousing.Contains(building))
            {
                greenHousing.Add(building);
            }
        }
        foreach (GameObject building in GameObject.FindGameObjectsWithTag("Planten"))
        {
            if(!planten.Contains(building))
            {
                planten.Add(building);
            }
        }
    }

    void UpdateResources()
    {   
        if(timer >= 1f)
        {
            for(iWo = 0; iWo < woodBuildings.Count; iWo++)
            {
                totalWoodAmount += woodBuildings[iWo].GetComponent<WoodProduction>().amount;
                woodBuildings[iWo].GetComponent<WoodProduction>().amount = 0;
                totalWoodAmount -= woodBuildings[iWo].GetComponent<WoodProduction>().woodCostAmount;
                woodBuildings[iWo].GetComponent<WoodProduction>().woodCostAmount = 0;
                totalFoodAmount -= woodBuildings[iWo].GetComponent<WoodProduction>().foodCostAmount;
                woodBuildings[iWo].GetComponent<WoodProduction>().foodCostAmount = 0;
                totalNonRenewableAmount -= woodBuildings[iWo].GetComponent<WoodProduction>().nonrenewableCostAmount;
                woodBuildings[iWo].GetComponent<WoodProduction>().nonrenewableCostAmount = 0;
                totalWaterProduction -= woodBuildings[iWo].GetComponent<WoodProduction>().waterCostAmount;
                woodBuildings[iWo].GetComponent<WoodProduction>().waterCostAmount = 0;
                totalEnergyProduction -= woodBuildings[iWo].GetComponent<WoodProduction>().energyCostAmount;
                woodBuildings[iWo].GetComponent<WoodProduction>().energyCostAmount = 0;
            }
            for(iWa = 0; iWa < waterBuildings.Count; iWa++)
            {
                totalWaterProduction += waterBuildings[iWa].GetComponent<WaterProduction>().amount;
                waterBuildings[iWa].GetComponent<Production>().amount = 0;
                totalWoodAmount -= waterBuildings[iWa].GetComponent<WaterProduction>().woodCostAmount;
                waterBuildings[iWa].GetComponent<Production>().woodCostAmount = 0;
                totalFoodAmount -= waterBuildings[iWa].GetComponent<WaterProduction>().foodCostAmount;
                waterBuildings[iWa].GetComponent<Production>().foodCostAmount = 0;
                totalNonRenewableAmount -= waterBuildings[iWa].GetComponent<WaterProduction>().nonrenewableCostAmount;
                waterBuildings[iWa].GetComponent<Production>().nonrenewableCostAmount = 0;
                totalWaterProduction -= waterBuildings[iWa].GetComponent<WaterProduction>().waterCostAmount;
                waterBuildings[iWa].GetComponent<Production>().waterCostAmount = 0;
                totalEnergyProduction -= waterBuildings[iWa].GetComponent<WaterProduction>().energyCostAmount;
                waterBuildings[iWa].GetComponent<Production>().energyCostAmount = 0;
            }
            for(iF = 0; iF < foodBuildings.Count; iF++)
            {
                totalFoodAmount += foodBuildings[iF].GetComponent<FoodProduction>().amount;
                foodBuildings[iF].GetComponent<Production>().amount = 0;
                totalWoodAmount -= foodBuildings[iF].GetComponent<FoodProduction>().woodCostAmount;
                foodBuildings[iF].GetComponent<Production>().woodCostAmount = 0;
                totalFoodAmount -= foodBuildings[iF].GetComponent<FoodProduction>().foodCostAmount;
                foodBuildings[iF].GetComponent<Production>().foodCostAmount = 0;
                totalNonRenewableAmount -= foodBuildings[iF].GetComponent<FoodProduction>().nonrenewableCostAmount;
                foodBuildings[iF].GetComponent<Production>().nonrenewableCostAmount = 0;
                totalWaterProduction -= foodBuildings[iF].GetComponent<FoodProduction>().waterCostAmount;
                foodBuildings[iF].GetComponent<Production>().waterCostAmount = 0;
                totalEnergyProduction -= foodBuildings[iF].GetComponent<FoodProduction>().energyCostAmount;
                foodBuildings[iF].GetComponent<Production>().energyCostAmount = 0;
            }
            for(iE = 0; iE < energyBuildings.Count; iE++)
            {
                totalEnergyProduction += energyBuildings[iE].GetComponent<ElectricityProduction>().amount;
                energyBuildings[iE].GetComponent<ElectricityProduction>().amount = 0;
                totalWoodAmount -= energyBuildings[iE].GetComponent<ElectricityProduction>().woodCostAmount;
                energyBuildings[iE].GetComponent<ElectricityProduction>().woodCostAmount = 0;
                totalFoodAmount -= energyBuildings[iE].GetComponent<ElectricityProduction>().foodCostAmount;
                energyBuildings[iE].GetComponent<ElectricityProduction>().foodCostAmount = 0;
                totalNonRenewableAmount -= energyBuildings[iE].GetComponent<ElectricityProduction>().nonrenewableCostAmount;
                energyBuildings[iE].GetComponent<ElectricityProduction>().nonrenewableCostAmount = 0;
                totalWaterProduction -= energyBuildings[iE].GetComponent<ElectricityProduction>().waterCostAmount;
                energyBuildings[iE].GetComponent<ElectricityProduction>().waterCostAmount = 0;
                totalEnergyProduction -= energyBuildings[iE].GetComponent<ElectricityProduction>().energyCostAmount;
                energyBuildings[iE].GetComponent<ElectricityProduction>().energyCostAmount = 0;
            }
            for(iP = 0; iP < housingBuildings.Count; iP++)
            {
                totalPopulationAmount += housingBuildings[iP].GetComponent<PopulationProduction>().amount;
                housingBuildings[iP].GetComponent<PopulationProduction>().amount = 0;
                totalWoodAmount -= housingBuildings[iP].GetComponent<PopulationProduction>().woodCostAmount;
                housingBuildings[iWo].GetComponent<PopulationProduction>().woodCostAmount = 0;
                totalFoodAmount -= housingBuildings[iP].GetComponent<PopulationProduction>().foodCostAmount;
                housingBuildings[iWo].GetComponent<PopulationProduction>().foodCostAmount = 0;
                totalNonRenewableAmount -= housingBuildings[iP].GetComponent<PopulationProduction>().nonrenewableCostAmount;
                housingBuildings[iWo].GetComponent<PopulationProduction>().nonrenewableCostAmount = 0;
                totalWaterProduction -= housingBuildings[iP].GetComponent<PopulationProduction>().waterCostAmount;
                housingBuildings[iWo].GetComponent<PopulationProduction>().waterCostAmount = 0;
                totalEnergyProduction -= housingBuildings[iP].GetComponent<PopulationProduction>().energyCostAmount;
                housingBuildings[iWo].GetComponent<PopulationProduction>().energyCostAmount = 0;
                totalPopulationCap += housingBuildings[iP].GetComponent<PopulationProduction>().populationCapAmount;
                housingBuildings[iWo].GetComponent<PopulationProduction>().populationCapAmount = 0;
            }
            for(iNR = 0; iNR < nonRenewableBuildings.Count; iNR++)
            {
                totalNonRenewableAmount += nonRenewableBuildings[iNR].GetComponent<Expedition>().amount;
                nonRenewableBuildings[iNR].GetComponent<Expedition>().amount = 0;
                totalWoodAmount -= nonRenewableBuildings[iNR].GetComponent<Expedition>().woodCostAmount;
                nonRenewableBuildings[iNR].GetComponent<Expedition>().woodCostAmount = 0;
                totalFoodAmount -= nonRenewableBuildings[iNR].GetComponent<Expedition>().foodCostAmount;
                nonRenewableBuildings[iNR].GetComponent<Expedition>().foodCostAmount = 0;
                totalNonRenewableAmount -= nonRenewableBuildings[iNR].GetComponent<Expedition>().nonrenewableCostAmount;
                nonRenewableBuildings[iNR].GetComponent<Expedition>().nonrenewableCostAmount = 0;
                totalWaterProduction -= nonRenewableBuildings[iNR].GetComponent<Expedition>().waterCostAmount;
                nonRenewableBuildings[iNR].GetComponent<Expedition>().waterCostAmount = 0;
                totalEnergyProduction -= nonRenewableBuildings[iNR].GetComponent<Expedition>().energyCostAmount;
                nonRenewableBuildings[iNR].GetComponent<Expedition>().energyCostAmount = 0;
            }

            timer = 0;
        }
    }

    void SetStartResources()
    {
        totalWoodAmount += 500;
        totalFoodAmount += 500;
        totalNonRenewableAmount += 50;
        totalWaterProduction += 100;
        totalEnergyProduction += 100;
        totalPopulationAmount += 592;
        totalPopulationCap += 750;
    }
}
