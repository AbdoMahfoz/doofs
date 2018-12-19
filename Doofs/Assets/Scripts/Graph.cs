using System.Collections.Generic;

static public class Graph
{
    static public int Distance { get; set; }
    static System.Random rnd = new System.Random();
    static public List<Node> CreateGraph(int Distance, int NodeLimit)
    {
        Graph.Distance = Distance;
        List<Node> Nodes = new List<Node>()
        {
            new Node()
            {
                nodeType = NodeType.Start
            }
        };
        GenerateUniquePath(Distance, Nodes[0], Nodes);
        Nodes[Nodes.Count - 1].nodeType = NodeType.End;
        GenerateUselessPath(Nodes, NodeLimit);
        return Nodes;
    }
    static void GenerateUselessPath(List<Node> Nodes, int limit)
    {
        Node cur = new Node();
        Queue<Node> q = new Queue<Node>();
        for(int i = 1; i < Nodes.Count -1; i++)
        {
            q.Enqueue(Nodes[i]);
        }
        while(q.Count > 0 && limit > 0)
        {
            cur = q.Dequeue();
            for(int i = 0; i < 4; i++)
            {
                if (cur.Doors[i] != null)
                    continue;
                int n = rnd.Next(0, 1);
                if(n == 1)
                {
                    Node next = new Node()
                    {
                        nodeType = NodeType.Useless
                    };
                    next.Doors[(i + 2) % 4] = cur;
                    cur.Doors[i] = next;
                    q.Enqueue(next);
                    limit--;
                    Nodes.Add(next);
                }
            }
        }
    }
    static void GenerateUniquePath(int Distance, Node Self, List<Node> Nodes)
    {
        if (Distance == 0)
            return;
        Node next = new Node()
        {
            nodeType = NodeType.Path
        };
        int n = rnd.Next(0, 3);
        while (Self.Doors[n] != null)
        { n = rnd.Next(0, 3); }
        next.Doors[(n + 2) % 4] = Self;
        Self.Doors[n] = next;
        Nodes.Add(next);
        GenerateUniquePath(Distance - 1, next, Nodes);
    }
}
