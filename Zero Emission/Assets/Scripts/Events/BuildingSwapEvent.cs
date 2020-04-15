using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSwapEvent : EventClass
{

    public GameObject oldBuilding;
    public GameObject newBuilding;

    public BuildingSwapEvent(string desc, GameObject oldB, GameObject newB) : base (desc) {
        oldBuilding = oldB;
        newBuilding = newB;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
