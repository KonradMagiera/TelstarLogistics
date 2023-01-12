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

        var graph = new int[cityCount,cityCount];
        //iterate all connections

        return graph;

    }

    

    private static string printSolution(int startVertex,
        int[] distances,
        int[] parents)
    {
        string s = "";
        int nVertices = distances.Length;
        s += ("Vertex\t Distance\tPath");

        for (int vertexIndex = 0;
             vertexIndex < nVertices;
             vertexIndex++)
        {
            if (vertexIndex != startVertex)
            {
                s += ("\n" + startVertex + " -> ");
                s += (vertexIndex + " \t\t ");
                s += (distances[vertexIndex] + "\t\t");
                printPath(vertexIndex, parents, ref s);

            }
        }

        return s;
    }

    private static void printPath(int currentVertex,
        int[] parents, ref string s)
    {

        // Base case : Source node has
        // been processed
        if (currentVertex == -1)
        {
            return;
        }

        printPath(parents[currentVertex], parents, ref s);
        s += (currentVertex + " ");

    }
}