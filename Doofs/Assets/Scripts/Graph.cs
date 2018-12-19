using System.Collections.Generic;

static public class Graph
{
    static public int Distance { get; set; }
    static System.Random rnd = new System.Random();
    static public Node[] CreateGraph(int Distance, int NodeLimit)
    {
        Graph.Distance = Distance;
        List<Node> Nodes = new List<Node>()
        {
            new Node()
            {
                nodeType = NodeType.Start,
                ID = 0
            }
        };
        GenerateUniquePath(Distance, Nodes[0], Nodes);
        Nodes[Nodes.Count - 1].nodeType = NodeType.End;
        GenerateUselessPath(Nodes, NodeLimit);
        return Nodes.ToArray();
    }
    static void GenerateUselessPath(List<Node> Nodes, int limit)
    {
        List<Node> StartUseless = new List<Node>(Nodes);
        StartUseless.RemoveAt(StartUseless.Count - 1);
        for (int i = 0; i < limit; i++)
        {
            int index = rnd.Next(0, StartUseless.Count - 1);
            for (int j = 0; j < 4; j++)
            {
                if (StartUseless[index].Doors[j] == null)
                {
                    Node next = new Node()
                    {
                        nodeType = NodeType.Useless,
                        ID = Nodes.Count
                    };
                    next.Doors[(j + 2) % 4] = StartUseless[index];
                    StartUseless[index].Doors[j] = next;
                    Nodes.Add(next);
                    StartUseless.Add(next);
                    int cnt = 0;
                    for (int z = 0; z < 4; z++)
                    {
                        if (StartUseless[index].Doors[z] == null)
                            cnt++;
                    }
                    if (cnt == 0)
                        StartUseless.RemoveAt(index);
                    break;
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
            nodeType = NodeType.Path,
            ID = Nodes.Count
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
