﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraDrag : MonoBehaviour
{
    [SerializeField] private float dragSpeed = 2;
    [SerializeField] private float minHeight;
    [SerializeField] private float maxHeight;
    [SerializeField] private float topDownTreshhold;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float topDownAngle;

    [Header("Borders")]
    [SerializeField] private float MaxX;
    [SerializeField] private float MinX;
    [SerializeField] private float MaxZ;
    [SerializeField] private float MinZ;
    private float bounce = 0f;
    

    private Vector3 dragOrigin;
    private Vector3 cameraPosOnBeginDrag;
    private Vector3 cameraDragDirection;
    private Quaternion standardRotation;
    private float cameraGlideMagnitude;
    private Vector3 mousePosition;
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

    private void Start()
    {
        standardRotation = gameObject.transform.rotation;
    }
    void Update()
    {

       

        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            cameraPosOnBeginDrag = transform.position;
            return;
        }

        if (Input.GetMouseButtonUp(0)) {
            
            //if mouse position is very different from position last frame, let camera glide, if rather still, stop camera.
            Vector3 newMousePosition = Input.mousePosition;
            if (Vector3.Distance(mousePosition, newMousePosition) > 0.2f) {
                cameraGlideMagnitude = cameraDragDirection.magnitude; //for glide when cam is let go
            }
        }

        //get mouse position
        mousePosition = Input.mousePosition;

        //cam is bouncing currently
        if (bounce > 0)
        {
            transform.position += cameraDragDirection * (bounce * 3) * Time.deltaTime;
            bounce -= Time.deltaTime;
            //so that camera does not glide after bounce is finished.
            cameraGlideMagnitude = 0;
            /*
            if (bounce < 0.05f) {
                cameraDragDirection.Normalize();
            }
            */

            return;
        }
        else {
            transform.position -= cameraDragDirection.normalized * cameraGlideMagnitude * Time.deltaTime;
            cameraGlideMagnitude *= 0.95f;
        }

        if (Input.GetMouseButton(0))
        {

            //check
            if (bounce <= 0 && MinX <= gameObject.transform.position.x && gameObject.transform.position.x <= MaxX && MinZ <= gameObject.transform.position.z && gameObject.transform.position.z <= MaxZ)
            {
                Vector3 dragDistance = dragOrigin - Input.mousePosition;
                cameraDragDirection = new Vector3(dragDistance.x, 0, dragDistance.y);
                cameraDragDirection *= (gameObject.transform.position.y / 250);
                transform.position = cameraPosOnBeginDrag - cameraDragDirection;
                
            }

            else {
                bounce = 0.5f;
                cameraGlideMagnitude = 0;
            }
            
            
        }

        // Zoom in / zoom out
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        
        if (scroll < 0 && gameObject.transform.position.y < maxHeight)
        {
            Debug.Log("scrolling < 0");
            gameObject.transform.position += new Vector3(0f, zoomSpeed, 0f);
        }
        else if (scroll > 0 && gameObject.transform.position.y > minHeight)
        {
            Debug.Log("scrolling > 0");
            gameObject.transform.position += new Vector3(0f, -zoomSpeed, 0f);
        }
        

        //lerp camera at height treshhold. 
        if (gameObject.transform.position.y < topDownTreshhold)
        {
            //create euler angles that represent desired rotation and make a quaternion out of it:
            Quaternion topDownRotation = Quaternion.Euler(topDownAngle, standardRotation.eulerAngles.y, standardRotation.eulerAngles.z);
            //use this quiaternion to lerp to, as euler angles does not lerp as expected...
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, topDownRotation, 0.05f);
        }

        else if (gameObject.transform.position.y > topDownTreshhold)
        {
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, standardRotation, 0.05f);
        }

    }


    private void OnDisable()
    {
        cameraGlideMagnitude = 0;
    }



}
