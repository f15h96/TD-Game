using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCopy : MonoBehaviour
{
    public string[,] board = new string[4,5];

    public GameObject Wall1;
    public GameObject Wall2;
    public GameObject Wall3;
    public GameObject Wall4;

    public List<GameObject> TowerBases;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBoard()
    {
        populateBoard(Wall1);
        populateBoard(Wall2);
        populateBoard(Wall3);
        populateBoard(Wall4);
    }
    
    
    public void populateBoard(GameObject Wall)
    {
        var boardColumn = 0;
        switch (Wall.name)
        {
            case "Wall1": boardColumn = 0;
                break;
            case "Wall2": boardColumn = 1;
                break;
            case "Wall3": boardColumn = 2;
                break;
            case "Wall4": boardColumn = 3;
                break;
        }
        
        for (int i = 0; i < Wall.transform.childCount; i++)
        {
           board[boardColumn, i] = Wall.transform.GetChild(i).GetComponent<TowerBase>().tower.ToString();
        }
        
    }

    public void spawnEnemies()
    {

    }
}
