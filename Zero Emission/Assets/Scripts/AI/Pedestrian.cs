using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pedestrian : MonoBehaviour
{
    public GameObject waypointsRoot;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    void Update()
    {
        
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            SetRandomDestination();
        }
    }

    private void SetRandomDestination()
    {
        agent.SetDestination(waypointsRoot.transform.GetChild(Random.Range(0, waypointsRoot.transform.childCount - 1)).transform.position);
    }

}
