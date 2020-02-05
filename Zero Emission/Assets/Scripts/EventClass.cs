using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// use as a parent to all events created. 
public class EventClass : MonoBehaviour
{

    public string Description;

    public EventClass(string description)
    {
        this.Description = description;
    }

}
