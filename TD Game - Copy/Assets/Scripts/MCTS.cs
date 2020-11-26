using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class MCTS : MonoBehaviour
{
    public enum Decision
    {
        EnemyL,
        EnemyM,
        EnemyS,
        Spread,
        Group,
    };

    public EnemySpawn Spawn;

    public Tree tree;
    
    private Node CurrNode = new Node();

    private Node bestScore;
    
    private int Currency;
    
    void Start()
    {
        CurrNode.isRoot = true;
        Currency = Spawn.Currency;
        CurrNode = tree.GenerateTree(Currency, CurrNode);
        PickNode(CurrNode);
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    

    private void PickNode(Node parent)
    {
        if (!CurrNode.explored)
        {
            if (CurrNode.Children.Count > 0)
            {
                Random r = new Random();
                var n = r.Next(0, CurrNode.Children.Count);
                if (CurrNode.Children[n].explored)
                {
                    if (ExploredCheck())
                    {
                        PickNode(CurrNode);
                        SpendCurrency();
                        CurrNode = tree.GenerateTree(Currency,CurrNode);
                    }
                    else
                    {
                        PickNode(CurrNode);
                        CurrNode.explored = true;
                        CurrNode = CurrNode.parent;
                    }
                }
                else
                {
                    CurrNode = CurrNode.Children[n];
                    PickNode(CurrNode);
                    SpendCurrency();
                    CurrNode = tree.GenerateTree(Currency,CurrNode);
                }
            }
            
            CurrNode.explored = true;
            CurrNode.score += 1;
            BackPropagate(CurrNode);
        }

        bestChild();
    }

    private bool ExploredCheck()
    {
        List<Node> notexplored = new List<Node>();
        for (int i = 0; i < CurrNode.Children.Count; i++)
        {
            if (!CurrNode.Children[i].explored)
            {
                notexplored.Add(CurrNode.Children[i]);
            }
        }

        if (notexplored.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void bestChild()
    {
        for (int i = 0; i < CurrNode.Children.Count -1; i++)
        {
            for (int j = 1; j < CurrNode.Children.Count; j++)
            {
                if (CurrNode.Children[i].score > CurrNode.Children[j].score)
                {
                    bestScore = CurrNode.Children[i];
                }
                else
                {
                    bestScore = CurrNode.Children[j];
                }
            }
        }
    }
    private void BackPropagate(Node child)
    {
        if (!child.parent.isRoot)
        {
            child.parent.score += child.score;
            BackPropagate(child.parent);
        }
        else
        {
            Currency = Spawn.Currency;
        }
        
    }

    private void SpendCurrency()
    {
        var currdecision = CurrNode.Decision;
        switch (currdecision)
        {
            case "EnemyL":
                Currency -= 5;
                break;
            case "EnemyM":
                Currency -= 3;
                break;
            case "EnemyS":
                Currency -= 1;
                break;
            default:
                break;
        }
    }
}
