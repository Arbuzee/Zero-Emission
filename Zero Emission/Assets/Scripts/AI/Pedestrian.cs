using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pedestrian : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float waypointDistance;
    [SerializeField] private Vector3 currentWaypoint;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[0].transform.position);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            agent.SetDestination(waypoints[1].transform.position);
        }

        currentWaypoint = agent.destination;
    }
}
