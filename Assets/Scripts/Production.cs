using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Production : MonoBehaviour
{
    //Serialized fields
    [Header("Type of resources")]
    [SerializeField] bool wood = false;
    [SerializeField] bool water = false;
    [SerializeField] bool food = false;
    [SerializeField] bool nonRenawable = false;
    [SerializeField] bool energy = false;

    [Header("Production rates per second")]
    [SerializeField] float productionRate = 0;

    //resources that it costs to produce 1 item
    [Header("Resources it costs per time it produces")]
    [SerializeField] float woodProductionCost = 0;
    [SerializeField] float waterProductionCost = 0;
    [SerializeField] float foodProductionCost = 0;
    [SerializeField] float nonRenewableProductionCost = 0;
    [SerializeField] float energyProductionCost = 0;

    [Header("Counters")]
    public Text woodText;
    public Text waterText;
    public Text foodText;
    public Text nonRenewableText;
    public Text energyText;

    //private fields
    private float woodAmount = 0;
    private float waterAmount = 0;
    private float foodAmount = 0;
    private float nonRenawableAmount = 0;
    private float energyAmount = 0;

    private float timer = 0;

    private bool produced;
    private bool canProduce = true;

    //public fields but not visible in the inspector
    [HideInInspector]public string woodCounter;
    [HideInInspector]public string waterCounter;
    [HideInInspector]public string foodCounter;
    [HideInInspector]public string nonRenawableCounter;
    [HideInInspector]public string energyCounter;

    // Start is called before the first frame update
    void Start()
    {
        woodCounter = "Wood: " + woodAmount;
        waterCounter = "Water: " + waterAmount;
        foodCounter = "Food: " + foodAmount;
        nonRenawableCounter = "Non-renewable: " + nonRenawableAmount;
        energyCounter = "Energy: " + energyAmount;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1f && canProduce)
        {
            if(wood)
            {
                woodAmount += 1 * productionRate;
                woodCounter = "Wood: " + woodAmount;
                woodText.text = woodCounter;
                produced = true;
            }
            else if(water)
            {
                waterAmount += 1 * productionRate;
                waterCounter = "Water: " + waterAmount;
                waterText.text = waterCounter;
                produced = true;
            }
            else if(food)
            {
                foodAmount += 1 * productionRate;
                foodCounter = "Food: " + foodAmount;
                foodText.text = foodCounter;
                produced = true;
            }
            else if(nonRenawable)
            {
                nonRenawableAmount += 1 * productionRate;
                nonRenawableCounter = "Non-renewable: " + nonRenawableAmount;
                nonRenewableText.text = nonRenawableCounter;
                produced = true;
            }
            else if(energy)
            {
                energyAmount += 1 * productionRate;
                energyCounter = "Energy: " + energyAmount;
                energyText.text = energyCounter;
                produced = true;
            }
            if(produced == true)
            {
                timer = 0;

                woodAmount -= woodProductionCost;
                waterAmount -= waterProductionCost;
                foodAmount -= foodProductionCost;
                nonRenawableAmount -= nonRenewableProductionCost;
                energyAmount -= energyProductionCost;

                if(woodAmount < 0)
                {
                    canProduce = false;
                }
                else if(waterAmount < 0)
                {
                    canProduce = false;
                }
                else if(foodAmount < 0)
                {
                    canProduce = false;
                }
                else if(nonRenawableAmount < 0)
                {
                    canProduce = false;
                }
                else if(energyAmount < 0)
                {
                    canProduce = false;
                }

                produced = false;
            }
        }
    }
}
