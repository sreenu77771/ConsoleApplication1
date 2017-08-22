using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    public class DepthFirstOrder
    {

        private bool[] marked;          // marked[v] = has v been marked in dfs?
        private int[] preArr;                 // pre[v]    = preorder  number of v
        private int[] postArr;                // post[v]   = postorder number of v
        private Queue<int> preorder;   // vertices in preorder
        private Queue<int> postorder;  // vertices in postorder
        private int preCounter;            // counter or preorder numbering
        private int postCounter;           // counter for postorder numbering

        /**
         * Determines a depth-first order for the digraph {@code G}.
         * @param G the digraph
         */

        public DepthFirstOrder(Diagraph G)
        {
            preArr = new int[G.V];
            postArr = new int[G.V];
            postorder = new Queue<int>();
            preorder = new Queue<int>();
            marked = new bool[G.V];

            for (int v = 0; v < G.V; v++)
                if (!marked[v]) dfs(G, v);
        }

        // run DFS in digraph G from vertex v and compute preorder/postorder
        private void dfs(Diagraph G, int v)
        {
            marked[v] = true;
            preArr[v] = preCounter++;
            preorder.Enqueue(v);
            foreach (int w in G.adj(v))
            {
                if (!marked[w])
                {
                    dfs(G, w);
                }
            }

            postorder.Enqueue(v);
            postArr[v] = postCounter++;
        }
       

        /**
         * Returns the preorder number of vertex {@code v}.
         * @param  v the vertex
         * @return the preorder number of vertex {@code v}
         * @throws IllegalArgumentException unless {@code 0 <= v < V}
         */

        public int pre(int v)
        {
            validateVertex(v);
            return preArr[v];
        }


        /**
         * Returns the postorder number of vertex {@code v}.
         * @param  v the vertex
         * @return the postorder number of vertex {@code v}
         * @throws IllegalArgumentException unless {@code 0 <= v < V}
         */

        public int post(int v)
        {
            validateVertex(v);
            return postArr[v];
        }



        /**
        * Returns the vertices in postorder.
         * @return the vertices in postorder, as an iterable of vertices
         */

        public IEnumerable<int> post()
        {
            return postorder;
        }



        /**
         * Returns the vertices in preorder.
         * @return the vertices in preorder, as an iterable of vertices
         */

        public IEnumerable<int> pre()
        {
            return preorder;
        }



        /**
         * Returns the vertices in reverse postorder.
         * @return the vertices in reverse postorder, as an iterable of vertices
         */

        public IEnumerable<int> reversePost()
        {
            Stack<int> reverse = new Stack<int>();
            foreach (int v in postorder)
                reverse.Push(v);
            return reverse;
        }


        private void validateVertex(int v)
        {
            int V = marked.Length;
            if (v < 0 || v >= V)
                throw new ArgumentException("vertex " + v + " is not between 0 and " + (V - 1));
        }

        /**
         * Determines a depth-first order for the edge-weighted digraph {@code G}.
         * @param G the edge-weighted digraph
         */

        //public DepthFirstOrder(EdgeWeightedDigraph G)
        //{
        //    pre = new int[G.V()];
        //    post = new int[G.V()];
        //    postorder = new Queue<Integer>();
        //    preorder = new Queue<Integer>();
        //    marked = new boolean[G.V()];
        //    for (int v = 0; v < G.V(); v++)
        //        if (!marked[v]) dfs(G, v);
        //}




        // run DFS in edge-weighted digraph G from vertex v and compute preorder/postorder

        //private void dfs(EdgeWeightedDigraph G, int v)
        //{
        //    marked[v] = true;
        //    pre[v] = preCounter++;
        //    preorder.enqueue(v);
        //    for (DirectedEdge e : G.adj(v))
        //    {
        //        int w = e.to();
        //        if (!marked[w])
        //        {
        //            dfs(G, w);
        //        }
        //    }
        //   postorder.enqueue(v);
        //    post[v] = postCounter++;
        //}

    }
}
