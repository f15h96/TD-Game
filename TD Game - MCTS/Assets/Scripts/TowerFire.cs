using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFire : MonoBehaviour
{
    private float time;

    public List<GameObject> towers;
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
        towers.Add(other.transform.parent.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        towers.Remove(other.transform.parent.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (gameObject.tag == "AOE")
        {
            time = time + Time.deltaTime;
            if (time > .1f)
            {
                other.transform.parent.gameObject.GetComponent<Enemy>().Health--;
                time = 0f;
            }
        } else if (gameObject.tag == "SingleTarget")
        {
            time = time + Time.deltaTime;
            if (time > 1f)
            {
                towers[0].transform.GetComponent<Enemy>().Health = towers[0].transform.GetComponent<Enemy>().Health - 2;
                time = 0;
            }
        }
    }
}
