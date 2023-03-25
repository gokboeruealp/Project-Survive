using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gokboerue : MonoBehaviour
{
    public static Vector2 G_GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public static void CreatePopupText(Vector2 position, string text)
    {
        PopupTextScript.Create(Gokboerue.G_GetMousePosition(), text, Color.white);
    }

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
}
