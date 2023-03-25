using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;

public class GameAssets : MonoBehaviour
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

    [System.Serializable]
    public class PrefabAsset
    {
        public string name;
        public Transform prefab;
    }

    public static Transform GetPrefabAsset(string name)
    {
        return GetAllPrefabAssets().FirstOrDefault(x => x.name == name).prefab;
    }

    public static List<PrefabAsset> GetAllPrefabAssets()
    {
        List<PrefabAsset> assets = new List<PrefabAsset>();
        FieldInfo[] fields = typeof(GameAssets).GetFields(BindingFlags.Public | BindingFlags.Instance);
        foreach (FieldInfo field in fields)
        {
            if (field.FieldType == typeof(PrefabAsset))
            {
                PrefabAsset asset = (PrefabAsset)field.GetValue(i);
                assets.Add(asset);
            }
        }
        return assets;
    }

    [Header("Prefabs")]
    public PrefabAsset popupText;
    public PrefabAsset bullet;
    public PrefabAsset enemy;

    public static class PrefabNames
    {
        public static string PopupText = "PopupText";
        public static string Bullet = "Bullet";
        public static string Enemy = "Enemy";
    }
    #endregion


    #region Pooler Manager
    public static Dictionary<string, Queue<GameObject>> pool = new Dictionary<string, Queue<GameObject>>();
    public static GameObject GetObjectFromPool(string name, Vector3 position, Quaternion rotation)
    {
        if (!pool.ContainsKey(name))
        {
            pool.Add(name, new Queue<GameObject>());
        }

        if (pool[name].Count == 0)
        {
            GameObject obj = Instantiate(GetPrefabAsset(name).gameObject, position, rotation);

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
    public static void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
        pool[obj.name].Enqueue(obj);
    }
    #endregion
}