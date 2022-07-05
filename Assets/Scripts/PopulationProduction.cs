using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PopulationProduction : Production
{

    void Update()
    {
        timer += Time.deltaTime;
        CanProduce();
        Produce();
    }

    public override void Produce()
    {
        if(timer >= 10f)
        {
            if(canProduce)
            {
                amount += productionRate;
            }
            timer = 0;
        }
    }

    public override void CanProduce()
    {
        if (totalAmounts.totalPopulationAmount < totalAmounts.totalPopulationCap)
        {
            canProduce = true;
            
        }
        else
        {
            canProduce = false;
            totalAmounts.totalPopulationAmount = totalAmounts.totalPopulationCap;
        }
    }

    public void RetractCosts()
    {
        woodCostAmount += woodBuildingCost;
        foodCostAmount += foodBuildingCost;
        nonrenewableCostAmount += nonRenewableBuildingCost;
        waterCostAmount += waterBuildingCost;
        energyCostAmount += electricityBuildingCost;
        populationCapAmount += capIncrease;
    }
}
