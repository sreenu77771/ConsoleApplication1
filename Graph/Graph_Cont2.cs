using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Graph2
    {
        const int V = 9;
        public static void dijkstra(int[][] graph, int src)
        {
            // The output array.  dist[i] will hold the shortest
            // distance from src to i
            int[] dist = new int[V];
            // sptSet[i] will true if vertex i is included in shortest
            // path tree or shortest distance from src to i is finalized
            bool[] sptSet = new bool[V];

            for (int i = 0; i < dist.Length; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            dist[src] = 0;
            for (int j = 0; j < V - 1; j++)
            {
                //index of mindistance
                int u = minDistance(dist, sptSet);
                sptSet[u] = true;

                for (int k = 0; k < V; k++)
                {
                    if (!sptSet[k] && graph[u][k] != 0 && dist[u] != int.MaxValue && graph[u][k] + dist[u] < dist[k])
                    {
                        dist[k] = graph[u][k] + dist[u];
                    }
                }
            }

            for (int i = 0; i < V; i++)
                Console.WriteLine( i + ": " +  dist[i]);

        }

        private static int minDistance(int[] dist, bool[] sptSet)
        {
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
            {
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }
            }

            return min_index;
        }

        public static void TestGraph()
        {

            /* Let us create the example graph discussed above */
            int[][] graph = new int[V][]{new int[]{0, 4, 0, 0, 0, 0, 0, 8, 0},
                                        new int[]{4, 0, 8, 0, 0, 0, 0, 11, 0},
                                        new int[]{0, 8, 0, 7, 0, 4, 0, 0, 2},
                                        new int[]{0, 0, 7, 0, 9, 14, 0, 0, 0},
                                        new int[]{0, 0, 0, 9, 0, 10, 0, 0, 0},
                                        new int[]{0, 0, 4, 14, 10, 0, 2, 0, 0},
                                        new int[]{0, 0, 0, 0, 0, 2, 0, 1, 6},
                                        new int[]{8, 11, 0, 0, 0, 0, 1, 0, 7},
                                        new int[]{0, 0, 2, 0, 0, 0, 6, 7, 0}};
            dijkstra(graph, 0);
        }
    }
}
