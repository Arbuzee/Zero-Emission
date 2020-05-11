using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUp : MonoBehaviour
{

    [SerializeField] private float FloatSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newY = gameObject.transform.position.y + FloatSpeed * Time.deltaTime;
        Vector3 newPos = gameObject.transform.position;
        newPos.y = newY;
        gameObject.transform.position = newPos;
    }
}
