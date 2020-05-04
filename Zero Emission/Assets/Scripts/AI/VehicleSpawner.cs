using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject vehiclePrefab;
    [SerializeField] private GameObject bikePrefab;
    [SerializeField] private GameObject autonomousCarPrefab;
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


    //On building swap needs to check for a lot of scenarios. later, either just put these check in manager, and let spawner script just spawn. Or let the individual buildings 
    // that affect vehicles do a call here on "drop"/Start() when instantiated in world.
    private void OnBuildingSwap(BuildingSwapEvent eve)
    {
        //if a bicycle stand was added, increase proportion of bikes on roads.
        if (eve.newBuilding.GetComponent<Building>().TypeOfBuilding.Equals("BicycleStand")) {
           
        }

        string inBuilding = eve.newBuilding.GetComponent<Building>().TypeOfBuilding;
        switch (inBuilding)
        {
            
            case "BicycleStand":
                //increase scooters/bikes
                int change = bikeMax / 2;
                bikeMax += change; //increase by 50%;
                //carMax -= change; // decrease by same amount
                Debug.Log("New bike max count: " + bikeMax + " car max count: " + carMax);
                break;
            
            case "GasStation":
                //increase "regular" cars
                carMax += maxVehicleCount / 4; // each extra gas station increaases the car count by a fourth of the maximum vehicles
                break;
            
            case "ElectricalStation":
                //increase just AI/electrical cars ratio
                break;
            
            case "ParkingLot":
                //increase max of vehicles
                break;
             
            case "SmartPark":
                //increase vehicle max a load
                break;
        }

        //also check what building was swapped out, this will affect values similarly but like, inverted.
        string outBuilding = eve.newBuilding.GetComponent<Building>().TypeOfBuilding;
        switch (outBuilding)
        {
            case "BicycleStand":
                Debug.Log("wowo");
                break;
            case "GasStation":
                break;
            //increase just AI/electrical cars ratio
            case "ElectricalStation":
                break;
            //increase max of vehicles
            case "ParkingLot":
                break;
            //increase vehicle max a load
            case "SmartPark":
                break;

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


    private void InstantiateVehicle(ref GameObject typeOfVehicle)
    {
        GameObject obj = Instantiate(typeOfVehicle);
        Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
        obj.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();
        obj.transform.position = child.position;
    }

}
