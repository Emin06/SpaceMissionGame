using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject GamePanel;
    public GameObject CroosHair;
    public GameObject PausePanel;
    public GameObject SettingsPanel;
    public GameObject InfoPanel;
    public GameObject InfoPanel1;
    public GameObject InfoPanel2;
    public GameObject InfoPanel3;
    public GameObject InfoPanel4;
    public GameObject InfoPanel5;

    public bool InventoryVisible;
    public bool PauseGame;

    public int amount;

    public TextMeshProUGUI AluminumText;
    public TextMeshProUGUI DiamondText;
    public TextMeshProUGUI UraniumText;

    public FirstPersonLook firstPersonLook;
    public Database database;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        firstPersonLook.enabled = false;
        amount = 1;
        InfoPanel.SetActive(true);
        InfoPanel1.SetActive(false);
        InfoPanel2.SetActive(false);
        InfoPanel3.SetActive(false);
        InfoPanel4.SetActive(false);
        InfoPanel5.SetActive(false);
        GamePanel.SetActive(false);
        CroosHair.SetActive(false);
        Inventory.SetActive(false);
        PausePanel.SetActive(false);
        SettingsPanel.SetActive(false);
        InventoryVisible = false;
        PauseGame = false;


        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryVisible = !InventoryVisible;
            if (InventoryVisible == true && Time.timeScale == 1)
            {
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                AluminumText.text = database.AluminumCount.ToString();
                DiamondText.text = database.DiamondCount.ToString();
                UraniumText.text = database.UraniumCount.ToString();
                GamePanel.SetActive(false);
                CroosHair.SetActive(false);
                Inventory.SetActive(InventoryVisible);
                firstPersonLook.enabled = !InventoryVisible;
            }
            else if(InventoryVisible == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
                CroosHair.SetActive(true);
                Inventory.SetActive(InventoryVisible);
                firstPersonLook.enabled = !InventoryVisible;
            }
            
            
            
            
        }
    }

    public void NextInfo()
    {
        if (amount == 1)
        {
            InfoPanel.SetActive(false);
            InfoPanel1.SetActive(true);
            amount++;
        }
        else if (amount == 2)
        {
            InfoPanel1.SetActive(false);
            InfoPanel2.SetActive(true);
            amount++;
        }
        else if (amount == 3)
        {
            InfoPanel2.SetActive(false);
            InfoPanel3.SetActive(true);
            amount++;
        }
        else if (amount == 4)
        {
            InfoPanel3.SetActive(false);
            InfoPanel4.SetActive(true);
            amount++;
        }
        else if (amount == 5)
        {
            InfoPanel4.SetActive(false);
            InfoPanel5.SetActive(true);
            amount++;
        }
        else if (amount == 6)
        {
            InfoPanel5.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            firstPersonLook.enabled = true;
            CroosHair.SetActive(true);
        }
    }

    public void PauseGamePanelOn()
    {
        PauseGame = true;
        PausePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        firstPersonLook.enabled = false;
    }

    public void PauseGamePanelOff()
    {
        PauseGame = false;
        PausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        firstPersonLook.enabled = true;
    }

    public void SettingsPanelOn()
    {
        PausePanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void SettingsPanelOff()
    {
        PausePanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
