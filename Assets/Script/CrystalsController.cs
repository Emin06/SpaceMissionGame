using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrystalsController : MonoBehaviour
{

    public Crystals crystals;

    public string Name;
    public float Health;

    void Start()
    {
        Name = crystals.Name;
        Health = crystals.Health;
    }
}
