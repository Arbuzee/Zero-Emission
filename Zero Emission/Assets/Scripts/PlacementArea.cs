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
    private GameObject currentBuilding;
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

    
    /// <summary>
    /// highly temporary solution since i cant figure out sum better right now.
    /// 
    /// </summary>
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            isMarked = true;
            

            Debug.Log("A PA is marked");
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
        if(CurrentBuilding == null)
        {
            currentBuilding = newBuilding;
        }
        else
        {
            Destroy(currentBuilding);
            currentBuilding = newBuilding;
        }
        IsMarked = false; //to unmark as OnExit won't trigger when building is placed.
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
