using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectorController : MonoBehaviour
{

    public GameObject CollectorActivatePanel;
    public GameObject CollectorPanel;
    public GameObject CollectorHitPanel;
    public GameObject FailedPanelUpgrade;
    public GameObject FailedPanelActivate;

    public GameObject SpaceCraftActivatePanel;

    public int CollectorActivateCost;
    public int CollectorUpgradeCost;
    public int CurrentUpgradeLevel;
    public int CollectorInventoryMaxCount;

    public TextMeshProUGUI FailedTextActivate;
    public TextMeshProUGUI FailedTextUpgrade;
    public TextMeshProUGUI CurrentSecondPerCollectCrystalText;
    public TextMeshProUGUI CollectorInventoryCountText;
    public TextMeshProUGUI CollectorNumberText;
    public TextMeshProUGUI CollectorUpgradeTierText;

    public RaycastHit CurrentHit;

    public FirstPersonLook firstPersonLook;
    public Database database;
    public MenuController menuController;

    void Start()
    {
        FailedPanelUpgrade.SetActive(false);
        FailedPanelActivate.SetActive(false);
        CollectorActivatePanel.SetActive(false);
        CollectorPanel.SetActive(false);
        CollectorHitPanel.SetActive(false);
        SpaceCraftActivatePanel.SetActive(false);
        CollectorUpgradeTierText.text = "Level = " + CurrentUpgradeLevel;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                BackGame();
            }
            else
            {
                menuController.PauseGamePanelOn();
            }
            
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2))
        {
            if (hit.collider.CompareTag("Collector") && Time.timeScale == 1)
            {
                CurrentHit = hit;
                CollectorHitPanel.SetActive(true);
                if (Input.GetMouseButtonUp(0))
                {
                    
                    firstPersonLook.enabled = false;
                    CollectorHitPanel.SetActive(false);
                    if (CurrentHit.collider.gameObject.GetComponent<CollectorUser>().Collector.Active && Time.timeScale == 1)
                    {
                        CollectorPanel.SetActive(true);
                        CollectorUpgradeTierText.text = "Level = " + CurrentHit.collider.gameObject.GetComponent<CollectorUser>().Collector.CurrentUpgradeTier;
                        CurrentSecondPerCollectCrystalText.text = "Bu bina size saniyede " + CurrentHit.collider.gameObject.GetComponent<CollectorUser>().Collector.CurrentUpgradeTier + " alüminyum kazandýrýr.";
                        CollectorInventoryCountText.text = CurrentHit.collider.gameObject.GetComponent<CollectorUser>().Collector.InventoryCount.ToString();
                        Cursor.lockState = CursorLockMode.None;
                        Time.timeScale = 0f;
                    }
                    else if (!CurrentHit.collider.gameObject.GetComponent<CollectorUser>().Collector.Active && Time.timeScale == 1)
                    {
                        CollectorActivatePanel.gameObject.SetActive(true);
                        CollectorUpgradeTierText.text = "Level = " + CurrentHit.collider.gameObject.GetComponent<CollectorUser>().Collector.CurrentUpgradeTier;
                        CurrentSecondPerCollectCrystalText.text = "Bu bina size saniyede " + CurrentHit.collider.gameObject.GetComponent<CollectorUser>().Collector.CurrentUpgradeTier + " alüminyum kazandýrýr.";
                        CollectorNumberText.text = "Toplayýcý " + CurrentHit.collider.gameObject.GetComponent<CollectorUser>().Collector.Number.ToString();
                        Cursor.lockState = CursorLockMode.None;
                        Time.timeScale = 0f;
                    }
                    
                }
                
            }
            else if(hit.collider.CompareTag("SpaceCraft") && Time.timeScale == 1)
            {
                CollectorHitPanel.SetActive(true);
                if (Input.GetMouseButtonUp(0))
                {
                    SpaceCraftActivatePanel.SetActive(true);
                    firstPersonLook.enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                    Time.timeScale = 0f;
                    CollectorHitPanel.SetActive(false);
                }
            }
        }
        else
        {
            CollectorHitPanel.SetActive(false);
        }
    }

    public void CollectorActivate()
    {
        if (database.AluminumCount >= CollectorActivateCost)
        {
            database.AluminumCount -= CollectorActivateCost;
            CurrentHit.collider.gameObject.GetComponent<CollectorUser>().Collector.Active = true;
            CollectorActivatePanel.SetActive(false);
            CollectorPanel.SetActive(true);
            FailedPanelActivate.SetActive(false);
        }
        else
        {
            FailedTextActivate.text = "Alüminyum sayýsý yetersiz.";
            FailedPanelActivate.SetActive(true);
        }
        
    }

    public void CollectorUpgrade()
    {
        if (CollectorUpgradeCost <= database.UraniumCount)
        {
            database.UraniumCount -= CollectorUpgradeCost;
            CurrentHit.collider.gameObject.GetComponent<CollectorUser>().Collector.CurrentUpgradeTier++;
            CollectorUpgradeTierText.text = "Level = " + CurrentHit.collider.gameObject.GetComponent<CollectorUser>().Collector.CurrentUpgradeTier;
            CurrentSecondPerCollectCrystalText.text = "Bu bina size saniyede " + CurrentHit.collider.gameObject.GetComponent<CollectorUser>().Collector.CurrentUpgradeTier + " alüminyum kazandýrýr.";
            FailedPanelUpgrade.SetActive(false);
        }
        else
        {
            FailedTextUpgrade.text = "Uranyum sayýsý yetersiz.";
            FailedPanelUpgrade.SetActive(true);
        }

    }

    public void CollectCollectorInventory()
    {
        database.DiamondCount += CurrentHit.collider.gameObject.GetComponent<CollectorUser>().Collector.InventoryCount;
        CurrentHit.collider.gameObject.GetComponent<CollectorUser>().Collector.InventoryCount = 0;
        CollectorInventoryCountText.text = CurrentHit.collider.gameObject.GetComponent<CollectorUser>().Collector.InventoryCount.ToString();
    }

    public void BackGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        menuController.CroosHair.SetActive(true);
        firstPersonLook.enabled = true;
        CollectorActivatePanel.SetActive(false);
        CollectorPanel.SetActive(false);
        CollectorHitPanel.SetActive(false);
        SpaceCraftActivatePanel.SetActive(false);
        menuController.PausePanel.SetActive(false);
        menuController.PauseGame = false;
        menuController.Inventory.SetActive(false);
    }
}
