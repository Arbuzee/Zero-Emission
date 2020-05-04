using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMixManager : MonoBehaviour
{
    public VehicleMixManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.RegisterListener<BuildingSwapEvent>(OnBuildingSwap);
    }




    private void OnBuildingSwap(BuildingSwapEvent eve) { 
        
    }

}
