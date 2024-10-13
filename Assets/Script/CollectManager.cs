using UnityEngine;
using UnityEngine.UI;

public class CollectManager : MonoBehaviour
{
    public Slider HealthSlider;
    public GameObject CrystalsUIPanel;

    public float MaxHealth = 100f;

    public AudioSource BreakSfx;

    public RaycastHit CurrentHit;

    public Database database;
    public UpgradeController upgradeController;

    public void Start()
    {
        CrystalsUIPanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2))
        {
            if (hit.collider.CompareTag("Uranium") && Time.timeScale == 1)
            {
                CrystalsUIPanel.gameObject.SetActive(true);
                CurrentHit = hit;
                UpdateHealthBar();
                if (Input.GetMouseButtonUp(0))
                {
                    DecreaseHealth(10);
                    IncreaseCount(1, 2);
                }
            }
            else if (hit.collider.CompareTag("Diamond") && Time.timeScale == 1)
            {
                CrystalsUIPanel.gameObject.SetActive(true);
                CurrentHit = hit;
                UpdateHealthBar();
                if (Input.GetMouseButtonUp(0))
                {
                    DecreaseHealth(10);
                    IncreaseCount(1, 1);
                }
            }
            else if (hit.collider.CompareTag("Aluminum") && Time.timeScale == 1)
            {
                CrystalsUIPanel.gameObject.SetActive(true);
                CurrentHit = hit;
                UpdateHealthBar();
                if (Input.GetMouseButtonUp(0))
                {
                    DecreaseHealth(10);
                    IncreaseCount(1, 0);
                }
            }
            
        }
        else
        {
            CrystalsUIPanel.gameObject.SetActive(false);
        }
    }

    public void UpdateHealthBar()
    {
        
        float normalizedHealth = CurrentHit.collider.gameObject.GetComponent<CrystalsController>().Health / MaxHealth;
        HealthSlider.value = normalizedHealth;
    }

    public void DecreaseHealth(float amount)
    {
        CurrentHit.collider.gameObject.GetComponent<CrystalsController>().Health -= amount;
        if (CurrentHit.collider.gameObject.GetComponent<CrystalsController>().Health <= 0)
        {
            CurrentHit.collider.gameObject.GetComponent<CrystalsController>().Health = 0;
            Destroy(CurrentHit.collider.gameObject); 
        }
        UpdateHealthBar();
    }

    public void IncreaseCount(int amount,int number)
    {
        BreakSfx.Play();
        amount = upgradeController.CurrentTier * amount;

        if (number == 0)
        {
            database.AluminumCount += amount;
        }
        else if (number == 1)
        {
            database.DiamondCount += amount;
        }
        else if (number == 2)
        {
            database.UraniumCount += amount;
        }
    }

    public void DecreaseCount(int amount)
    {

    }
}
