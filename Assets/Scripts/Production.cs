using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract class Production : MonoBehaviour
{

    [Header("Production rates per second")]
    [SerializeField] protected float productionRate = 0;
    [SerializeField] protected float productGain = 0;

    [HideInInspector] public string tagName;

    [HideInInspector]public float amount;
    [HideInInspector]public float happiness;
    [HideInInspector]public float ecologie;
    //resources that it costs to produce 1 item
    [Header("Resources it costs per time it produces")]
    [SerializeField] protected float woodProductionCost = 0;
    [SerializeField] protected float foodProductionCost = 0;
    [SerializeField] protected float nonRenewableProductionCost = 0;
    [SerializeField] protected float populationProductionCost = 0;
    [Header("Resources it costs over time to maintain building")]
    [SerializeField] protected float electricityUsageCost = 0;
    [SerializeField] protected float waterUsageCost = 0;
    [SerializeField] protected float foodUsageCost = 0;
    [SerializeField] protected float populationUsageCost = 0;

    public GameObject canvas;
    protected TotalOfEverything totalAmounts;

    protected float timer = 0;

    [HideInInspector]public bool produced;
    protected bool canProduce = true;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("HUD");
        totalAmounts = canvas.GetComponent<TotalOfEverything>();
    }

    public virtual void Produce()
    {

    }

    public virtual void CanProduce()
    {
        
    }
}
