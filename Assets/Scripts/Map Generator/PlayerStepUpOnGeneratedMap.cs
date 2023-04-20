using GokboerueTools.MapGenerator;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GokboerueTools.MapGenerator
{
    public class PlayerStepUpOnGeneratedMap : MonoBehaviour
    {
        [SerializeField] private MapGenerator _mapGenerator;
        List<MapObject> moveableMapObjects = new List<MapObject>();

        private Vector3 targetPosition;
        public MapObject currentMapObject;

        private void OnEnable()
        {
            moveableMapObjects = _mapGenerator.GetStartRooms();
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
                            targetPosition = mapObject.transform.position;
                            currentMapObject = mapObject;
                            moveableMapObjects = mapObject._connectedMapObjects;
                        }
                    }
                }
            }

            if (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, 5 * Time.deltaTime);
            }

            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, transform.position.y + 7, Camera.main.transform.position.z);
        }
    }
}