using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GODFUCKINGDAMNIT : MonoBehaviour
{
    private List<GameObject> buildings;
    private GameObject building;
    
    private float totalWoodAmount = 0;
    private float totalWaterAmount = 0;
    private float totalFoodAmount = 0;
    private float totalNonRenewableAmount = 0;
    private float totalEnergyAmount = 0;

    private float timer = 0;

    public Text woodText;
    public Text waterText;
    public Text foodText;
    public Text nonRenewableText;
    public Text energyText;

    // Start is called before the first frame update
    void Start()
    {
        buildings = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        building = GameObject.FindWithTag("ProductionBuilding");
        buildings.Add(building);

        foreach(GameObject b in buildings)
        {
            if(timer >= 1)
            {
                totalWoodAmount += b.GetComponent<Production>().woodAmount;
                b.GetComponent<Production>().woodAmount = 0;
                totalWaterAmount += b.GetComponent<Production>().waterAmount;
                b.GetComponent<Production>().waterAmount = 0;
                totalFoodAmount += b.GetComponent<Production>().foodAmount;
                b.GetComponent<Production>().foodAmount = 0;
                totalNonRenewableAmount += b.GetComponent<Production>().nonRenewableAmount;
                b.GetComponent<Production>().nonRenewableAmount = 0;
                totalEnergyAmount += b.GetComponent<Production>().energyAmount;
                b.GetComponent<Production>().energyAmount = 0;
                timer = 0;
            }
        }
        woodText.text = "Wood: " + totalWoodAmount;
        waterText.text = "Water: " + totalWaterAmount;
        foodText.text = "Food: " + totalFoodAmount;
        nonRenewableText.text = "Non-renewable: " + totalNonRenewableAmount;
        energyText.text = "Energy: " + totalEnergyAmount;
    }
}
