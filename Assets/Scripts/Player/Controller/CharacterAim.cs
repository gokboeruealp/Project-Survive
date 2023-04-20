using GokboerueTools;
using UnityEngine;
using static GokboerueTools.GameAssets;

public class CharacterAim : MonoBehaviour
{
    #region Variables
    public Transform firePoint;
    #endregion

    #region Unity Methods
    private void Update()
    {
        OnLook();
    }
    #endregion

    #region Input Methods
    private void OnFire()
    {
        Transform bullet = GetObjectFromPool(AssetData.Bullet, firePoint.position, firePoint.rotation).transform;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * 5f, ForceMode2D.Impulse);

        GokboerueTools.Gokboerue.GetGameManager();
    }

    private void OnLook()
    {
        if (GokboerueTools.Gokboerue.IsExistEnemy())
        {
            Enemy nearestEnemy = GokboerueTools.Gokboerue.CalculateNearestEnemy(transform);
            transform.rotation = RotatePlayerHelper(nearestEnemy.transform.position);
        }
        else
        {
            transform.rotation = RotatePlayerHelper(GokboerueTools.Gokboerue.G_GetMousePosition());
        }
    }
    #endregion

    #region Helper Methods
    private Quaternion RotatePlayerHelper(Vector2 choise)
    {
        var direction = choise - (Vector2)transform.position;
        return Quaternion.LookRotation(Vector3.forward, direction);
    }
    #endregion
}