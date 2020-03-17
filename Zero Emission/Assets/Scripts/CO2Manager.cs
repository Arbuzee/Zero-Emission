using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CO2Manager : MonoBehaviour
{
    private Image CO2Indikator;

    private int co2Level = 100;
    private int co2Max = 100;
    public int CO2Level { get => co2Level; set => co2Level = value; }

    // Start is called before the first frame update
    void Start()
    {
        CO2Indikator = GetComponent<Image>();
        EventManager.Instance.RegisterListener<CO2Change>(OnCO2Change);
        co2Max = UpdateCo2Level(0); // beginning of game decides what co2 lvl is 100% of bar.
        CO2Level = co2Max;

        FillCo2Indicator();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("keypress");
            UpdateCo2Level(-5);
            FillCo2Indicator();
        }
    }

    public void OnCO2Change(CO2Change ev)
    {
        UpdateCo2Level(ev.CO2AdjustmentValue);
    }

    public int UpdateCo2Level(int value)
    {
        Debug.Log("updating CO2 level");
        int co2;
        //calc co2 level of town --> change this to re-calc the town emission? OR: CO2event holds difference between old building and new at swap.
        co2 = CO2Level + value;
        return co2;
    }

    private void FillCo2Indicator()
    {
        Debug.Log("filling co2 meter");
        CO2Indikator.fillAmount = GetFillAmount();
    }

    private int GetFillAmount()
    {
        return co2Level / co2Max;
    }
    
}
