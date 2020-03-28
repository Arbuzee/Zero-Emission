using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;
    private Vector3 cameraPosOnBeginDrag;
    public static CameraDrag Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            cameraPosOnBeginDrag = transform.position;
            return;
        }

        if (Input.GetMouseButton(0))
        {
            
            Vector3 dragDistance = dragOrigin - Input.mousePosition;
            transform.position = cameraPosOnBeginDrag - new Vector3(dragDistance.x, 0, dragDistance.y);

            //code for continous movement of camera
            /*
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            float xPos = pos.x  * (dragDistance.magnitude / 10);
            float yPos = pos.y  * (dragDistance.magnitude / 10);
            //Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);
            Vector3 move = new Vector3(xPos, 0, yPos);
            transform.Translate(move, Space.World);
            */
        }





    }



}
