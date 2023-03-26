using System.Collections.Generic;
using UnityEngine;

namespace GokboerueTools
{
    [System.Serializable]
    public class GameAssets : MonoBehaviour, IManager
    {
        #region Prefab Manager
        private static GameAssets _i;
        public static GameAssets i
        {
            get
            {
                if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
                return _i;
            }
        }

        public void Initialize()
        {
            Debug.Log("GameAssets Initialized");

            DontDestroyOnLoad(gameObject);
        }

        [System.Serializable]
        public class PrefabAsset
        {
            public string tag;
            public Transform prefab;
            public EAssetType assetType;
            public bool isPool;
        }
        public enum EAssetType
        {
            Prefab,
            AudioClip,
            Sprite,
            Material,
            Texture,
            ScriptableObject
        }

        [Header("Prefabs")]
        public string AssetFileName = "AssetData";
        public List<PrefabAsset> prefabAssets = new List<PrefabAsset>();
        #endregion

        #region Editor        
        public void GenerateAssetData()
        {
            string path = UnityEditor.EditorUtility.SaveFilePanel("Save AssetData", "", AssetFileName, "cs");
            if (!string.IsNullOrEmpty(path))
            {
                string assetData = "namespace GokboerueTools\n{\n\tinternal class AssetData\n\t{\n";

                foreach (PrefabAsset prefabAsset in prefabAssets)
                {
                    string variableName = prefabAsset.prefab.name.Replace(" ", "");
                    assetData += "\t\tpublic static string " + variableName + " = \"" + prefabAsset.prefab.name + "\";\n";
                }

                assetData += "\t}\n}";
                System.IO.File.WriteAllText(path, assetData);

                Debug.Log(AssetFileName + " Created");
            }
            else
            {
                Debug.LogWarning(AssetFileName + " Not Created");
            }
        }
        #endregion

        #region Unity Methods
        private void Awake()
        {
            Initialize();
        }
        #endregion

        #region Pooler Manager
        public static Dictionary<string, Queue<GameObject>> pool = new Dictionary<string, Queue<GameObject>>();
        public static GameObject GetObjectFromPool(string name, Vector3 position, Quaternion rotation)
        {
            var asset = Gokboerue.GetPrefabAsset(name);
            if (asset.isPool)
            {
                if (!pool.ContainsKey(name))
                {
                    pool.Add(name, new Queue<GameObject>());
                }

                if (pool[name].Count == 0)
                {
                    GameObject obj = Instantiate(Gokboerue.GetPrefabAsset(name).prefab.gameObject, position, rotation);

                    SetTransformForPool(obj.transform, name);

                    obj.name = name;
                    return obj;
                }
                else
                {
                    GameObject obj = pool[name].Dequeue();
                    obj.transform.position = position;
                    obj.transform.rotation = rotation;
                    obj.SetActive(true);
                    return obj;
                }
            }
            else
            {
                GameObject obj = Instantiate(Gokboerue.GetPrefabAsset(name).prefab.gameObject, position, rotation);
                obj.name = name;
                return obj;
            }
        }

        public static void ReturnObjectToPool(GameObject obj)
        {
            if (Gokboerue.GetPrefabAsset(obj.name).isPool)
            {
                obj.SetActive(false);
                pool[obj.name].Enqueue(obj);
            }
            else
            {
                Destroy(obj);
            }
        }

        public static void ClearPool()
        {
            pool.Clear();
        }

        private static void SetTransformForPool(Transform obj, string name)
        {
            if (i.transform.Find(name) != null)
            {
                obj.transform.SetParent(i.transform.Find(name));
            }
            else
            {
                GameObject parent = new GameObject(name);
                parent.transform.SetParent(i.transform);
                obj.transform.SetParent(parent.transform);
            }
        }
        #endregion
    }
}