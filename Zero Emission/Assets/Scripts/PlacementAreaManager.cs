using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementAreaManager : MonoBehaviour
{
    private  PlacementArea[] placementAreas;

    // Start is called before the first frame update
    void Start()
    {
        placementAreas = FindObjectsOfType<PlacementArea>(); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When an object is dragged, call the placements areas that match and tell them to light up or whatevs man
    public void OnBeginDrag()
    {
        foreach(PlacementArea pa in placementAreas)
        {
            pa.LightUp();
        }
    }

    public void OnEndDrag()
    {
        foreach (PlacementArea pa in placementAreas)
        {
            pa.DisableLight();
        }
    }

}
