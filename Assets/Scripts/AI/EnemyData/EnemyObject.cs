using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyObject : ScriptableObject
{
    public string enemyName;
    public int health;
    public int damage;
    public float speed;
    public float attackSpeed;
    public float attackRange;
    public float detectionRange;
    public float attackDelay;
    public float attackDuration;
    public float attackCooldown;
    public float attackCooldownDuration;
    public float attackCooldownDelay;

    public GameObject enemyPrefab;
    public GameObject deathEffect;
    public GameObject hitEffect;
    public GameObject attackEffect;

    public Sprite enemySprite;
    public Sprite deathSprite;

    public AudioClip deathSound;
    public AudioClip hitSound;
    public AudioClip attackSound;
}