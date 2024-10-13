using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeController : MonoBehaviour
{

    public int CurrentTier;
    public int CostUpgradeTier;

    public GameObject FailedPanel;

    public TextMeshProUGUI CostUpgradeTierText;
    public TextMeshProUGUI FailedText;
    public TextMeshProUGUI CurrentTierText;

    public Database database;
    public MenuController menuController;


    void Start()
    {
        FailedPanel.SetActive(false);
        CostUpgradeTierText.text = "Maden Toplama Aracý Ücreti:" + CostUpgradeTier.ToString();
        CurrentTierText.text = "Level = " + CurrentTier.ToString();
    }

    void Update()
    {
        
    }

    public void IncreaseTier()
    {
        if (CostUpgradeTier <= database.UraniumCount)
        {
            FailedPanel.SetActive(false);
            database.UraniumCount -= CostUpgradeTier;
            CurrentTier++;
            CostUpgradeTier++;
            CostUpgradeTierText.text = "Maden Toplama Aracý Ücreti:" + CostUpgradeTier.ToString();
            CurrentTierText.text = "Level = " + CurrentTier.ToString();
            menuController.UraniumText.text = database.UraniumCount.ToString();
        }
        else
        {
            FailedPanel.SetActive(true);
            FailedText.text = "Uranyum sayýnýz yetersiz";
        }
        
    }
}
