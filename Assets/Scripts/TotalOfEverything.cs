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
    
    private GameObject woodBuilding;
    private GameObject waterBuilding;
    private GameObject foodBuilding;
    private GameObject nonRenewableBuilding;
    private GameObject energyBuilding;
    
    private float totalWoodAmount = 0;
    private float totalWaterAmount = 0;
    private float totalFoodAmount = 0;
    private float totalNonRenewableAmount = 0;
    private float totalEnergyAmount = 0;

    private float timer = 0;
    private int iWo = 0;
    private int iWa = 0;
    private int iF = 0;

    public Text woodText;
    public Text waterText;
    public Text foodText;
    public Text nonRenewableText;
    public Text energyText;

    // Start is called before the first frame update
    void Start()
    {
        woodBuildings = new List<GameObject>();
        waterBuildings = new List<GameObject>();
        foodBuildings = new List<GameObject>();
        nonRenewableBuildings = new List<GameObject>();
        energyBuildings = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        HowManyBuildings();
        UpdateResources();

        woodText.text = "wood: " + totalWoodAmount;
        waterText.text = "water: " + totalWaterAmount;
        foodText.text = "food: " + totalFoodAmount;
        nonRenewableText.text = "nonrenewable: " + totalNonRenewableAmount;
        energyText.text = "energy: " + totalEnergyAmount;
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
    }

    void UpdateResources()
    {   
        if(timer >= 1f)
        {
            Debug.Log("Checking");
            for(iWo = 0; iWo < woodBuildings.Count; iWo++)
            {
                totalWoodAmount += woodBuildings[iWo].GetComponent<Production>().woodAmount;
                woodBuildings[iWo].GetComponent<Production>().woodAmount = 0;
            }
            for(iWa = 0; iWa < waterBuildings.Count; iWa++)
            {
                totalWaterAmount += waterBuildings[iWa].GetComponent<Production>().waterAmount;
                waterBuildings[iWa].GetComponent<Production>().waterAmount = 0;
            }
            for(iF = 0; iF < foodBuildings.Count; iF++)
            {
                totalFoodAmount += foodBuildings[iF].GetComponent<Production>().foodAmount;
                foodBuildings[iF].GetComponent<Production>().foodAmount = 0;
            }
            timer = 0;
        }
    }
}
