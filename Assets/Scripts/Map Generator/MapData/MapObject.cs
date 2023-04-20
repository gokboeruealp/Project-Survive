using System.Collections.Generic;
using UnityEngine;

namespace GokboerueTools.MapGenerator
{
    public class MapObject : MonoBehaviour
    {
        public EMapObjectType _type;
        public GridNode _gridNode;
        public List<MapObject> _connectedMapObjects;

        public void setColor(Color color)
        {
            GetComponent<SpriteRenderer>().color = color;
        }

        public MapObject(EMapObjectType type, GridNode gridNode)
        {
            _type = type;
            _gridNode = gridNode;
        }

        public void AddConnectedMapObject(MapObject mapObject)
        {
            if (_connectedMapObjects == null)
            {
                _connectedMapObjects = new List<MapObject>();
            }

            if (!_connectedMapObjects.Contains(mapObject))
            {
                _connectedMapObjects.Add(mapObject);
            }
        }
    }
}