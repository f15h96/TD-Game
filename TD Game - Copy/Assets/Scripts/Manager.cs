using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject HighlghtedGameObject;

    private Vector3 TowerPos;

    public GameObject SingleTower;
    public GameObject AOETower;

    public int HP = 100;
    private TowerBase towerBase;

    public EnemySpawn spawn;

    public Button NextWaveButton;

    public Image GameOver;

    public int Wave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Enemy") == false)
        {
            NextWaveButton.gameObject.SetActive(true);
        }

        if (HP <= 0)
        {
            GameOver.gameObject.SetActive(true);
        }
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

    public void StartWave()
    {
        gameObject.GetComponent<GameCopy>().StartBoard();
       spawn.StartWave();
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

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void RemoveTower()
    {
        towerBase = HighlghtedGameObject.GetComponent<TowerBase>();
        Destroy(towerBase.tower);
        towerBase.hasTower = false;
    }
}
