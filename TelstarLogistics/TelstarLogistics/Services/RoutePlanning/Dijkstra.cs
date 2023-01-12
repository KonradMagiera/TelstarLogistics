using TelstarLogistics.Data;
using TelstarLogistics.Models;
using Route = TelstarLogistics.Models.Route;

namespace TelstarLogistics.Services.RoutePlanning;

public class Dijkstra
{
    private Dictionary<int,int> cityIdToGraphIdx;
    private (int, string)[,] graph;
    private List<City> cities;


    public string TEST(string from, string to)
    {
        var search = new Dijkstra();
        var distance = search.GetRoute(from.ToLower(), to.ToLower(),false, out var path);

        string output = ($"distance:{distance} \n");
        foreach (var city in path)
        {
            output += ($"{city} -> ");
        }

        return output;
    }


    public int GetRoute(string? from, string? to, bool reccommended, out List<string> path)
    {
        graph = CreateGraph(reccommended);
        var fromCity = cities.FirstOrDefault(city => city.Name == from);
        var toCity = cities.FirstOrDefault(city => city.Name == to);
        if (cityIdToGraphIdx.TryGetValue(fromCity.CityId,out int fromIdx) && cityIdToGraphIdx.TryGetValue(toCity.CityId, out int toIdx))
        {
            var distances = ComputePaths(graph, fromIdx, out var parents, out var transportTypes, out int[] carDistance);
            path = GetPath(toIdx, parents, transportTypes).Select(pathnode => $"{pathnode.Item2},{cities[pathnode.Item1].Name}").ToList();
            return carDistance[toIdx];
        }

        path = new List<string>() { "no" };
        return -1;
    }

    private (int, string)[,] CreateGraph(bool recommended)
    {
        var context = new TelstarLogisticsContext();

        cities = context.Cities.ToList();
        //cities = new List<City>
        //{
        //    new City
        //    {
        //        Name = "c1",
        //        CityId = 1
        //    },
        //    new City
        //    {
        //        Name = "c2",
        //        CityId = 2
        //    },
        //    new City
        //    {
        //        Name = "c3",
        //        CityId = 3
        //    },
        //    new City
        //    {
        //        Name = "c4",
        //        CityId = 4
        //    },
        //    new City
        //    {
        //        Name = "c0",
        //        CityId = 0
        //    },
        //    new City
        //    {
        //        Name = "c5",
        //        CityId = 5
        //    },
        //};
        cityIdToGraphIdx = cities.ToDictionary(city => city.CityId, city => cities.IndexOf(city));

        var graph = new (int, string)[cities.Count, cities.Count];

        var routes = recommended ? context.Routes.Where(route => route.TransportType == "car").ToList() : context.Routes.ToList();
        //var routes = new List<Route>
        //{
        //    new Route
        //    {
        //        City1Id = 1,
        //        City2Id = 2,
        //        Distance = 10,
        //        TransportType = "car"
        //    },
        //    new Route
        //    {
        //        City1Id = 2,
        //        City2Id = 3,
        //        Distance = 10,
        //        TransportType = "car"
        //    },
        //    new Route
        //    {
        //        City1Id = 3,
        //        City2Id = 4,
        //        Distance = 10,
        //        TransportType = "car"
        //    },
        //    new Route
        //    {
        //        City1Id = 4,
        //        City2Id = 1,
        //        Distance = 10,
        //        TransportType = "car"
        //    },
        //    new Route
        //    {
        //        City1Id = 1,
        //        City2Id = 3,
        //        Distance = 1,
        //        TransportType = "plane"
        //    },
        //    new Route
        //    {
        //        City1Id = 0,
        //        City2Id = 1,
        //        Distance = 5,
        //        TransportType = "car"
        //    },
        //    new Route
        //    {
        //        City1Id = 3,
        //        City2Id = 5,
        //        Distance = 5,
        //        TransportType = "car"
        //    },
        //    new Route
        //    {
        //        City1Id = 0,
        //        City2Id = 5,
        //        Distance = 20,
        //        TransportType = "boat"
        //    },

        //};

        for (int i = 0; i < routes.Count; i++)
        {
            var route = routes[i];

            var city1 = cityIdToGraphIdx[route.City1Id];
            var city2 = cityIdToGraphIdx[route.City2Id];

            if (graph[city1, city2].Item2 == "car")
            {
                continue;
            }

            graph[city1, city2] = (route.Distance, route.TransportType);
            graph[city2, city1] = (route.Distance, route.TransportType);
        }

        return graph;
    }

    public static int[] ComputePaths((int, string)[,] graph, int sourceNode, out int[] parent, out string[] TransportType, out int[] carDistance)
    {
        int n = graph.GetLength(0);
        int[] distance = new int[n];
        bool[] visited = new bool[n];
        carDistance = new int[n];
        TransportType = new string[n];
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
                if (!visited[j] && graph[minDistanceNode, j].Item1 != 0 && distance[minDistanceNode] != int.MaxValue && distance[minDistanceNode] + graph[minDistanceNode, j].Item1 < distance[j])
                {
                    distance[j] = distance[minDistanceNode] + graph[minDistanceNode, j].Item1;
                    int cardist = graph[minDistanceNode, j].Item2 == "car" ? graph[minDistanceNode, j].Item1 : 0;
                    carDistance[j] = carDistance[minDistanceNode] + cardist;
                    parent[j] = minDistanceNode;
                    TransportType[j] = graph[minDistanceNode, j].Item2;
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

    public static List<(int, string)> GetPath(int endVertex, int[] parents, string[] TransportTypes)
    {
        List<(int, string)> path = RetracePath(endVertex, parents, TransportTypes);
        path.Reverse();
        return path;
    }

    public static List<(int, string)> RetracePath(int endVertex, int[] parents, string[] TransportTypes)
    {
        if (endVertex < 0 || endVertex > parents.Length) throw new ArgumentOutOfRangeException(nameof(endVertex));

        var path = new List<(int, string)>();

        int count = 0; //loop failsafe
        int idx = endVertex; //move from end index towards start
        while (parents[idx] >= 0 && count < parents.Length)
        {
            path.Add((idx, TransportTypes[idx]));
            idx = parents[idx];
            count++;
        }
        path.Add((idx, ""));

        return path;
    }
}