using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Building : PlaceableObject
{
    private Collider boxCollider;

    [SerializeField]private int co2Rating;

    public int CO2Rating { get => co2Rating; private set => co2Rating = value; }

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }


    
}

