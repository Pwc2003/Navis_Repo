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
    [Header("Resources")]
    public float woodAmount = 0;
    public float waterAmount = 0;
    public float foodAmount = 0;
    public float nonRenewableAmount = 0;
    public float energyAmount = 0;

    private float timer = 0;

    [HideInInspector]public bool produced;
    private bool canProduce = true;

    //public fields but not visible in the inspector
    [HideInInspector]public string woodCounter;
    [HideInInspector]public string waterCounter;
    [HideInInspector]public string foodCounter;
    [HideInInspector]public string nonRenewableCounter;
    [HideInInspector]public string energyCounter;

    // Start is called before the first frame update
    void Start()
    {
        woodCounter = "Wood: " + woodAmount;
        waterCounter = "Water: " + waterAmount;
        foodCounter = "Food: " + foodAmount;
        nonRenewableCounter = "Non-renewable: " + nonRenewableAmount;
        energyCounter = "Energy: " + energyAmount;
    }

    // Update is called once per frame
    public void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1f && canProduce)
        {
            if(wood)
            {
                woodAmount += 1 * productionRate;
                produced = true;
            }
            else if(water)
            {
                waterAmount += 1 * productionRate;
                produced = true;
            }
            else if(food)
            {
                foodAmount += 1 * productionRate;
                produced = true;
            }
            else if(nonRenawable)
            {
                nonRenewableAmount += 1 * productionRate;
                produced = true;
            }
            else if(energy)
            {
                energyAmount += 1 * productionRate;
                produced = true;
            }
            if(produced == true)
            {
                timer = 0;
                produced = false;
            }
        }
    }
}
