using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlaceableObject : MonoBehaviour
{
    private Vector3 rotation;

    private void Start()
    {
        EventManager.Instance.RegisterListener<EndDragEvent>(Replace);
    }

    protected void Replace(EndDragEvent eve)
    {
        
    }

    private void RemoveListener()
    {
        EventManager.Instance.UnregisterListener<EndDragEvent>(Replace);
    }

    public void SnapToArea(PlacementArea pa)
    {
        Debug.Log(pa);
        //snap to target area
        transform.position = pa.gameObject.transform.position;
        //Give target area ref to new occupying building (if occupied).
        pa.SwapBuilding(this.gameObject);
    }
}
