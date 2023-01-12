using System.Reflection.Metadata.Ecma335;

namespace TelstarLogistics.Services.RoutePlanning;

public class Dijkstra
{
    public static int[] ComputePaths(int[,] graph, int sourceNode, out int[] parent)
    {

        int n = graph.GetLength(0);
        int[] distance = new int[n];
        bool[] visited = new bool[n];
        parent = new int[n];


        for (int i = 0; i < n; i++)
        {
            distance[i] = int.MaxValue;
        }
        distance[sourceNode] = 0;
        parent[sourceNode] = -1;


        for (int i = 0; i < n - 1; i++)
        {
            int minDistanceNode = MinimumDistanceNode(distance, visited);
            visited[minDistanceNode] = true;



            for (int j = 0; j < n; j++)
            {
                if (!visited[j] && graph[minDistanceNode, j] != 0 && distance[minDistanceNode] != int.MaxValue && distance[minDistanceNode] + graph[minDistanceNode, j] < distance[j])
                {
                    distance[j] = distance[minDistanceNode] + graph[minDistanceNode, j];
                    parent[j] = minDistanceNode;
                }
            }
        }
        return distance;
    }



    static int MinimumDistanceNode(int[] distance, bool[] visited)
    {
        int min = int.MaxValue;
        int minIndex = -1;


        for (int i = 0; i < distance.Length; i++)
        {
            if (!visited[i] && distance[i] <= min)
            {
                min = distance[i];
                minIndex = i;
            }
        }
        return minIndex;
    }

    public static List<int> GetPath(int endVertex, int[] parents)
    {
        var path = RetracePath(endVertex, parents);
        path.Reverse();
        return path;
    }

    public static List<int> RetracePath(int endVertex, int[] parents)
    {
        if (endVertex < 0 || endVertex > parents.Length) throw new ArgumentOutOfRangeException(nameof(endVertex));

        var path = new List<int>();

        int count = 0; //loop failsafe
        int idx = endVertex; //move from end index towards start
        while (parents[idx] >= 0 && count < parents.Length)
        {
            path.Add(idx);
            idx = parents[idx];
            count++;
        }
        path.Add(idx);

        return path;
    }
}