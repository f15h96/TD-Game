using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.transform.parent.GetComponent<Enemy>()!= null)
        {
            other.gameObject.transform.parent.GetComponent<Enemy>().waypointNumber += 1;
        }
    }
}
