//Author: Sofia Kauko
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementArea : MonoBehaviour
{
    Light paLight;

    // Start is called before the first frame update
    void Start()
    {
        paLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LightUp()
    {
        paLight.enabled = true;
    }

    public void DisableLight()
    {
        paLight.enabled = false;
    }


}
