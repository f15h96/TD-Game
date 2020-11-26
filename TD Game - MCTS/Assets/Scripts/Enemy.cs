using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health;
    public GameObject Waypoints;
    public float Speed;
    public int waypointNumber = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Waypoints = GameObject.Find("Waypoints");
    }

    // Update is called once per frame
    void Update()
    {
        Transform Waypoint = Waypoints.transform.GetChild(waypointNumber);
        Vector3 newPos = Vector3.MoveTowards(transform.position, Waypoint.position, Speed);
        transform.position = newPos;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
