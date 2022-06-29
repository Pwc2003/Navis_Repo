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
    
    private GameObject woodBuilding;
    private GameObject waterBuilding;
    private GameObject foodBuilding;
    private GameObject nonRenewableBuilding;
    private GameObject energyBuilding;
    private GameObject housingBuilding;
    
    [HideInInspector]public float totalWoodAmount = 0;
    [HideInInspector]public float totalWaterProduction = 0;
    [HideInInspector]public float totalFoodAmount = 0;
    [HideInInspector]public float totalNonRenewableAmount = 0;
    [HideInInspector]public float totalEnergyProduction = 0;
    [HideInInspector]public float totalPopulationAmount = 0;


    private float timer = 0;
    private int iWo = 0;
    private int iWa = 0;
    private int iF = 0;
    private int iE = 0;
    private int iNR = 0;
    private int iP = 0;

    public Text woodText;
    public Text waterText;
    public Text foodText;
    public Text nonRenewableText;
    public Text energyText;
    public Text populationText;

    // Start is called before the first frame update
    void Start()
    {
        woodBuildings = new List<GameObject>();
        waterBuildings = new List<GameObject>();
        foodBuildings = new List<GameObject>();
        nonRenewableBuildings = new List<GameObject>();
        energyBuildings = new List<GameObject>();
        housingBuildings = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        HowManyBuildings();
        UpdateResources();

        woodText.text = "wood: " + totalWoodAmount;
        waterText.text = "water: " + totalWaterProduction;
        foodText.text = "food: " + totalFoodAmount;
        nonRenewableText.text = "nonrenewable: " + totalNonRenewableAmount;
        energyText.text = "energy: " + totalEnergyProduction;
        populationText.text = "population: " + totalPopulationAmount;
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
    }

    void UpdateResources()
    {   
        if(timer >= 1f)
        {
            for(iWo = 0; iWo < woodBuildings.Count; iWo++)
            {
                totalWoodAmount += woodBuildings[iWo].GetComponent<WoodProduction>().amount;
                woodBuildings[iWo].GetComponent<WoodProduction>().amount = 0;
            }
            for(iWa = 0; iWa < waterBuildings.Count; iWa++)
            {
                totalWaterProduction += waterBuildings[iWa].GetComponent<WaterProduction>().amount;
                waterBuildings[iWa].GetComponent<Production>().amount = 0;
            }
            for(iF = 0; iF < foodBuildings.Count; iF++)
            {
                totalFoodAmount += foodBuildings[iF].GetComponent<FoodProduction>().amount;
                foodBuildings[iF].GetComponent<Production>().amount = 0;
            }
            for(iE = 0; iE < energyBuildings.Count; iE++)
            {
                totalEnergyProduction += energyBuildings[iE].GetComponent<ElectricityProduction>().amount;
                energyBuildings[iE].GetComponent<ElectricityProduction>().amount = 0;
            }
            for(iP = 0; iP < housingBuildings.Count; iP++)
            {
                totalPopulationAmount += housingBuildings[iP].GetComponent<PopulationProduction>().amount;
                housingBuildings[iP].GetComponent<PopulationProduction>().amount = 0;
            }
            timer = 0;
        }
    }
}
