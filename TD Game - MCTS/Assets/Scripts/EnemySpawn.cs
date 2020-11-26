using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyS;
    public GameObject enemyM;
    public GameObject enemyL;
    // Start is called before the first frame update
    void Start()
    {
        SpawnS();
        SpawnM();
        SpawnM();
        // SpawnL();
    }

    // Update is called once per frame
    void Update()
    {
    }

    
    public void SpawnS()
    {
        Instantiate(enemyS, transform.GetChild(0).position, Quaternion.identity);
    }
    public void SpawnM()
    {
        Instantiate(enemyM, transform.GetChild(1).position, Quaternion.identity);
    }
    public void SpawnL()
    {
        Instantiate(enemyL, transform.GetChild(2).position, Quaternion.identity);
    }
}
