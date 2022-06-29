using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class FoodProduction : Production
{
    void Update()
    {
        Debug.Log(canProduce);
        timer += Time.deltaTime;
        CanProduce();
        Produce();
    }

    public override void Produce()
    {
        if(timer >= 1.2f)
        {
            if(canProduce)
            {
                amount += productionRate;
                totalAmounts.totalWaterProduction -= waterUsageCost;
                totalAmounts.totalEnergyProduction -= electricityUsageCost;
            }
            timer = 0;
        }
    }

    public override void CanProduce()
    {
        if(totalAmounts.totalWaterProduction - waterUsageCost >= 0 && totalAmounts.totalEnergyProduction - electricityUsageCost >= 0)
        {
            canProduce = true;
        }
        else
        {
            canProduce = false;
        }
    }
}
