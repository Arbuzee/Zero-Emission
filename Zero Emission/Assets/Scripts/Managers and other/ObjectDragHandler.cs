﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private RawImage image;
    private Vector3 originalPosition;
    [SerializeField] private GameObject building;
    private RectTransform panel;
    private GameObject placementObject;
    private bool instantiated = false;
    [SerializeField] private LayerMask layerMask;

    private void Start()
    {
        image = GetComponent<RawImage>();
        originalPosition = transform.position;
        panel = transform.parent.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (RectTransformUtility.RectangleContainsScreenPoint(transform.parent.GetComponent<RectTransform>(), Input.mousePosition))
            {
                CameraDrag.Instance.enabled = false;
            }
        }
        if (Input.GetMouseButtonUp(0)) {
            CameraDrag.Instance.enabled = true;
        }
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        CameraDrag.Instance.enabled = false;
        /*
        if (!RectTransformUtility.RectangleContainsScreenPoint(panel, Input.mousePosition)) {
            CameraDrag.Instance.enabled = true;
        }
        */
    }

    public void OnDrag(PointerEventData eventData)
    {

        if(placementObject != null)
        {
            placementObject.transform.position = GetMouseWorldPos();
        }
        /*
        else
        {
            transform.position = Input.mousePosition;
        }
        */
        if(!RectTransformUtility.RectangleContainsScreenPoint(panel, Input.mousePosition))
        {
            image.enabled = false;
            if (!instantiated)
            {
                InstantiateBuilding();
                EventManager.Instance.FireEvent(new DragObjectEvent("object is being dragged", placementObject));
            }
        }
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        EventManager.Instance.FireEvent(new EndDragEvent("Dragging ended", placementObject));
        image.enabled = true;
        transform.position = originalPosition;
        instantiated = false;
        placementObject = null;

        CameraDrag.Instance.enabled = true;
    }

    private void InstantiateBuilding()
    {
        placementObject = Instantiate(building, Input.mousePosition, Quaternion.identity);
        instantiated = true;
    }

    private Vector3 GetMouseWorldPos()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask);
        Vector3 mousePoint = new Vector3(hit.point.x, 0.0f, hit.point.z);
        return mousePoint;
    }
}
