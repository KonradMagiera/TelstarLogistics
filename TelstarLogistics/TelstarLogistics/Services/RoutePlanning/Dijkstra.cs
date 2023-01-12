using TelstarLogistics.Data;
using TelstarLogistics.Models;
using Route = TelstarLogistics.Models.Route;

namespace TelstarLogistics.Services.RoutePlanning;

public class Dijkstra
{
    private Dictionary<int,int> cityIdToGraphIdx;
    private int[,] graph;
    private List<City> cities;


    //public string TEST(string from, string to)
    //{
    //    //var search = new Dijkstra();
    //    //var distance = search.GetRoute(from.ToLower(), to.ToLower(), out var path);

    //    //string output = ($"distance:{distance} \n");
    //    //foreach (var city in path)
    //    //{
    //    //    output += ($"{city} -> ");
    //    //}

    //    //return output;
    //}


    public int GetRoute(string? from, string? to, bool reccommended, out List<string> path)
    {
        graph = CreateGraph(reccommended);
        var fromCity = cities.FirstOrDefault(city => city.Name == from);
        var toCity = cities.FirstOrDefault(city => city.Name == to);
        if (cityIdToGraphIdx.TryGetValue(fromCity.CityId,out int fromIdx) && cityIdToGraphIdx.TryGetValue(toCity.CityId, out int toIdx))
        {
            var distances = ComputePaths(graph, fromIdx, out var parents);
            path = GetPath(toIdx, parents).Select(id => cities[id].Name).ToList();
            return distances[toIdx];
        }

        path = new List<string>() { "no" };
        return -1;
    }



    private int[,] CreateGraph(bool recommended)
    {
        var context = new TelstarLogisticsContext();

        cities = context.Cities.ToList();
        cityIdToGraphIdx = cities.ToDictionary(city => city.CityId, city => cities.IndexOf(city));

        var graph = new int[cities.Count, cities.Count];

        var routes = recommended ? context.Routes.Where(route => route.TransportType == "car").ToList() : context.Routes.ToList();

        for (int i = 0; i < routes.Count; i++)
        {
            var route = routes[i];

            var city1 = cityIdToGraphIdx[route.City1Id];
            var city2 = cityIdToGraphIdx[route.City2Id];

            graph[city1, city2] = route.Distance;
            graph[city2, city2] = route.Distance;
        }

        return graph;
    }

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
        List<int> path = RetracePath(endVertex, parents);
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