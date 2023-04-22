using System.Collections.Generic;
using UnityEngine;

namespace GokboerueTools.MapGenerator
{
    public class MapObject : MonoBehaviour
    {
        public EMapObjectType _type;
        public EMapMoveableObjectType _moveableType;
        public GridNode _gridNode;
        public List<MapObject> _connectedMapObjects;
        public bool isPassed = false;

        public void setColor(Color color)
        {
            GetComponent<SpriteRenderer>().color = color;
        }

        public void setMapObjectType(EMapMoveableObjectType moveableType)
        {
            _moveableType = moveableType;

            switch (moveableType)
            {
                case EMapMoveableObjectType.None:
                    setColor(Color.green);
                    break;
                case EMapMoveableObjectType.Moveable:
                    setColor(Color.cyan);
                    break;
                case EMapMoveableObjectType.Passed:
                    setColor(Color.yellow);
                    break;
            }
        }

        public MapObject(EMapObjectType type, GridNode gridNode)
        {
            _type = type;
            _moveableType = EMapMoveableObjectType.None;
            _gridNode = gridNode;
            _connectedMapObjects = new List<MapObject>();
            isPassed = false;
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