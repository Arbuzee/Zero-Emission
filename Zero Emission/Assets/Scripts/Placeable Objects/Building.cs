using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Building : PlaceableObject
{
    private Collider boxCollider;
    

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    
}

