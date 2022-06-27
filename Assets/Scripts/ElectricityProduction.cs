using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ElectricityProduction : Production
{
    void Update()
    {
        timer += Time.deltaTime;
        CanProduce();
        Produce();
    }

    public override void Produce()
    {
        if(timer >= 0.9f)
        {
            amount += productionRate;
            timer = 0;
        }
    }

    public override void CanProduce()
    {
    }
}
