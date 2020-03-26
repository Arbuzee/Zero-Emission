using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuildingSizes;

public class PlacementAreaManager : MonoBehaviour
{
    private  PlacementArea[] placementAreas;

    // Start is called before the first frame update
    void Start()
    {
        placementAreas = FindObjectsOfType<PlacementArea>();

        EventManager.Instance.RegisterListener<DragObjectEvent>(OnBeginDrag);
        EventManager.Instance.RegisterListener<EndDragEvent>(OnEndDrag);

        //Set max CO2 level for Co2lvl manager.
        int Co2MaxLevel = 0;
        foreach (PlacementArea pa in placementAreas) // break loop into other method?
        {
            if(pa.CurrentBuilding != null)
            {
                Co2MaxLevel += pa.CurrentBuilding.GetComponent<PlaceableObject>().CO2Rating;
            }
        }

        CO2Manager.Instance.SetMaxCO2(Co2MaxLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When an object is dragged, call the placements areas that match and tell them to light up or whatevs man
    public void OnBeginDrag(DragObjectEvent ev)
    {
        //temp solution 
        if (RoadCheck(ev.obj))
        {
            return;
        }


        SIZE buildingSize = ev.obj.GetComponent<PlaceableObject>().Size;
        GameObject gmo = ev.obj;

        foreach (PlacementArea pa in placementAreas)
        {
            pa.IsMarked = false;
            if (pa.Size.Equals(buildingSize)) 
            {
                pa.LightUp();
            }
        }
    }


    //might move listening to individual placement areas.
    public void OnEndDrag(EndDragEvent ev)
    {
        //temp solution 
        if (RoadCheck(ev.obj))
        {
            return;
        }

        PlacementArea targetArea = null;
        SIZE buildingSize = ev.obj.GetComponent<PlaceableObject>().Size;

        foreach (PlacementArea pa in placementAreas)
        {
            pa.DisableLight();
            if (pa.IsMarked && pa.Size.Equals(buildingSize))
            {
                targetArea = pa;
            }
        }

        if(targetArea == null)
        {
            Destroy(ev.obj);
            return;
        }

        ev.obj.GetComponent<PlaceableObject>().SnapToArea(targetArea);
    }




    private bool RoadCheck(GameObject obj)
    {
        Road road;
        bool isRoad = obj.TryGetComponent<Road>(out road);
        return isRoad;
    }

}
