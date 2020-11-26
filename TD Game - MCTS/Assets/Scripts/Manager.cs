using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject HighlghtedGameObject;

    private Vector3 TowerPos;

    public GameObject SingleTower;
    public GameObject AOETower;

    public int HP = 100;
    private TowerBase towerBase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SingleTarget()
    {
        towerBase = HighlghtedGameObject.GetComponent<TowerBase>();
        if (towerBase.hasTower == false)
        {
            TowerPos = HighlghtedGameObject.transform.position;
            towerBase.tower = Instantiate(SingleTower, TowerPos, Quaternion.identity);
            towerBase.hasTower = true;
        }
    }
    
    public void AOE()
    {
        towerBase = HighlghtedGameObject.GetComponent<TowerBase>();
            if (towerBase.hasTower == false)
        {
            TowerPos = HighlghtedGameObject.transform.position;
            towerBase.tower = Instantiate(AOETower, TowerPos, Quaternion.identity);
            towerBase.hasTower = true;
        }

    }

    public void RemoveTower()
    {
        towerBase = HighlghtedGameObject.GetComponent<TowerBase>();
        Destroy(towerBase.tower);
        towerBase.hasTower = false;
    }
}
