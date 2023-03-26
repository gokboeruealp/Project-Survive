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
    }
}