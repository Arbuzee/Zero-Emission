using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuildingSizes;

public class Building : PlaceableObject
{
    private Collider boxCollider;
    //[SerializeField] private string size;

    //public string Size { get => size; set => size = value; }
    public SIZE Size;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlacementArea"))
        {
            print("snapping");
            transform.position = other.gameObject.transform.position;
        }
    }
    */
    /*
    public void SnapToArea(PlacementArea pa)
    {
        Debug.Log(pa);
        //snap to target area
        transform.position = pa.gameObject.transform.position;
        //Give target area ref to new occupying building (if occupied).
        pa.SwapBuilding(this.gameObject);
    }
    */

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
