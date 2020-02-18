using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuildingSizes;

public class Building : PlaceableObject
{
    private Collider boxCollider;
    public SIZE Size;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    public SIZE GetSize()
    {
        return Size;
    }
}

namespace BuildingSizes
{
    public enum SIZE
    {
        Small,
        Medium,
        Large
    };
}
