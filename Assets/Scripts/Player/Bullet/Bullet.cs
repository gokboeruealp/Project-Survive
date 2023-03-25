using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;

    [SerializeField] private float damage = 40;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        Invoke("DestroyBullet", 3f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void DestroyBullet()
    {
        GameAssets.ReturnObjectToPool(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);

            GameAssets.ReturnObjectToPool(gameObject);
        }
    }   
}
