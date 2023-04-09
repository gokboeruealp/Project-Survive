using System;
using UnityEngine;

[Serializable]
public class GridNode
{
    public int x;
    public int y;

    public GridNode(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2 ToVector2()
    {
        return new Vector2(x, y);
    }

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, 0);
    }
}
