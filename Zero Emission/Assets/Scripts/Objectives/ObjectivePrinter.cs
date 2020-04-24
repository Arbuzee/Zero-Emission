using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//class idea: "spawn" instance of objective one after one that references this, however keeps track of its own
// objectives and calls this to change text when updating/is finished.
public class ObjectivePrinter : MonoBehaviour
{

    private Text txt;
    private Objective currentObjective;

    public static ObjectivePrinter Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        EventManager.Instance.RegisterListener<BuildingSwapEvent>(OnBuildingSwap);
        ObjectiveGenerator.Instance.CreateObjective();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBuildingSwap(BuildingSwapEvent eve) {

        txt.text = "Building Swapped";

        //do the current objective checks:
        if(eve.newBuilding.GetComponent<Building>().TypeOfBuilding.Equals("WindTurbine")){ // find way to compare prefab types
            Debug.Log
        }
    }

    

}
