using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapping : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlacementArea"))
        {
            print("snapping");
            transform.position = other.gameObject.transform.position;
        }
    }
}
