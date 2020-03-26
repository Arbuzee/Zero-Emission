using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CO2Manager : MonoBehaviour
{
    private Image CO2Indikator;

    private int co2Level = 100;
    private int co2MaxLevel = 100; // needs to be calculated at start based on all buildings on placeable areas
    public int CO2Level { get => co2Level; set => co2Level = value; } //nessecary when UI gets own script and must access co2lvl.

    private CO2Manager instance;
    public CO2Manager Instance { get => instance; set => instance = value; }

    // Start is called before the first frame update
    void Start()
    {
        CO2Indikator = GetComponent<Image>();
        CO2Indikator.type = Image.Type.Filled;
        CO2Indikator.fillMethod = Image.FillMethod.Vertical;
        CO2Indikator.fillAmount = 1f;
        EventManager.Instance.RegisterListener<CO2Change>(OnCO2Change);
        CO2Level = 50; //50 if we want starting values to be a medium thing, 100 if we want players to never exceed starting co2lvl.
        FillCo2Indicator();
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
    }

    public void UpdateCo2Level(int value)
    {
        CO2Level = CO2Level + value;
        Debug.Log("updating CO2 level:" + CO2Level);

        FillCo2Indicator();
    }

    private void FillCo2Indicator()
    {
        Debug.Log("filling co2 meter");
        CO2Indikator.fillAmount = GetFillAmount();
    }

    private float GetFillAmount()
    {
        return CO2Level / 100f;  // because fillAmount is range 0f - 1f
    }
    
}
