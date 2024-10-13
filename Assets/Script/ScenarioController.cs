using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenarioController : MonoBehaviour
{
    public GameObject Image0;
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;

    public bool ScenerioCompleted;

    // Start is called before the first frame update
    void Start()
    {
        ScenerioCompleted = false;
        Image0.SetActive(true);
        Image1.SetActive(false);
        Image2.SetActive(false);
        Image3.SetActive(false);
        Image4.SetActive(false);
        StartCoroutine(Scenario1(3f));
    }

    // Update is called once per frame
    void Update()
    {
        if (ScenerioCompleted == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    IEnumerator Scenario1(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Image0.SetActive(false);
        Image1.SetActive(true);
        StartCoroutine(Scenario2(3f));
    }
    IEnumerator Scenario2(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Image1.SetActive(false);
        Image2.SetActive(true);
        StartCoroutine(Scenario3(6f));
    }
    IEnumerator Scenario3(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Image2.SetActive(false);
        Image3.SetActive(true); 
        StartCoroutine(Scenario4(3f));
    }
    IEnumerator Scenario4(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Image3.SetActive(false);
        Image4.SetActive(true);
        ScenerioCompleted = true;
    }
}
