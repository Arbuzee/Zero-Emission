using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject vehiclePrefab;
    [SerializeField] private GameObject bikePrefab;
    [SerializeField] private int vehicleSpawnCount;
    [SerializeField] GameObject[] vehicleSpawnPoints;
    [SerializeField] private float carToBikeDifference;

    private int activeVehicleCount { get { return activeCarCount + activeGreenCount; } }
    private int activeCarCount;
    private int activeGreenCount;

    private void Start()
    {
        StartCoroutine(IntialSpawn());
        EventManager.Instance.RegisterListener<VehicleDespawnEvent>(DespawnEvent);
    }

    private void Update()
    {
        
    }

    IEnumerator IntialSpawn()
    {
        int count = 0;
        GameObject obj;
        while (count < vehicleSpawnCount)
        {
            if(carToBikeDifference < (activeCarCount - activeGreenCount))
            {
                obj = Instantiate(bikePrefab);
                activeGreenCount++;
            }
            else
            {
                obj = Instantiate(vehiclePrefab);
                activeCarCount++;
            }
            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
            obj.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();
            obj.transform.position = child.position;

            yield return new WaitForEndOfFrame();
            count++;
        }
    }

    private void SpawnVehicle()
    {
        print(activeVehicleCount);

        GameObject obj;
        while (activeVehicleCount < vehicleSpawnCount)
        {
            if (carToBikeDifference < (activeCarCount - activeGreenCount))
            {
                obj = Instantiate(bikePrefab);
                activeGreenCount++;
            }
            else
            {
                obj = Instantiate(vehiclePrefab);
                activeCarCount++;
            }
            GameObject spawnPoint = vehicleSpawnPoints[Random.Range(0, (vehicleSpawnPoints.Length - 1))];
            obj.GetComponent<WaypointNavigator>().currentWaypoint = spawnPoint.GetComponent<Waypoint>();
            obj.transform.position = spawnPoint.transform.position;
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
            activeGreenCount--;
        }
        Destroy(eve.Vehicle.gameObject);
        SpawnVehicle();
        print(eve.Description);
    }
}
