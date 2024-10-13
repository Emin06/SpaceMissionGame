using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceCraftController : MonoBehaviour
{
    public int SpaceCraftLaunchCost;

    public GameObject FailedTextPanel;

    public Database database;

    public bool demo;

    void Start()
    {
        demo = false;
        FailedTextPanel.SetActive(false);
    }

    void Update()
    {
        
    }

    public void LaunchSpaceCraft()
    {
        if (database.DiamondCount >= SpaceCraftLaunchCost)
        {
            if (demo == false)
            {
                SceneManager.LoadScene(3);
                demo = true;
            }
            
        }
        else
        {
            FailedTextPanel.SetActive(true);
        }
    }
}
