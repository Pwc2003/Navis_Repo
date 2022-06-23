using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class WaterProduction : Production
{
    
    void Update()
    {
        timer += Time.deltaTime;
        CanProduce();
        Produce();
    }

    public override void Produce()
    {
        if(timer >= 1f)
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
        if(totalAmounts.totalWaterAmount - electricityProductionCost >= 0)
        {
            canProduce = true;
        }
        else
        {
            canProduce = false;
        }
    }
}
