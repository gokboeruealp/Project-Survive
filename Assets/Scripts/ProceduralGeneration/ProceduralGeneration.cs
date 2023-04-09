using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ProceduralGeneration : MonoBehaviour
{
    public GameObject nodePrefab;
    public float radius = 5f;
    public Vector2 sampleRegionSize = new Vector2(20, 20);
    public int numSamplesBeforeRejection = 30;

    private List<Vector2> points = new List<Vector2>();
    public List<Node> nodes = new List<Node>();

    private void Start()
    {
        GenerateNodes();
        GenerateConnections();
        CalculatePath();
    }

    private void GenerateNodes()
    {
        points = PoissonDiscSampling.GeneratePoints(radius, sampleRegionSize, numSamplesBeforeRejection);
        foreach (Vector2 point in points)
        {
            Node node = Instantiate(nodePrefab, new Vector2(point.x, point.y), Quaternion.identity).GetComponent<Node>();
            nodes.Add(node);
        }
    }

    private void GenerateConnections()
    {
        foreach (Node node in nodes)
        {
            List<Node> neighbours = GetNeighbours(node);
            foreach (Node neighbour in neighbours)
            {
                node.GetComponent<Node>().AddNeighbor(neighbour);
            }
        }
    }

    private List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();
        foreach (Node otherNode in nodes)
        {
            if (otherNode != node)
            {
                if (Vector2.Distance(node.transform.position, otherNode.transform.position) <= 2)
                {
                    neighbours.Add(otherNode);
                }
            }
        }
        return neighbours;
    }

    public void CalculatePath()
    {
        Node[] lowestNodes = new Node[4];
        Node highestNode = null;
        List<Node> path = new List<Node>();

        List<Node> sortedNodes = nodes.OrderBy(node => node.transform.position.y).ToList();

        for (int i = 0; i < 4; i++)
        {
            lowestNodes[i] = sortedNodes[i];
        }

        highestNode = sortedNodes[sortedNodes.Count - 1];

        foreach (Node lowestNode in lowestNodes)
        {
            path.AddRange(AStar.FindPath(lowestNode, highestNode));
        }

        foreach (var item in path)
        {
            item.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.yellow;
        }

        DestroyOtherNodes(lowestNodes, path, highestNode);

        foreach (var node in nodes)
        {
            node.Init();
        }
    }

    void DestroyOtherNodes(Node[] lowestNodes, List<Node> path, Node highestNode)
    {
        List<Node> notDestroyNodes = new List<Node>();
        notDestroyNodes.AddRange(lowestNodes);
        notDestroyNodes.AddRange(path);
        notDestroyNodes.Add(highestNode);

        foreach (var node in nodes)
        {
            if (!notDestroyNodes.Contains(node))
            {
                Destroy(node.gameObject);
            }
        }
    }
}