using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{

    public List<Node> Children = new List<Node>();
    
    public List<Node> possibleChildren = new List<Node>();

    public Node parent;

    public string Decision;

    public bool explored;

    public int score;

    public bool isRoot;

    public int timesVisited;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddChild(Node parent, MCTS.Decision decistion)
    {
        Node node = new Node();
        node.parent = parent;
        node.Decision = decistion.ToString();
        parent.Children.Add(node);
    }

    public void AddPossible(Node parent, MCTS.Decision decistion)
    {
        
    }
    
}
