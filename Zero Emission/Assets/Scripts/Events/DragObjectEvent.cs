using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectEvent : EventClass
{
    public GameObject obj;
    public DragObjectEvent(string description, GameObject obj) : base(description)
    {
        this.obj = obj;
    }
    
}
