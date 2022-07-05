using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class WoodProduction : Production
{
    
    void Update()
    {
        timer += Time.deltaTime;
        CanProduce();
        Produce();
    }

    public override void Produce()
    {
        if(timer >= 1.1f)
        {
            if(canProduce)
            {
                amount += productionRate;
                totalAmounts.totalWaterProduction -= waterUsageCost;
            }
            timer = 0;
        }
    }

    public override void CanProduce()
    {
        if(totalAmounts.totalWaterProduction - waterUsageCost >= 0)
        {
            canProduce = true;
        }
        else
        {
            canProduce = false;
        }
    }

    public void RetractCosts()
    {
            woodCostAmount += woodBuildingCost;
            foodCostAmount += foodBuildingCost;
            nonrenewableCostAmount += nonRenewableBuildingCost;
            waterCostAmount += waterBuildingCost;
            energyCostAmount += electricityBuildingCost;
    }
}
