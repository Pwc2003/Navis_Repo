using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ElectricityUsage : Production
{

    void Update()
    {
        timer += Time.deltaTime;
        Use();
    }

    void Use()
    {
        if (timer >= 1f)
        {
            totalAmounts.totalEnergyProduction -= electricityUsageCost;
            timer = 0;
        }
    }
}
