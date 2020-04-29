using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBuilding : Building
{
    [SerializeField] private GameObject drones;
    [SerializeField] private float minDroneLiftTime = 10f;
    [SerializeField] private float maxDroneLiftTime = 30f;
    private float spawnTimer;

    private void Start()
    {
        spawnTimer = Random.Range(minDroneLiftTime, maxDroneLiftTime);
        //drones.transform.GetChild(Random.Range(0, drones.transform.childCount)).GetComponent<Animator>().SetTrigger("Liftoff");
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0)
        {
            drones.transform.GetChild(Random.Range(0, drones.transform.childCount)).GetComponent<Animator>().SetTrigger("Liftoff");
            spawnTimer = Random.Range(minDroneLiftTime, maxDroneLiftTime);
        }
    }
}
