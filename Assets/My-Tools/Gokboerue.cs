using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static GokboerueTools.GameAssets;

namespace GokboerueTools
{
    public class Gokboerue : MonoBehaviour
    {
        #region Other
        public static Vector2 G_GetMousePosition()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        public static void CreatePopupText(Vector2 position, string text, Color color)
        {
            PopupTextScript.Create(G_GetMousePosition(), text, color);
        }
        #endregion

        #region Enemy Manager
        public static Enemy CalculateNearestEnemy(Transform transform)
        {
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            if (enemies.Length == 0) return null;

            Enemy nearestEnemy = null;
            float minDistance = Mathf.Infinity;
            Vector3 currentPosition = transform.position;
            foreach (Enemy enemy in enemies)
            {
                float distance = Vector3.Distance(currentPosition, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestEnemy = enemy;
                }
            }
            Debug.DrawLine(transform.position, nearestEnemy.transform.position, Color.red);
            return nearestEnemy;
        }

        public static bool IsExistEnemy()
        {
            Enemy[] enemies = FindObjectsOfType<Enemy>();

            if (enemies.Length == 0) return false;
            else return true;
        }
        #endregion

        #region Prefab Manager
        public static PrefabAsset GetPrefabAsset(string tag)
        {
            return GetGameAssets().prefabAssets.FirstOrDefault(x => x.tag == tag);
        }
        #endregion

        #region Game Manager
        public static GameManager GetGameManager()
        {
            return GameManager.i;
        }

        public static GameAssets GetGameAssets()
        {
            return i;
        }
        #endregion

        #region Delay
        public static void Delay(float delay, System.Action action)
        {
            i.StartCoroutine(DelayCoroutine(delay, action));
        }

        private static System.Collections.IEnumerator DelayCoroutine(float delay, System.Action action)
        {
            yield return new WaitForSeconds(delay);
            action();
        }

        public static void Delay(float delay, System.Action action, System.Action onEnd)
        {
            i.StartCoroutine(DelayCoroutine(delay, action, onEnd));
        }

        private static System.Collections.IEnumerator DelayCoroutine(float delay, System.Action action, System.Action onEnd)
        {
            yield return new WaitForSeconds(delay);
            action();
            onEnd();
        }

        public static void Delay(float delay, System.Action action, System.Action onEnd, System.Action onEnd2)
        {
            i.StartCoroutine(DelayCoroutine(delay, action, onEnd, onEnd2));
        }

        private static System.Collections.IEnumerator DelayCoroutine(float delay, System.Action action, System.Action onEnd, System.Action onEnd2)
        {
            yield return new WaitForSeconds(delay);
            action();
            onEnd();
            onEnd2();
        }

        public static void Delay(float delay, System.Action action, System.Action onEnd, System.Action onEnd2, System.Action onEnd3)
        {
            i.StartCoroutine(DelayCoroutine(delay, action, onEnd, onEnd2, onEnd3));
        }

        private static System.Collections.IEnumerator DelayCoroutine(float delay, System.Action action, System.Action onEnd, System.Action onEnd2, System.Action onEnd3)
        {
            yield return new WaitForSeconds(delay);
            action();
            onEnd();
            onEnd2();
            onEnd3();
        }
        #endregion

        #region Randomness
        public static int RandomInt(int min, int max)
        {
            return Random.Range(min, max);
        }

        public static float RandomFloat(float min, float max)
        {
            return Random.Range(min, max);
        }

        public static bool RandomBool()
        {
            return Random.Range(0, 2) == 0;
        }

        public static bool RandomBool(float chance)
        {
            return Random.Range(0f, 1f) < chance;
        }

        public static T RandomEnum<T>()
        {
            System.Array A = System.Enum.GetValues(typeof(T));
            T V = (T)A.GetValue(Random.Range(0, A.Length));
            return V;
        }

        public static List<T> RandomList<T>(List<T> list)
        {
            List<T> newList = new List<T>();
            while (list.Count > 0)
            {
                int index = Random.Range(0, list.Count);
                newList.Add(list[index]);
                list.RemoveAt(index);
            }
            return newList;
        }

        public static List<int> GenerateRandomUniqeList(int min, int max, int count)
        {
            List<int> list = new List<int>();
            while (list.Count < count)
            {
                int random = Random.Range(min, max);
                if (!list.Contains(random))
                {
                    list.Add(random);
                }
            }
            return list;
        }
        #endregion
    }
}