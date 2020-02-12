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
}
