﻿using System.Collections;
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
    private int progressCount;
    private AudioSource audioSource;

    [SerializeField] private AudioClip successSound;


    public static ObjectivePrinter Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        txt = gameObject.GetComponent<Text>();
        EventManager.Instance.RegisterListener<BuildingSwapEvent>(OnBuildingSwap);
        /*
        CurrentObjectiveObj = ObjectiveGenerator.Instance.CreateObjective();
        currentObjective = CurrentObjectiveObj.GetComponent<Objective>();
        progressCount = 0;
        */
        NewObjective();
        PrintObjective();
    }


    private void PrintObjective() {
        string questText = "";
        questText += currentObjective.description + " Type: " + currentObjective.typeToBuild + " Progress: " + progressCount + "/" + currentObjective.count;
        gameObject.GetComponent<Text>().text = questText;
    }


    private void NewObjective(){
        CurrentObjectiveObj = ObjectiveGenerator.Instance.CreateObjective();
        currentObjective = CurrentObjectiveObj.GetComponent<Objective>();
        progressCount = 0;
    }

    private void ObjectiveSuccess() {
        Debug.Log("Objective finished!");
        audioSource.PlayOneShot(successSound);
        string description = currentObjective.description + "You placed " + progressCount + "/" + currentObjective.count + " buildings of type: " + currentObjective.typeToBuild + ", Good job!";
        PopUpManager.Instance.ShowPopupWindow("Objective finished", description, 5.0f, Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10f)));
        gameObject.GetComponent<Text>().text = "Objective Finished!";
        NewObjective();
        PrintObjective();
    }

    private void OnBuildingSwap(BuildingSwapEvent eve) {

        //get wanted building
        string wantedBuilding = currentObjective.GetComponent<Objective>().typeToBuild;

        //do the current objective checks:
        if(eve.newBuilding.GetComponent<Building>().TypeOfBuilding.Equals(wantedBuilding)){ // find way to compare prefab types
            Debug.Log("Placed building matches current objective target");
            progressCount ++;
            PrintObjective(); // update quest text for player

            if (progressCount == currentObjective.count) {
                ObjectiveSuccess();
            }
        }
    }

    

}
