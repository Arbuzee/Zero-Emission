﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDragEvent : EventClass
{

    GameObject obj;
    public EndDragEvent(string description, GameObject obj) : base(description)
    {
        this.obj = obj;
    }

}
