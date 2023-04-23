using UnityEngine;

[CreateAssetMenu(fileName = "New Axe", menuName = "Weapons/Axe", order = 0)]
[System.Serializable]
public class Axe : WeaponObject
{
    public float axeRange;
    private float time = 0f;
    public float duration = 1f;

    Transform handle, axeEndPoint;

    public override void Attack() { }
    public override void Attack(GameObject Axe) { }
    public override void Attack(GameObject Axe, GameObject Player)
    {
        Vector3 startPoint = new Vector3(0, axeRange, 0);
        Vector3 midPoint = new Vector3(axeRange * 2, 0, 0);
        Vector3 endPoint = new Vector3(0, -axeRange, 0);
        Vector3[] points = new Vector3[] { startPoint, midPoint, endPoint };

        time += Time.deltaTime / duration;
        if (time > 1f)
        {
            time = 0f;
        }

        Axe.transform.position = GetBezierPoint(points, time);

        handle = Player.transform.GetChild(0).GetChild(0);
        axeEndPoint = Player.transform.GetChild(0).GetChild(1);

        Vector3 targetDirection = handle.position - axeEndPoint.position;
        float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        Axe.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, targetAngle));
    }

    Vector3 GetBezierPoint(Vector3[] points, float t)
    {
        Vector3 p = Vector3.zero;

        for (int i = 0; i < points.Length; i++)
        {
            p += Mathf.Pow(1 - t, points.Length - i - 1) * Mathf.Pow(t, i) * GetBinomialCoefficient(points.Length - 1, i) * points[i];
        }

        return p;
    }

    int GetBinomialCoefficient(int n, int k)
    {
        int ret = 1;

        if (k > n - k)
        {
            k = n - k;
        }

        for (int i = 1; i <= k; i++)
        {
            ret *= n - k + i;
            ret /= i;
        }

        return ret;
    }
}
