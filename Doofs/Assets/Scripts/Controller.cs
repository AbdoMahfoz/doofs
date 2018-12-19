using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public int Param1, Param2;
    public GameObject[] Template;
    private GameObject[] GraphObjects;
    public void DrawGraph(Node[] Nodes)
    {
        Dictionary<Node, bool> Visited = new Dictionary<Node, bool>();
        List<GameObject> res = new List<GameObject>();
        Queue<KeyValuePair<GameObject, Node>> q = new Queue<KeyValuePair<GameObject, Node>>();
        q.Enqueue(new KeyValuePair<GameObject, Node>
        (
            Instantiate(Template[(int)Nodes[0].roomType]),
            Nodes[0]
        ));
        res.Add(q.Peek().Key);
        while (q.Count > 0)
        {
            var cur = q.Dequeue();
            for(int i = 0; i < 4; i++)
            {
                Debug.Log(cur.Value.Doors[i]);
                if (cur.Value.Doors[i] != null && !Visited.ContainsKey(cur.Value.Doors[i]))
                {
                    GameObject g = Instantiate(Template[(int)cur.Value.roomType]);
                    g.transform.position = cur.Key.transform.position;
                    switch(i)
                    {
                        case 0:
                            g.transform.Translate(new Vector3(-10.0f, 0.0f, 0.0f));
                            break;
                        case 1:
                            g.transform.Translate(new Vector3(0.0f, 10.0f, 0.0f));
                            break;
                        case 2:
                            g.transform.Translate(new Vector3(10.0f, 0.0f, 0.0f));
                            break;
                        case 3:
                            g.transform.Translate(new Vector3(0.0f, -10.0f, 0.0f));
                            break;
                    }
                    res.Add(g);
                    Visited.Add(cur.Value.Doors[i], true);
                    q.Enqueue(new KeyValuePair<GameObject, Node>(g, cur.Value.Doors[i]));
                }
            }
        }
        GraphObjects = res.ToArray();
    }
    void Start ()
    {
        DrawGraph(Graph.CreateGraph(Param1, Param2));
	}
}
