using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveGenerator : MonoBehaviour
{

    public GameObject currentObjective;
    public GameObject QuestObject;
    
    public static ObjectiveGenerator Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        CreateObjective();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //instantiate in game world so their own update/listen can do checks fow its own conditions? 
    public GameObject CreateObjective() {

        currentObjective = Instantiate(QuestObject);
        //currentObjective.GetComponent<Objective>() = GenerateObjectiveData();
        return currentObjective;
    }


    private Objective GenerateObjectiveData() {

        string description = "add one windturbine";
        string type = "WindTurbine";
        int count = 1;
        
        return new Objective(description, type, count);
    }

}
