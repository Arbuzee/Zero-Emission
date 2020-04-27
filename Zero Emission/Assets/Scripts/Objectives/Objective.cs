using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{

    public string description;
    public string typeToBuild;
    public int count;

    public Objective(string desc, string type, int count) {
        description = desc;
        typeToBuild = type;
        this.count = count;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame. Keep this as instantiated objective should check its own requirements and call printer to fix if more complex.
    void Update()
    {
        
    }
}
