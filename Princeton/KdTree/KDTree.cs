using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    class KDTree<Point2D, V> : IEnumerable<Node<Point2D, V>> where Point2D : IComparable<Point2D>
    {
        private Node<Point2D, V> root = null;

        public IEnumerator GetEnumerator()
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
            this.root = put(root, key, val);
        }

        public Node<Point2D, V> put(Node<Point2D, V> temp, Point2D key, V val)
        {
            if(temp == null)
            {
                return new Node<Point2D, V>(key, val);
            }

            IComparer<Point2D> comparer = (IComparer<Point2D> )new XPoint2DComparer();
            if(temp.depth %2 ==1 )
            {
                comparer = (IComparer<Point2D>)new YPoint2DComparer();
            }

            if (comparer.Compare(temp.Key, key) < 0)
                temp.right = put(temp.right, key, val);

            temp.left = put(temp.left, key, val);

            temp.depth += 1;

            return temp;
        }

        public Node<Point2D, V> nearest(Point2D key)
        {

        }

        public IEnumerator<Point2D> range(RectHV rect)
        {

        }

    }    
}
