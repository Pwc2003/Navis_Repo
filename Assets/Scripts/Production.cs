using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract class Production : MonoBehaviour
{

    [Header("Production rates per second")]
    [SerializeField] public float productionRate = 0;

    [HideInInspector]public float amount;

    //resources that it costs to produce 1 item
    [Header("Resources it costs per time it produces")]
    [SerializeField] protected float woodProductionCost = 0;
    [SerializeField] protected float waterProductionCost = 0;
    [SerializeField] protected float foodProductionCost = 0;
    [SerializeField] protected float nonRenewableProductionCost = 0;
    [SerializeField] protected float electricityProductionCost = 0;

    public GameObject canvas;
    protected TotalOfEverything totalAmounts;

    protected float timer = 0;

    [HideInInspector]public bool produced;
    protected bool canProduce = true;

    // Start is called before the first frame update
    void Start()
    {
        totalAmounts = canvas.GetComponent<TotalOfEverything>();
    }

    public virtual void Produce()
    {

    }

    public virtual void CanProduce()
    {
        
    }
}
