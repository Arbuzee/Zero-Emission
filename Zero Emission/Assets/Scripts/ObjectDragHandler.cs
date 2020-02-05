using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RawImage image;
    private Vector3 originalPosition;
    [SerializeField] private GameObject building;
    [SerializeField] private RectTransform panel;
    private GameObject buildingObject;
    private bool instantiated = false;
    [SerializeField] private LayerMask layerMask;

    private void Start()
    {
        image = GetComponent<RawImage>();
        originalPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {

        if(buildingObject != null)
        {
            buildingObject.transform.position = GetMouseWorldPos();
        }

        else
        {
            transform.position = Input.mousePosition;
        }

        if(!RectTransformUtility.RectangleContainsScreenPoint(panel, Input.mousePosition))
        {
            image.enabled = false;
            if(!instantiated)
                InstantiateBuilding();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.enabled = true;
        transform.position = originalPosition;
        instantiated = false;
    }

    private void InstantiateBuilding()
    {
        buildingObject = Instantiate(building, Input.mousePosition, Quaternion.identity);
        instantiated = true;
    }

    private Vector3 GetMouseWorldPos()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
        Vector3 mousePoint = new Vector3(hit.point.x, 0.0f, hit.point.z);
        return mousePoint;
    }
}
