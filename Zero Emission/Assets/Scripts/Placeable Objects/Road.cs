using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    
    [SerializeField]private string roadType;
    private bool isTriggered;
    [SerializeField] private GameObject greenSiblingRoad;
    [SerializeField] private GameObject regularSiblingRoad;

    public string RoadType { get => roadType; set => roadType = value; }

    private void Start()
    {
        EventManager.Instance.RegisterListener<EndDragEvent>(OnObjectDrop);
    }

    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Road"))
        {
            Debug.Log("road has been triggered.");
            isTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Road"))
        {
            isTriggered = false;
            Debug.Log("road has been UNtriggered.");
        }
    }
    


    // nonononno
    private void OnObjectDrop(EndDragEvent eve)
    {
        if (isTriggered)
        {
            Debug.Log("New road dropped");
            isTriggered = false; //untrigger if new obj is placed. not neccesary if destroy works


            //instatiate, set and rotate new roadpiece to match this roadpiece.
            string type = eve.obj.GetComponent<Road>().RoadType;
            GameObject newRoad;
            if (type == "GreenRoad")
            {
                newRoad = Instantiate(greenSiblingRoad);
                newRoad.transform.position = this.gameObject.transform.position;
                newRoad.transform.rotation = this.gameObject.transform.rotation;
            }
            else if (type == "RegularRoad")
            {
                newRoad = Instantiate(regularSiblingRoad);
                newRoad.transform.position = this.gameObject.transform.position;
                newRoad.transform.rotation = this.gameObject.transform.rotation;
            }
            

            //NEED to fix situation when remove listener creates enumaration problems. Look into soon
            //prep for removal
            //gameObject.SetActive(false);
            transform.root.gameObject.SetActive(false); // temporary removal of old road.
            //EventManager.Instance.UnregisterListener<EndDragEvent>(OnObjectDrop);
            //Destroy(this.gameObject);
            
        }
        //remove road showpiece
        Destroy(eve.obj);
    }

}
