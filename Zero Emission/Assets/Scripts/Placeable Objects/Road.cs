﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : PlaceableObject
{
    private int RoadID;
    private void Start()
    {
        EventManager.Instance.RegisterListener<EndDragEvent>(OnRoadDrop);
    }



    private void OnRoadDrop(EndDragEvent eve)
    {

    }

}
