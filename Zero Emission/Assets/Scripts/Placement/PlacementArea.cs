//Author: Sofia Kauko
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuildingSizes;

public class PlacementArea : MonoBehaviour
{
    private bool isMarked;
    Light paLight;
    //[SerializeField]private string size;
    [SerializeField]private GameObject currentBuilding;
    //public string Size { get => size; set => size = value; }
    public SIZE Size;
    public bool IsMarked { get => isMarked; set => isMarked = value; }
    public GameObject CurrentBuilding { get => currentBuilding; set => currentBuilding = value; }
    
    // Start is called before the first frame update
    void Start()
    {
        paLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            isMarked = true;
            //Debug.Log("A PA is marked");
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            isMarked = false;
        }
    }

    public void SwapBuilding(GameObject newBuilding)
    {
        IsMarked = false; //to unmark as OnExit won't trigger when building is placed.
        int CO2Rating;

        if (CurrentBuilding == null)
        {
            //get new buildings co2 rating
            CO2Rating = newBuilding.GetComponent<Building>().CO2Rating;
            currentBuilding = newBuilding;
            
        }
        else
        {
            //calculate co2 diff between swapped buildings
            CO2Rating = newBuilding.GetComponent<Building>().CO2Rating - currentBuilding.GetComponent<Building>().CO2Rating;
            Destroy(currentBuilding);
            currentBuilding = newBuilding;
        }

        //send CO2-change event
        EventManager.Instance.FireEvent(new CO2Change("possible Co2 level change has occured", newBuilding, CO2Rating));
    }

    public void LightUp()
    {
        paLight.enabled = true;
        if (currentBuilding != null)
            currentBuilding.SetActive(false);
    }

    public void DisableLight()
    {
        paLight.enabled = false;
        if (currentBuilding != null)
            currentBuilding.SetActive(true);
    }


}
