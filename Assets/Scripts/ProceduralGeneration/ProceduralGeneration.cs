using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        Invoke("GenerateNodes", 2f);
        Invoke("GenerateConnections", 2f);
        Invoke("CalculatePath", 2f);
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
        // En düþük 4 düðümü ve en yüksek düðümü saklamak için bir dizi oluþturun.
        Node[] lowestNodes = new Node[4];
        Node highestNode = null;

        // PoissonDiscSampling kullanarak bir düðüm aðý oluþturun.

        // Düðümleri y ekseninde sýralayýn.
        List<Node> sortedNodes = nodes.OrderBy(node => node.transform.position.y).ToList();

        // En düþük 4 düðümü seçin.
        for (int i = 0; i < 4; i++)
        {
            lowestNodes[i] = sortedNodes[i];
        }

        // En yüksek düðümü seçin.
        highestNode = sortedNodes[sortedNodes.Count - 1];

        // Her bir en düþük düðümle en yüksek düðüm arasýnda yollar (path) oluþturun.
        foreach (Node lowestNode in lowestNodes)
        {
            List<Node> path = CalculatePath(lowestNode, highestNode);

            foreach (var node in path)
            {
                node.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.yellow;
            }
        }

        foreach (var lowestNode in lowestNodes)
        {
            lowestNode.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.green;
        }

        highestNode.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.blue;
    }

    // Ýki düðüm arasýndaki yolu hesaplamak için bir fonksiyon oluþturun.
    List<Node> CalculatePath(Node startNode, Node endNode)
    {
        // A* algoritmasýný kullanarak en kýsa yolun düðümlerini hesaplayýn.
        List<Node> path = AStar.FindPath(startNode, endNode);

        // En kýsa yolun düðümlerini döndürün.
        return path;
    }
}