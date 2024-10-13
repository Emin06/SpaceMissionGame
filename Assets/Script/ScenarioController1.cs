using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenarioController1 : MonoBehaviour
{
    public GameObject Image0;
    public GameObject Image1;
    public GameObject Image2;

    public float time;

    public bool Demo2;
    public bool Demo4;

    void Awake()
    {
        Image0.SetActive(true);
        Image1.SetActive(false);
        Image2.SetActive(false);
        Time.timeScale = 1f;

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void FixedUpdate()
    {
        Time.timeScale = 1f;
        time += Time.deltaTime;
        if (time >= 2 && !Demo2)
        {
            Image0.SetActive(false);
            Image1.SetActive(true);
            Demo2 = true;
        }
        if (time >= 4 && !Demo4)
        {
            Image1.SetActive(false);
            Image2.SetActive(true);
            Demo4 = true;
        }
    }

}
