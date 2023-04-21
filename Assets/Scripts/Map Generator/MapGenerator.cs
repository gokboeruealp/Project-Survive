using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace GokboerueTools.MapGenerator
{
    public class MapGenerator : MonoBehaviour
    {
        #region Variables
        [SerializeField] private int xCount = 10;
        [SerializeField] private int yCount = 30;

        [Range(1, 7)][SerializeField] private int startRoomCount = 4;

        [SerializeField] private GameObject emptyRoomObject;
        [SerializeField] private GameObject roadObject;
        
        private List<MapObject> _mapObjects;
        #endregion

        #region Variable Getter Setter Methods
        public List<MapObject> GetMapObjects()
        {
            return _mapObjects;
        }

        public List<MapObject> GetStartRooms()
        {
            return _mapObjects.Where(mapObject => mapObject._type == EMapObjectType.StartRoom).ToList();
        }
        #endregion

        #region Unity Methods
        private void Start()
        {
            Generate();
        }
        #endregion

        #region Methods
        private void Generate()
        {
            ClearMap();
            CreateRooms();
            SelectStartRooms();
            SelectRoads();
            DestroyNoneRoom();
            RemoveNullMapObjects();
        }

        private void ClearMap()
        {
            _mapObjects = new List<MapObject>();
            var tempList = transform.Cast<Transform>().ToList();
            foreach (var child in tempList)
            {
                DestroyImmediate(child.gameObject);
            }
        }

        private void CreateRooms()
        {
            _mapObjects = new List<MapObject>();
            for (int y = 0; y < yCount; y++)
            {
                for (int x = 0; x < xCount; x++)
                {
                    MapObject mapObject = new MapObject(EMapObjectType.None, new GridNode(x, y));
                    var emptyGameObject = Instantiate(emptyRoomObject, new Vector2(mapObject._gridNode.x, mapObject._gridNode.y), Quaternion.identity, transform);
                    emptyGameObject.GetComponent<MapObject>()._gridNode = mapObject._gridNode;
                    emptyGameObject.name = $"{mapObject._type}:{x}:{y}";

                    _mapObjects.Add(emptyGameObject.GetComponent<MapObject>());
                }
            }
        }

        private void SelectStartRooms()
        {
            var startRooms = Gokboerue.GenerateRandomUniqeList(0, xCount, startRoomCount);

            foreach (var startRoom in startRooms)
            {
                var startRoomObject = _mapObjects.Where(x => x._gridNode.y == 0).FirstOrDefault(x => x._gridNode.x == startRoom);
                startRoomObject.name = $"{EMapObjectType.StartRoom}:{startRoomObject._gridNode.x}:{startRoomObject._gridNode.y}";

                startRoomObject.GetComponent<MapObject>()._type = EMapObjectType.StartRoom;
                startRoomObject.GetComponent<SpriteRenderer>().color = Color.red;
            }



        }

        private void SelectRoads()
        {
            var startRooms = _mapObjects.Where(x => x._type == EMapObjectType.StartRoom).ToList();
            var bossRoom = _mapObjects.FirstOrDefault(x => x._type == EMapObjectType.Boss);
            int bossY = yCount - 1;

            foreach (var startRoom in startRooms)
            {
                GridNode currentRoom = new GridNode(startRoom._gridNode.x, startRoom._gridNode.y);
                GridNode previousRoom = new GridNode(startRoom._gridNode.x, startRoom._gridNode.y);

                while (currentRoom.y < bossY)
                {
                    GridNode nextRoom = CalculateRandomNextRoom(currentRoom);

                    var selectedRoom = _mapObjects.FirstOrDefault(x => x._gridNode.x == nextRoom.x && x._gridNode.y == nextRoom.y);
                    selectedRoom.name = $"{EMapObjectType.Road}:{selectedRoom._gridNode.x}:{selectedRoom._gridNode.y}";
                    selectedRoom.GetComponent<MapObject>()._type = EMapObjectType.Road;
                    selectedRoom.GetComponent<SpriteRenderer>().color = Color.green;

                    if (selectedRoom != null)
                    {
                        var lineObject = Instantiate(roadObject, selectedRoom.transform.position, Quaternion.identity, transform);
                        var lineRenderer = lineObject.GetComponent<LineRenderer>();

                        lineRenderer.startColor = Color.white;
                        lineRenderer.endColor = Color.white;
                        lineRenderer.startWidth = 0.05f;
                        lineRenderer.endWidth = 0.05f;
                        lineRenderer.positionCount = 2;
                        lineRenderer.useWorldSpace = true;

                        var previousRoomObject = _mapObjects.FirstOrDefault(x => x._gridNode.x == previousRoom.x && x._gridNode.y == previousRoom.y);
                        lineRenderer.SetPosition(0, previousRoomObject.transform.position);
                        lineRenderer.SetPosition(1, selectedRoom.transform.position);

                        previousRoomObject.AddConnectedMapObject(selectedRoom);
                    }

                    previousRoom = selectedRoom._gridNode;
                    currentRoom = nextRoom;
                }
            }
        }

        private GridNode CalculateRandomNextRoom(GridNode currentRoomGrid)
        {
            var nextRoomGrid = currentRoomGrid;
            nextRoomGrid.y++;
            if (currentRoomGrid.x == 0)
            {
                var isRight = Gokboerue.RandomBool();
                if (isRight)
                {
                    nextRoomGrid.x++;
                }
            }
            else if (currentRoomGrid.x == xCount - 1)
            {
                var isRight = Gokboerue.RandomBool();
                if (!isRight)
                {
                    nextRoomGrid.x--;
                }
            }
            else
            {
                var isRight = Gokboerue.RandomBool();
                if (isRight)
                {
                    nextRoomGrid.x++;
                }
                else
                {
                    nextRoomGrid.x--;
                }
            }

            return nextRoomGrid;
        }

        private void DestroyNoneRoom()
        {
            var noneRooms = _mapObjects.Where(x => x._type == EMapObjectType.None).ToList();
            foreach (var noneRoom in noneRooms)
            {
                DestroyImmediate(noneRoom.gameObject);
            }
        }

        private void RemoveNullMapObjects()
        {
            _mapObjects.RemoveAll(x => x == null);
        }
        #endregion

        #region Editor
        internal void DrawMapInEditor()
        {
            Generate();
        }

        internal void ClearMapInEditor()
        {
            ClearMap();
        }
        #endregion

        #region Test
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Generate();
            }
        }
        #endregion
    }
}
