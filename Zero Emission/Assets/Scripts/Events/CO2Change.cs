using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CO2Change : EventClass
{
    public GameObject Object;
    public int CO2AdjustmentValue;

    public CO2Change(string description, GameObject Object, int CO2AdjustmentValue) : base(description)
    {
        this.Object = Object;
        this.CO2AdjustmentValue = CO2AdjustmentValue;
    }

}
