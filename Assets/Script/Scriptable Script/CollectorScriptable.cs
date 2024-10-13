using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Collector", menuName = "Collector")]
public class CollectorScriptable : ScriptableObject
{
    public int Number;
    public bool Active;
    public int InventoryCount;
    public int CurrentUpgradeTier;
}
