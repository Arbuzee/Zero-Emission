using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveGenerator : MonoBehaviour
{

    public GameObject currentObjective;
    public GameObject QuestObject;
    public string[] BuildingTypes;

    
    public static ObjectiveGenerator Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject); //only one may live
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //instantiate in game world so their own update/listen can do checks fow its own conditions? 
    public GameObject CreateObjective() {

        currentObjective = Instantiate(QuestObject);
        Objective data = GenerateObjectiveData();
        currentObjective.GetComponent<Objective>().typeToBuild = data.typeToBuild;
        currentObjective.GetComponent<Objective>().count = data.count;
        return currentObjective;
    }


    private Objective GenerateObjectiveData() {

        //generate random quest
        string type = GetRandomBuildingType();
        int count = Random.Range(1, 4);
        string description = "Build " + count + " " + type;
        return new Objective(description, type, count);
    }


    private string GetRandomBuildingType() {
        int randomizer = Random.Range(0, BuildingTypes.Length);
        string str = BuildingTypes[randomizer];
        return str;
    }

}
