using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleDespawnEvent : EventClass
{
    public Vehicle Vehicle;

    public VehicleDespawnEvent(string description, Vehicle vehicle) : base(description)
    {
        Vehicle = vehicle;
    }
}
