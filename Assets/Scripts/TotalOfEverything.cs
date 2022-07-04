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
            for(iNR = 0; iNR < nonRenewableBuildings.Count; iNR++)
            {
                totalNonRenewableAmount += nonRenewableBuildings[iNR].GetComponent<Expedition>().amount;
                nonRenewableBuildings[iNR].GetComponent<Expedition>().amount = 0;
            }
            timer = 0;
        }
    }

    void Happiness()
    {
        happiness = (specialBuildings.Count * 20) / housingBuildings.Count / (ecologie * -1 / 100) * 100;
    }

    void Ecologie()
    {
        ecologie = ((greenHousings * 3) + plants / 10) / (housingBuildings.Count + energyBuildings.Count + foodBuildings.Count + waterBuildings.Count + woodBuildings.Count + nonRenewableBuildings.Count * 2) * 100;
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
