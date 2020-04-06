using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pedestrian;
    [SerializeField] private int spawnLimit;

    


    private void Start()
    {
        StartCoroutine(IntialSpawn());
        
    }

    IEnumerator IntialSpawn()
    {
        int count = 0;
        while (count < spawnLimit)
        {
            GameObject obj = Instantiate(pedestrian, transform.GetChild(Random.Range(0, transform.childCount - 1)));
            obj.GetComponent<Pedestrian>().waypointsRoot = this.gameObject;
            yield return new WaitForEndOfFrame();
            count++;
        }
    }
}

