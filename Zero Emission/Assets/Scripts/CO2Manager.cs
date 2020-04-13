using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CO2Manager : MonoBehaviour
{
    private Image CO2Indicator;
    [SerializeField] private TextMeshProUGUI CO2PercentageText;

    private int co2Level = 100;

    public int CO2MaxLevel { get; set; }
    public int CO2Level { get => co2Level; set => co2Level = value; } //nessecary when UI gets own script and must access co2lvl.
    

    public static CO2Manager Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject); //only one may live
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CO2Indicator = GetComponent<Image>();
        CO2Indicator.type = Image.Type.Filled;
        CO2Indicator.fillMethod = Image.FillMethod.Vertical;
        CO2Indicator.fillAmount = 1f;
        EventManager.Instance.RegisterListener<CO2Change>(OnCO2Change);
    }

    public void Update()
    {
        //Just for testing
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("keypress");
            UpdateCo2Level(-5);
            FillCo2Indicator();
        }
    }

    /// <summary>
    /// Called when placeable object is dropped. Difference between values is calculated where swap occurs and is sent 
    /// to event as "CO2AdjustmentValue". On call, updates CO2level with new adjustment.
    /// </summary>
    /// <param name="ev"></param>
    public void OnCO2Change(CO2Change ev)
    {
        Debug.Log("building drop co2 value: " + ev.CO2AdjustmentValue);
        UpdateCo2Level(ev.CO2AdjustmentValue); // adjustment value gives a positive amount is new building swapped out a green one
        UpdateCo2PercentageText();
    }

    public void UpdateCo2Level(int value)
    {
        CO2Level = CO2Level + value;
        Debug.Log("updating CO2 level:" + CO2Level);

        FillCo2Indicator();
    }

    public void UpdateCo2PercentageText()
    {
        CO2PercentageText.text = "CO2: " + Mathf.Ceil(GetFillAmount() * 100) + "%";
    }

    private void FillCo2Indicator()
    {
        Debug.Log("filling co2 meter");
        CO2Indicator.fillAmount = GetFillAmount();
    }

    private float GetFillAmount()
    {
        float tempMax = (float)CO2MaxLevel;
        float tempCurrent = (float)CO2Level;
        return tempCurrent / tempMax;  // because fillAmount is range 0f - 1f
    }
    
    public void SetMaxCO2(int value) //only called at start from placementarea manager. 
    {
        CO2MaxLevel = value;
        CO2Level = CO2MaxLevel;
        Debug.Log("Max Co2 lvl is: " + CO2MaxLevel);
    }

}
