using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace GokboerueTools.MapGenerator
{
    public class MapTimeline : MonoBehaviour
    {
        [SerializeField] private MapGenerator mapGenerator;
        [SerializeField] private PlayerStepUpOnGeneratedMap playerStepUpOnGeneratedMap;

        private GameObject mainCamera;

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
        private float GetRightLeftMapObjectX(bool isRight)
        {
            List<MapObject> mapObjects = mapGenerator.GetMapObjects();

            var leftmostMapObject = mapObjects[0];
            foreach (var mapObject in mapObjects)
            {
                if (isRight)
                {
                    if (mapObject.transform.position.x > leftmostMapObject.transform.position.x)
                    {
                        leftmostMapObject = mapObject;
                    }
                }
                else
                {
                    if (mapObject.transform.position.x < leftmostMapObject.transform.position.x)
                    {
                        leftmostMapObject = mapObject;
                    }
                }
            }

            return leftmostMapObject.transform.position.x;
        }
        private float GetMiddleMapObjectX()
        {
            return (GetRightLeftMapObjectX(true) - GetRightLeftMapObjectX(false)) / 2;
        }

        private void Start()
        {
            Invoke("CameraTimeline", 1);
        }

        void CameraTimeline()
        {
            mainCamera = GameObject.Find("Main Camera");
            var returnPos = mainCamera.transform.position;

            mainCamera.transform.DOMove(new Vector3(GetMiddleMapObjectX(), GetTopBotmostMapObjectY(true), -10), 3);
            mainCamera.transform.DOMove(returnPos, 3)
                .OnComplete(() => { playerStepUpOnGeneratedMap.gameObject.SetActive(true); }).SetDelay(3);
        }
    }
}