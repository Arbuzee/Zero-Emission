using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject vehiclePrefab;
    [SerializeField] private GameObject bikePrefab;
    [SerializeField] private int maxVehicleCount;
    [SerializeField] private int carMax;
    [SerializeField] private int bikeMax;
    [SerializeField] GameObject[] vehicleSpawnPoints;
    //idea: fetch ratios and such variables from vehicleMixManager. 
    [SerializeField] private float carToBikeDifference;

    private int activeVehicleCount { get { return activeCarCount + activeBikeCount + activeGarbagetruckCount; } }
    //types of vehicles
    private int activeCarCount;
    private int activeBikeCount;
    private int activeGarbagetruckCount;
    


    private void Start()
    {
        StartCoroutine(IntialSpawn());
        EventManager.Instance.RegisterListener<VehicleDespawnEvent>(DespawnEvent);
        EventManager.Instance.RegisterListener<BuildingSwapEvent>(OnBuildingSwap);
    }

    private void OnBuildingSwap(BuildingSwapEvent eve)
    {
        //if a becycle stand was added, increase proportion of bikes on roads.
        if (eve.newBuilding.GetComponent<Building>().TypeOfBuilding.Equals("BicycleStand")) {
            int change = bikeMax / 2;
            bikeMax += change; //increase by 50%;
            carMax -= change; // decrease by same amount
            Debug.Log("New bike max count: " + bikeMax + " car max count: " + carMax);
        }
    }

    IEnumerator IntialSpawn()
    {
        int count = 0;
        
        while (count < maxVehicleCount)
        {
            if (activeBikeCount < bikeMax) //Old control: carToBikeDifference < (activeCarCount - activeBikeCount)
            {
                InstantiateVehicle(ref bikePrefab);
                activeBikeCount++;
            }
            else if (activeCarCount < carMax)
            {
                InstantiateVehicle(ref vehiclePrefab);
                activeCarCount++;
            }
            
            yield return new WaitForEndOfFrame();
            count++;
        }
    }

    private void SpawnVehicle()
    {
        //print(activeVehicleCount);

        while (activeVehicleCount < maxVehicleCount)
        {
            int randomInt = 0;

            // the purpose of this is to maske sure only 1 vehicle spaws each call if both/all types are "legal" to spawn.
            if (activeBikeCount < bikeMax && activeCarCount < carMax) { 
                randomInt = Random.Range(1, 3);
                Debug.Log("rand int is: " + randomInt);
            }

            if (activeBikeCount < bikeMax && (randomInt == 0 || randomInt == 1)) //Old control: carToBikeDifference < (activeCarCount - activeBikeCount)
            {
                InstantiateVehicle(ref bikePrefab);
                activeBikeCount++;
            }
            else if (activeCarCount < carMax && (randomInt == 0 || randomInt == 2))
            {
                InstantiateVehicle(ref vehiclePrefab);
                activeCarCount++;
            }

            Debug.Log("spawn vehicle: " + activeVehicleCount + " Type: " + randomInt);

        }
    }

    private void DespawnEvent(VehicleDespawnEvent eve)
    {
        Vehicle.VehicleType vehicleType = eve.Vehicle.type;
        if(vehicleType == Vehicle.VehicleType.Car)
        {
            activeCarCount--;
        }
        else
        {
            activeBikeCount--;
        }
        Destroy(eve.Vehicle.gameObject);
        SpawnVehicle();
        print(eve.Description);
    }

    /*
    private void InstantiateVehicle() {
        GameObject obj;
        if (activeBikeCount < bikeMax) //Old control: carToBikeDifference < (activeCarCount - activeBikeCount)
        {
            obj = Instantiate(bikePrefab);
            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
            obj.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();
            obj.transform.position = child.position;
            activeBikeCount++;
        }
        else if (activeCarCount < carMax)
        {
            obj = Instantiate(vehiclePrefab);
            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
            obj.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();
            obj.transform.position = child.position;
            activeCarCount++;
        }
    }
    */

    private void InstantiateVehicle(ref GameObject typeOfVehicle)
    {
        GameObject obj = Instantiate(typeOfVehicle);
        Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
        obj.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();
        obj.transform.position = child.position;
    }

}
