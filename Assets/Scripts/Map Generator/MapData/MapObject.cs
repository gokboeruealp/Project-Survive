using UnityEngine;

public class MapObject : MonoBehaviour
{
    public EMapObjectType _type;
    public GridNode _gridNode;

    public MapObject(EMapObjectType type, GridNode gridNode)
    {
        _type = type;
        _gridNode = gridNode;
    }
}
