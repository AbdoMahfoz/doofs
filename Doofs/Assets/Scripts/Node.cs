
public enum RoomType { }
public enum NodeType { Start, End, Useless, Path }
public class Node
{
    /// <summary>
    /// 0 = Left
    /// 1 = Front
    /// 2 = Right
    /// 3 = Down
    /// </summary>
    public Node[] Doors = new Node[4];
    public int ID;
    public RoomType roomType;
    public NodeType nodeType;
}
