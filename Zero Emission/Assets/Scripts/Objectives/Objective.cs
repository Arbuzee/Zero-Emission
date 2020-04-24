using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{

    public string description;
    public string type;
    public int count;

    public Objective(string desc, string type, int count) {
        description = desc;
        this.type = type;
        this.count = count;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
