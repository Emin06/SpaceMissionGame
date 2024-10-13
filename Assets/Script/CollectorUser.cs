using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorUser : MonoBehaviour
{

    public CollectorScriptable Collector;
    public CollectorController collectorController;

    public bool control;

    void Start()
    {
        control = true;
        collectorController.CurrentSecondPerCollectCrystalText.text = "Bu bina size saniyede " + Collector.CurrentUpgradeTier + " alüminyum kazandýrýr.";
    }

    void Update()
    {
        if (Collector.Active && control)
        {
            InvokeRepeating("IncreaseCollectCrystalCount", 0f, 1f);
            control = false;
        }
    }

    public void IncreaseCollectCrystalCount()
    {
        if (collectorController.CollectorInventoryMaxCount > Collector.InventoryCount)
        {
            Collector.InventoryCount += Collector.CurrentUpgradeTier;
        }

    }
}
