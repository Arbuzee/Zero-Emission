using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//class idea: "spawn" instance of objective one after one that references this, however keeps track of its own
// objectives and calls this to change text when updating/is finished.
public class ObjectivePrinter : MonoBehaviour
{

    private Text txt;
    private GameObject CurrentObjectiveObj;
    private Objective currentObjective;
    private int countDown;

    public static ObjectivePrinter Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        EventManager.Instance.RegisterListener<BuildingSwapEvent>(OnBuildingSwap);
        CurrentObjectiveObj = ObjectiveGenerator.Instance.CreateObjective();
        currentObjective = CurrentObjectiveObj.GetComponent<Objective>();
        PrintObjective();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void PrintObjective() {
        string questText = "";
        questText += currentObjective.description + " Type: " + currentObjective.typeToBuild + " Progress: " + countDown + "/" + currentObjective.count;
        gameObject.GetComponent<Text>().text = questText;
    }

    private void OnBuildingSwap(BuildingSwapEvent eve) {

        txt.text = "Building Swapped";
        //get wanted building
        string wantedBuilding = currentObjective.GetComponent<Objective>().typeToBuild;

        //do the current objective checks:
        if(eve.newBuilding.GetComponent<Building>().TypeOfBuilding.Equals(wantedBuilding)){ // find way to compare prefab types
            Debug.Log("Placed building matches current objective target");
            countDown --;
            PrintObjective(); // update quest text for player

            if (countDown <= 0) {
                Debug.Log("Objective finished!");
                gameObject.GetComponent<Text>().text = "Objective Finished!";
            }
        }
    }

    

}
