using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.RegisterListener<BuildingSwapEvent>(OnBuildingSwap);
    }


    private void OnBuildingSwap(BuildingSwapEvent eve) {

        //instantiate or activate UI panel with swap information


        Debug.Log(eve.oldBuilding + " was swapped for: " + eve.newBuilding);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
