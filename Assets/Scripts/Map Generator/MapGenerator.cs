using GokboerueTools;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int xCount = 30;
    [SerializeField] private int yCount = 70;

    [Range(10, 60)][SerializeField] private int startRoomCount = 4;

    [SerializeField] private List<MapObject> roads;
    [SerializeField] private MapObject boss;

    [SerializeField] private GameObject emptyRoomObject;
    [SerializeField] private GameObject roadObject;

    private List<MapObject> _mapObjects;

    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        ClearMap();
        CreateRooms();
        SetPositionRandomRoomsDotFive();
        SelectStartRooms();
        SelectBossRoom();
        SelectRoads();
        DestroyNoneRoom();
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

    private void SetPositionRandomRoomsDotFive()
    {
        foreach (var mapObject in _mapObjects)
        {
            mapObject.transform.position = new Vector2(mapObject._gridNode.x + Random.Range(-0.3f, 0.3f), mapObject._gridNode.y + Random.Range(-0.3f, 0.3f));
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

    private void SelectBossRoom()
    {
        var bossRoom = Random.Range(0, xCount);

        var bossRoomObject = _mapObjects.Where(x => x._gridNode.y == yCount - 1).FirstOrDefault(x => x._gridNode.x == bossRoom);
        bossRoomObject.name = $"{EMapObjectType.Boss}:{bossRoomObject._gridNode.x}:{bossRoomObject._gridNode.y}";
        bossRoomObject.GetComponent<MapObject>()._type = EMapObjectType.Boss;
        bossRoomObject.GetComponent<SpriteRenderer>().color = Color.blue;

        boss = bossRoomObject;
    }

    private void SelectRoads()
    {
        var startRooms = _mapObjects.Where(x => x._type == EMapObjectType.StartRoom).ToList();
        var bossRoom = _mapObjects.FirstOrDefault(x => x._type == EMapObjectType.Boss);
        int bossY = bossRoom._gridNode.y - 1;

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
