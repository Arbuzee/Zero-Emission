using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    private Vehicle pedestrian;

    public Waypoint currentWaypoint;
    public int direction = 0;

    private void Start()
    {
        //direction = Mathf.RoundToInt(Random.Range(0f, 1f));
        pedestrian = GetComponent<Vehicle>();
        pedestrian.SetDestination(currentWaypoint.GetPosition());
    }

    private void Update()
    {
        if (pedestrian.reachedDestination)
        {
            bool shouldBranch = false;

            if(currentWaypoint.branches != null && currentWaypoint.branches.Count > 0)
            {
                shouldBranch = Random.Range(0f, 1f) <= currentWaypoint.branchRatio ? true : false;
            }

            if (shouldBranch)
            {
                currentWaypoint = currentWaypoint.branches[Random.Range(0, currentWaypoint.branches.Count - 1)];
            }

            else
            {
                if(direction == 0)
                {
                    if(currentWaypoint.nextWaypoint != null)
                    {
                        currentWaypoint = currentWaypoint.nextWaypoint;
                    }
                    else
                    {
                        currentWaypoint = currentWaypoint.previousWaypoint;
                        direction = 1;
                    }
                }
                else if(direction == 1)
                {
                    if(currentWaypoint.previousWaypoint != null)
                    {
                        currentWaypoint = currentWaypoint.previousWaypoint;
                    }
                    else
                    {
                        currentWaypoint = currentWaypoint.nextWaypoint;
                        direction = 0;
                    }
                }
            }
            pedestrian.SetDestination(currentWaypoint.GetPosition());
        }
    }
}
