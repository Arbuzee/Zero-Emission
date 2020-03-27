using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject vehiclePrefab;
    [SerializeField] private GameObject bikePrefab;
    [SerializeField] private int vehicleSpawnCount;
    [SerializeField] GameObject[] vehicleSpawnPoints;
    [SerializeField] private float carToBikeRatio;

    private int activeVehicleCount = 0;

    private void Start()
    {
        StartCoroutine(IntialSpawn());
        EventManager.Instance.RegisterListener<VehicleDespawnEvent>(DespawnEvent);
    }

    IEnumerator IntialSpawn()
    {
        int count = 0;
        while (count < vehicleSpawnCount)
        {
            GameObject obj = Instantiate(vehiclePrefab);
            activeVehicleCount++;
            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
            obj.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();
            obj.transform.position = child.position;

            yield return new WaitForEndOfFrame();
            count++;
        }
    }

    private void SpawnVehicle()
    {
        int count = activeVehicleCount;
        while (count < vehicleSpawnCount)
        {
            GameObject obj = Instantiate(vehiclePrefab);
            activeVehicleCount++;
            GameObject spawnPoint = vehicleSpawnPoints[Random.Range(0, (vehicleSpawnPoints.Length - 1))];
            obj.GetComponent<WaypointNavigator>().currentWaypoint = spawnPoint.GetComponent<Waypoint>();
            obj.transform.position = spawnPoint.transform.position;
            count++;
        }
        
    }

    private void DespawnEvent(VehicleDespawnEvent eve)
    {
        activeVehicleCount--;
        SpawnVehicle();
        print(eve.Description);
    }
}
