namespace TelstarLogistics.Services.RoutePlanning;

public class DijkstraGraph
{
    private Dictionary<int, int> GraphIdxToCityId;
    private int[,] graph;

    private int[,] CreateGraph()
    {
        //get from -> to
        //get all cities
        //get connections to all other cities
        int cityCount = 3;
        //map city to int

        var graph = new int[cityCount, cityCount];
        //iterate all connections

        return graph;

    }
}