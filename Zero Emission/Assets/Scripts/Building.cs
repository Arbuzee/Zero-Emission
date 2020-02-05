﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private Collider boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlacementArea"))
        {
            print("snapping");
            transform.position = other.gameObject.transform.position;
        }
    }
}