using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleDespawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Vehicle"))
        {
            EventManager.Instance.FireEvent(new VehicleDespawnEvent("Vehicle despawned", other.gameObject.GetComponent<Vehicle>()));
        }
    }
}
