using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPlacementArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.RegisterListener<EndDragEvent>(ChangeRoad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeRoad(EndDragEvent ev) // varför event? gör som med vanliga placement area, så slipper man iterera genom alla vägar och se vilken som är närmast släppet
    {
        //get roadtype the placing road has (bicycle, regular...)
        
        //instantiate that type of piece with this ID and give this(roadpiece that this script is attached to) rotation and transform.

    }

}
