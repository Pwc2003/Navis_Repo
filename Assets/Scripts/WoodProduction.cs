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
                totalAmounts.totalWaterAmount -= waterProductionCost;
            }
            timer = 0;
        }
    }

    public override void CanProduce()
    {
        if(totalAmounts.totalWaterAmount - waterProductionCost >= 0)
        {
            canProduce = true;
        }
        else
        {
            canProduce = false;
        }
    }
}
