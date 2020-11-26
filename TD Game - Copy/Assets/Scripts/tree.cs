using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree
{
    private Node currNode;

    private bool finTree;
    // Start is called before the first frame update
    void Start()
    {
        currNode = new Node();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Node GenerateTree(int curr, Node CurrNode)
    {
        if (curr > 0)
        {
            if (curr > 5)
            {
                CurrNode.AddPossible(CurrNode, MCTS.Decision.EnemyL);
                CurrNode.AddPossible(CurrNode, MCTS.Decision.EnemyM);
                CurrNode.AddPossible(CurrNode, MCTS.Decision.EnemyS);
                return CurrNode;
            }
            else if (curr > 3)
            {
                CurrNode.AddChild(CurrNode, MCTS.Decision.EnemyM);
                CurrNode.AddChild(CurrNode, MCTS.Decision.EnemyS);
                return CurrNode;
            }
            else
            {
                CurrNode.AddChild(CurrNode, MCTS.Decision.EnemyS);      
                return CurrNode;
            }
        }

        if (CurrNode.Decision.Equals("Spread")|| CurrNode.Decision.Equals("Group"))
        {
            return CurrNode;
        }
        else
        {
            CurrNode.AddChild(CurrNode, MCTS.Decision.Group);
            CurrNode.AddChild(CurrNode, MCTS.Decision.Spread);
            return CurrNode;
        }
    }
}
