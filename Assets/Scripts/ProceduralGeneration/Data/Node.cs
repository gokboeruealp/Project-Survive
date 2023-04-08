using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Node : MonoBehaviour
{
    //A* Variables
    public float gCost;
    public float hCost;
    public float fCost { get { return gCost + hCost; } }
    public Node parent;
    public bool isWalkable = true;

    public List<Node> neighbours;
    public List<Line> lines = new List<Line>();
    public Line lineObject;
    public void AddNeighbor(Node neighbor)
    {
        if (!neighbours.Contains(neighbor))
        {
            neighbours.Add(neighbor);
            neighbor.neighbours.Add(this);
        }
    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        Invoke("DrawLines", 2f);
        Invoke("ClearCrossedLines", 2f);
        Invoke("DestroyPositionDuplicatedLines", 2f);
        Invoke("RestructuringNeighbours", 2f);
    }

    public void DrawLines()
    {
        foreach (Node neighbour in neighbours)
        {
            var newLine = Instantiate(lineObject, Vector3.zero, Quaternion.identity);
            Line line = newLine.GetComponent<Line>();
            line.SetStartAndEndNode(this, neighbour);
            line.DrawLine();

            newLine.transform.SetParent(transform);
            lines.Add(line);
        }
    }

    public void ClearCrossedLines()
    {
        List<Line> otherLines = FindObjectsOfType<Line>().ToList();
        List<Line> thisLines = GetComponentsInChildren<Line>().ToList();

        // Remove intersecting lines
        for (int i = 0; i < thisLines.Count; i++)
        {
            for (int j = 0; j < otherLines.Count; j++)
            {
                if (thisLines[i] != otherLines[j])
                {
                    if (CalculateIsIntersect(thisLines[i], otherLines[j]))
                    {
                        Destroy(thisLines[i].gameObject);
                    }
                }
            }
        }
    }

    public void RestructuringNeighbours()
    {
        neighbours.Clear();
        List<Line> thisLines = GetComponentsInChildren<Line>().ToList();
        foreach (Line line in thisLines)
        {
            if (line.endNode != this)
            {
                neighbours.Add(line.endNode);
            }
            else
            {
                neighbours.Add(line.startNode);
            }
        }
    }

    public void DestroyPositionDuplicatedLines()
    {
        float epsilon = 0.0001f;

        List<Line> otherLines = FindObjectsOfType<Line>().ToList();
        List<Line> thisLines = GetComponentsInChildren<Line>().ToList();

        foreach (Line thisLine in thisLines)
        {
            foreach (Line otherLine in otherLines)
            {
                if (thisLine != otherLine)
                {
                    bool intersectedStartNode = Vector3.Distance(thisLine.startNode.transform.position, otherLine.startNode.transform.position) <= epsilon;
                    bool intersectedEndNode = Vector3.Distance(thisLine.endNode.transform.position, otherLine.endNode.transform.position) <= epsilon;
                    bool intersectedStartNodeOtherEndNode = Vector3.Distance(thisLine.startNode.transform.position, otherLine.endNode.transform.position) <= epsilon;
                    bool intersectedEndNodeOtherStartNode = Vector3.Distance(thisLine.endNode.transform.position, otherLine.startNode.transform.position) <= epsilon;

                    if ((intersectedStartNode && intersectedEndNode) || (intersectedStartNodeOtherEndNode && intersectedEndNodeOtherStartNode))
                    {
                        Destroy(thisLine.gameObject);
                        break;
                    }
                }
            }
        }
    }

    public bool CalculateIsIntersect(Line thisLine, Line otherLine)
    {
        // Get the start and end points of both lines
        Vector2 a1 = thisLine.GetComponent<LineRenderer>().GetPosition(0);
        Vector2 a2 = thisLine.GetComponent<LineRenderer>().GetPosition(1);
        Vector2 b1 = otherLine.GetComponent<LineRenderer>().GetPosition(0);
        Vector2 b2 = otherLine.GetComponent<LineRenderer>().GetPosition(1);

        // If any of the start or end points are the same, consider the lines intersecting
        if (a1 == b1 || a1 == b2 || a2 == b1 || a2 == b2)
        {
            return false;
        }

        // Otherwise, calculate if the lines intersect
        float denominator = ((b2.y - b1.y) * (a2.x - a1.x)) - ((b2.x - b1.x) * (a2.y - a1.y));
        float numerator1 = ((b2.x - b1.x) * (a1.y - b1.y)) - ((b2.y - b1.y) * (a1.x - b1.x));
        float numerator2 = ((a2.x - a1.x) * (a1.y - b1.y)) - ((a2.y - a1.y) * (a1.x - b1.x));

        // If the denominator is zero, the lines are parallel and don't intersect
        if (denominator == 0f)
        {
            return false;
        }

        // Calculate the parameters r and s to determine if the lines intersect
        float r = numerator1 / denominator;
        float s = numerator2 / denominator;

        // If r or s are outside of the [0, 1] range, the lines don't intersect
        if (r < 0 || r > 1 || s < 0 || s > 1)
        {
            return false;
        }

        // Otherwise, the lines intersect
        return true;
    }
}