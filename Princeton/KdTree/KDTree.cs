using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    public class KDTree<V> : IEnumerable<Node<Point2D, V>>
    {
        private Node<Point2D, V> root = null;

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<Node<Point2D, V>> IEnumerable<Node<Point2D, V>>.GetEnumerator()
        {
            Queue<Node<Point2D, V>> cq = new Queue<Node<Point2D, V>>();
            Queue<Node<Point2D, V>> nq = new Queue<Node<Point2D, V>>();

            cq.Enqueue(root);
            Node<Point2D, V> c = null;
            while (cq.Count != 0 || nq.Count != 0)
            {
                while (cq.Count != 0 && (c = cq.Dequeue()) != null)
                {
                    yield return c;
                    if (c.left != null)
                        nq.Enqueue(c.left);
                    if (c.right != null)
                        nq.Enqueue(c.right);
                }

                //wont work if 0 as key
                yield return new Node<Point2D, V>(default(Point2D), default(V));

                var temp = nq;
                nq = cq;
                cq = temp;
            }
        }

        public void put(Point2D key, V val)
        {
            this.root = put(root, key, val, -1);
        }

        public Node<Point2D, V> put(Node<Point2D, V> temp, Point2D key, V val, int depth)
        {
            if(temp == null)
            {
                var t = new Node<Point2D, V>(key, val);
                t.depth = depth + 1;
                return t;
            }

            IComparer<Point2D> comparer = (IComparer<Point2D> )new XPoint2DComparer();
            if(temp.depth %2 ==1 )
            {
                comparer = (IComparer<Point2D>)new YPoint2DComparer();
            }

            if (comparer.Compare(temp.Key, key) < 0)
            {
                temp.right = put(temp.right, key, val, temp.depth);
            }
            else if(comparer.Compare(temp.Key, key) > 0)
            {
                temp.left = put(temp.left, key, val, temp.depth);
            }
            else
            {
                temp = new Node<Point2D, V>(key, val);
            }           


            return temp;
        }

        public Node<Point2D, V> nearest(Point2D key)
        {
            Node<Point2D, V> min = null;
            nearest(this.root, key, ref min, double.MaxValue);
            return min;
        }

        public void nearest(Node<Point2D, V> temp, Point2D key, ref Node<Point2D, V> min, double closestDist)
        {
            if (temp == null) return;

            double dist = temp.Key.distanceTo(key);
            if (dist < closestDist)
            {
                closestDist = dist;
                min = temp;
            }
            
            
            double leftDist = double.MaxValue;
            double rightDist = double.MaxValue;
            if(temp.left != null)
            {
                leftDist = key.distanceTo(temp.left.Key);
            }
            if(temp.right != null)
            {
                rightDist = key.distanceTo(temp.right.Key);
            }

            if(leftDist > rightDist)
            {
                nearest(temp.right, key, ref min, closestDist);
            }
            else
                nearest(temp.left, key, ref min, closestDist);                       
            
        }

        public int FindDepth(Point2D p)
        {
            return FindDepth(root, p);
        }
        public int FindDepth(Node<Point2D, V> temp, Point2D p)
        {
            if (temp == null) return -1;

            IComparer<Point2D> comparer = (IComparer<Point2D>)new XPoint2DComparer();
            if (temp.depth % 2 == 1)
            {
                comparer = (IComparer<Point2D>)new YPoint2DComparer();
            }

            int c = comparer.Compare(temp.Key, p);

            if(c < 0)
            {
                return FindDepth(temp.right, p);
            }
            else if(c > 0)
            {
                return FindDepth(temp.left, p);
            }
            else
            {
                return temp.depth;
            }

        }

        public IEnumerator<Point2D> range(RectHV rect)
        {
            var l = new List<Point2D>();
            range(this.root, rect, l);
            return l.GetEnumerator();
        }

        public void range(Node<Point2D, V> temp, RectHV rect, List<Point2D> t)
        {
            if (temp == null) return;

            if(rect.Contains(temp.Key))
            {
                t.Add(temp.Key);
            }

            IComparer<Point2D> comparer = (IComparer<Point2D>)new XPoint2DComparer();
            if (temp.depth % 2 == 1)
            {
                comparer = (IComparer<Point2D>)new YPoint2DComparer();
            }

            if (temp.depth % 2 == 1)
            {
                if (rect.ContainsInY(temp.Key) > 0)
                    range(temp.left, rect, t);
                else if (rect.ContainsInY(temp.Key) < 0)
                    range(temp.right, rect, t);
                else
                {
                    range(temp.left, rect, t);
                    range(temp.right, rect, t);
                }
            }
            else
            {
                if (rect.ContainsInX(temp.Key) > 0)
                    range(temp.left, rect, t);
                else if (rect.ContainsInX(temp.Key) < 0)
                    range(temp.right, rect, t);
                else
                {
                    range(temp.left, rect, t);
                    range(temp.right, rect, t);
                }
            }



        }

        public static void InternalMain()
        {
            KDTree<int> tree = new KDTree<int>();

            tree.put(new Point2D(.7, 0.2), 1);
            tree.put(new Point2D(0.5, 0.4), 1);
            tree.put(new Point2D(0.2, 0.3), 1);
            tree.put(new Point2D(0.4, 0.7), 1);
            tree.put(new Point2D(0.9, 0.6), 1);

            Display(tree);

            Console.WriteLine(tree.FindDepth(new Point2D(0.4, 0.7)));
            IEnumerator<Point2D> t = tree.range(new RectHV(0, 0, .8, .5));
            
            while(t.MoveNext())
            {
                Console.WriteLine(t.Current);               
            }
            Console.WriteLine("Nearest" +tree.nearest(new Point2D(.75, .3)).Key);
            Console.WriteLine();

        }

        private static void Display(KDTree<int> tree)
        {
            foreach (var v in tree)
            {
                if (v.Key==null && v.Val == default(int))
                    Console.WriteLine();
                else
                    Console.Write(v.Key + " ");
            }
        }

    }    
}
