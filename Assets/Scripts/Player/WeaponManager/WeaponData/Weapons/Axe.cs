using GokboerueTools;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Axe", menuName = "Weapons/Axe", order = 0)]
[System.Serializable]
public class Axe : WeaponObject
{
    public float axeRange;
    public float duration = 1f;

    private float time = 0f;
    
    public override void Attack() { }
    public override void Attack(GameObject Axe) { }
    public override void Attack(GameObject Axe, Transform Player)
    {
        Vector3 playerPos = Player.transform.position;
        Player player = Player.gameObject.GetComponent<Player>();

        Vector3 startPoint = new Vector3(playerPos.x, playerPos.y + axeRange, playerPos.z);
        Vector3 midPoint = new Vector3(playerPos.x + (axeRange * 2), playerPos.y, playerPos.z);
        midPoint = player.body.flipX ? new Vector3(playerPos.x - (axeRange * 2), playerPos.y, playerPos.z) : midPoint;
        Vector3 endPoint = new Vector3(playerPos.x, playerPos.y - axeRange, playerPos.z);
        
        Vector3[] points = new Vector3[] { startPoint, midPoint, endPoint };

        time += Time.deltaTime / duration;
        if (time > 1f)
        {
            time = 0f;
        }

        Axe.transform.position = Gokboerue.GetBezierPoint(points, time);
    }
    public override IEnumerator AttackCoroutine(GameObject Axe, Transform Player)
    {
        Player player = Player.gameObject.GetComponent<Player>();

        Vector3 startPoint = new Vector3(Player.transform.position.x, Player.transform.position.y + axeRange, Player.transform.position.z);
        Vector3 midPoint = new Vector3(Player.transform.position.x + (axeRange * 2), Player.transform.position.y, Player.transform.position.z);
        midPoint = player.body.flipX ? new Vector3(Player.transform.position.x - (axeRange * 2), Player.transform.position.y, Player.transform.position.z) : midPoint;
        Vector3 endPoint = new Vector3(Player.transform.position.x, Player.transform.position.y - axeRange, Player.transform.position.z);

        Vector3[] points = new Vector3[] { startPoint, midPoint, endPoint };

        float time = 0f;
        bool attackInProgress = true;
        while (attackInProgress)
        {
            time += Time.deltaTime / duration;
            if (time > 1f)
            {
                attackInProgress = false;
            }

            Axe.transform.position = Gokboerue.GetBezierPoint(points, time);

            // Her döngüde bir sonraki adýma geçmek için yield return null kullanýyoruz.
            yield return null;
        }

        Axe.transform.position = Player.transform.position;
    }
}
