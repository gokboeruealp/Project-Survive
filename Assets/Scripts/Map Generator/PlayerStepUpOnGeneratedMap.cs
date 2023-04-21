using GokboerueTools.MapGenerator;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GokboerueTools.MapGenerator
{
    public class PlayerStepUpOnGeneratedMap : MonoBehaviour
    {
        [SerializeField] private MapGenerator mapGenerator;
        List<MapObject> moveableMapObjects = new List<MapObject>();

        private Vector3 targetPosition;
        public MapObject currentMapObject;

        private void OnEnable()
        {
            moveableMapObjects = mapGenerator.GetStartRooms();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit.collider != null)
                {
                    var mapObject = hit.collider.gameObject.GetComponent<MapObject>();
                    if (mapObject != null)
                    {
                        if (moveableMapObjects.Contains(mapObject))
                        {
                            for (int i = 0; i < moveableMapObjects.Count; i++)
                            {
                                if (moveableMapObjects[i] != currentMapObject)
                                {
                                    moveableMapObjects[i].setMapObjectType(EMapMoveableObjectType.None);
                                }
                            }
                            
                            targetPosition = mapObject.transform.position;
                            currentMapObject = mapObject;
                            moveableMapObjects = mapObject._connectedMapObjects;

                            mapObject.setMapObjectType(EMapMoveableObjectType.Passed);
                            mapObject.isPassed = true;
                            
                            foreach (var connectedMapObject in mapObject._connectedMapObjects)
                            {
                                connectedMapObject.setMapObjectType(EMapMoveableObjectType.Moveable);
                            }
                        }
                    }
                }
            }

            if (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, 5 * Time.deltaTime);
            }

            if (Camera.main.transform.position.y < GetTopBotmostMapObjectY(true) - 5)
            {
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, transform.position.y + 7, Camera.main.transform.position.z);
            }
        }

        private float GetTopBotmostMapObjectY(bool isTop)
        {
            var mapObjects = mapGenerator.GetMapObjects();
            var topmostMapObject = mapObjects[0];
            foreach (var mapObject in mapObjects)
            {
                if (isTop)
                {
                    if (mapObject.transform.position.y > topmostMapObject.transform.position.y)
                    {
                        topmostMapObject = mapObject;
                    }
                }
                else
                {
                    if (mapObject.transform.position.y < topmostMapObject.transform.position.y)
                    {
                        topmostMapObject = mapObject;
                    }
                }
            }

            return topmostMapObject.transform.position.y;
        }
    }
}