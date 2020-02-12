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

        EventManager.Instance.RegisterListener<DragObjectEvent>(OnBeginDrag);
        EventManager.Instance.RegisterListener<EndDragEvent>(OnEndDrag);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When an object is dragged, call the placements areas that match and tell them to light up or whatevs man
    public void OnBeginDrag(DragObjectEvent ev)
    {
        string buildingSize = ev.obj.GetComponent<Building>().Size;
        GameObject gmo = ev.obj;

        foreach (PlacementArea pa in placementAreas)
        {
           if (pa.Size.Equals(buildingSize)) 
            {
                pa.LightUp();
            }
        }
    }

    public void OnEndDrag(EndDragEvent ev)
    {
        PlacementArea targetArea = null;
        foreach (PlacementArea pa in placementAreas)
        {
            pa.DisableLight();
            if (pa.IsMarked)
                targetArea = pa;
        }

        if(targetArea == null)
        {
            Destroy(ev.obj);
            return;
        }


        ev.obj.GetComponent<Building>().SnapToArea(targetArea);
    }



}
