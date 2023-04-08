using UnityEngine;

public class Line : MonoBehaviour
{
    public Node startNode;
    public Node endNode;
    public LineRenderer lineRenderer;
    public void DrawLine()
    {
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startNode.transform.position);
        lineRenderer.SetPosition(1, endNode.transform.position);
    }

    public void SetStartAndEndNode(Node startNode, Node endNode)
    {
        this.startNode = startNode;
        this.endNode = endNode;
    }
}