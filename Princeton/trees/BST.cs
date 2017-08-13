using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    class BST<T, V> :  IEnumerable<Node<T, V>> where T : IComparable<T>
    {
        private Node<T, V> root = null;
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
            //yield return new Node<T, V>(default(T), default(V));
            
        }


        IEnumerator<Node<T, V>> IEnumerable<Node<T, V>>.GetEnumerator()
        {
            Queue<Node<T, V>> cq = new Queue<Node<T, V>>();
            Queue<Node<T, V>> nq = new Queue<Node<T, V>>();

            cq.Enqueue(root);
            Node<T, V> c = null;
            while (cq.Count != 0 || nq.Count != 0)
            {
                while (cq.Count != 0 && (c = cq.Dequeue()) != null)
                {
                    yield return c;
                    if(c.left != null)
                        nq.Enqueue(c.left);
                    if(c.right != null)
                        nq.Enqueue(c.right);
                }

                //wont work if 0 as key
                yield return new Node<T, V>(default(T), default(V));

                var temp = nq;
                nq = cq;
                cq = temp;
            }
        }

        public void InOrderTravesal()
        {
            Stack<Node<T,V>> s = new Stack<Node<T, V>>();

            var t = root;
            s.Push(t);
            while(s.Count != 0)
            {
                var n = s.Peek();

                if(n.left != null && n.left.visisted == false)
                {
                    s.Push(n.left);
                    continue;
                }

                Console.Write(n.Key + " ");
                n.visisted = true;
                s.Pop();
                if(n.right != null)
                {
                    s.Push(n.right);
                    
                }
            }
        }

        public void PostOrderTravesal()
        {
            Stack<Node<T, V>> s = new Stack<Node<T, V>>();

            var t = root;
            s.Push(t);
            while (s.Count != 0)
            {
                var n = s.Peek();

                if (n.right != null && n.right.visisted == false)
                {
                    s.Push(n.right);
                }

                if (n.left != null && n.left.visisted == false)
                {
                    s.Push(n.left);
                }

                if(((n.left== null) || (n.left.visisted == true)) &&
                    ((n.right == null) || (n.right.visisted == true)))
                {
                    n.visisted = true;
                    Console.Write(s.Pop().Key + " ");
                }
            }
        }

        public void PreOrderTravesal()
        {
            Stack<Node<T, V>> s = new Stack<Node<T, V>>();

            var t = root;
            s.Push(t);
            while (s.Count != 0)
            {
                var n = s.Pop();
                Console.Write( n.Key + " ");
                if (n.right != null)
                    s.Push(n.right);
                if (n.left != null)
                    s.Push(n.left);
            }
        }
        
        public int size()
        {
            return size(root);
        }


        public int size(Node<T, V> temp)
        {
            if (temp == null) return 0;
            return temp.count;
        }

        public int rank(T key)
        {
            return rank(root, key);
        }


        public int rank(Node<T, V> temp, T key)
        {
            if(temp == null) return 0;
            if (temp.Key.CompareTo(key) > 0)
                return rank(temp.left, key);
            else if (temp.Key.CompareTo(key) < 0)
                return 1 + rank(temp.left, key) + rank(temp.right, key);
            else return rank(temp.left, key);
        }

        public void putAlt(T key, V val)
        {
            root = putAlt(root, key, val);
        }

        private Node<T, V> putAlt(Node<T, V> temp, T key, V val)
        {
            if (temp == null)
            {
                var t = new Node<T, V>(key, val);
                t.count = 1;
                return t;
            }

            if (temp.Key.CompareTo(key) > 0)
            {
                temp.left = putAlt(temp.left, key, val);
            }
            if (temp.Key.CompareTo(key) < 0)
            {
                temp.right = putAlt(temp.right, key, val);
            }
            else
            {
                temp.Val = val;
            }
            temp.count = 1 + size(temp.left) + size(temp.right);

            return temp;
        }

        public void put(T key, V val)
        {
            Node<T, V> temp = root;
            Node<T, V> parent = null;
            if (key == null) throw new NullReferenceException();
            while (temp != null)
            {
                if (root.Key.CompareTo(key) > 0)
                {
                    parent = temp;
                    temp = temp.left;
                }
                else if (root.Key.CompareTo(key) < 0)
                {
                    parent = temp;
                    temp = temp.right;
                }
                else
                {
                    root.Val = val;
                    break;
                }
            }
            if (temp == null)
            {
                if (root != null)
                {
                    if (parent.Key.CompareTo(key) > 0)
                        parent.left = new Node<T, V>(key, val);
                    else
                        parent.right = new Node<T, V>(key, val);
                }
                else
                    root = new Node<T, V>(key, val);
            }
            
            
            
        }

        public Node<T, V> DeleteMin()
        {
            this.root =  this.DeleteMin(root);
            return root;
        }
        public Node<T, V> DeleteMin(Node<T, V> x)
        {
            if (x.left == null) return x.right;
            x.left = DeleteMin(x.left);
            x.count = 1 + size(x.left) + size(x.right);
            return x;
        }

        public Node<T, V> DeleteMax()
        {
            this.root = this.DeleteMax(root);
            return root;
        }
        public Node<T, V> DeleteMax(Node<T, V> x)
        {
            if (x.right == null) return x.left;
            x.right = DeleteMax(x.right);
            x.count = 1 + size(x.left) + size(x.right);
            return x;
        }

        public Node<T, V> Delete(Node<T, V> x, T key)
        {
            if (x.Key.CompareTo(key) > 0)
                x.left = Delete(x.left, key);
            else if (x.Key.CompareTo(key) < 0)
                x.right = Delete(x.right, key);
            else
            {
                //if its leaf - delete
                if (x.left == null && x.right == null)
                {
                    return null;
                }
                //if right is null.. then just link its left
                else if (x.right == null)
                {
                    return x.left;
                }
                else if (x.left == null) return x.right;
                else
                {
                    var t = x;
                    x = min(t.right);
                    x.right = DeleteMin(t.right);
                    x.left = t.left;

                }             
            }
            x.count = size(x.left) + size(x.right) + 1;
            return x;
        }

        private Node<T, V> min(Node<T, V> t)
        {
            while (t.left != null)
                t = t.left;
            return t;
        }

        public Node<T,V> get(T key)
        {
            return this.get(root, key);
        }
        public Node<T, V> get(Node<T,V> top, T key)
        {
            Node<T, V> temp = top;
            if (key == null) throw new NullReferenceException();
            while (temp != null)
            {
                if (temp.Key.CompareTo(key) > 0)
                {
                    temp = temp.left;
                }
                else if (temp.Key.CompareTo(key) < 0)
                {
                    temp = temp.right;
                }
                else return temp;
            }
            return new Node<T,V>(default(T),default(V));
        }

        public Node<T, V> Min()
        {
            //assume root is not null
            Node<T, V> temp = root;
            while (temp.left != null)
            {
                temp = temp.left;
            }

            return temp;
        }

        public Node<T, V> Max()
        {
            //assume root is not null
            Node<T, V> temp = root;
            while (temp.right != null)
            {
                temp = temp.right;
            }

            return temp;
        }

        public Node<T, V> Floor(T key)
        {
            return Floor(root, key);
        }
        public Node<T, V> FloorAlt(Node<T,V> top, T key)
        {
            //if key is root key return;
            //otherwise look in left child if its there 
            // other wise look in right if its there
            //if not present in both then root should be the floor
            var temp = top;            
            while (temp != null)
            {
                if (temp.Key.CompareTo(key) == 0) return temp;
                temp = temp.left;
            }
            temp = top.right;
            while (temp != null)
            {
                if (temp.Key.CompareTo(key) == 0) return temp;
                temp = temp.right;
            }
            return top;
        }

        private Node<T, V> FloorAltTextBook(Node<T, V> x, T key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.Key);
            if (cmp == 0) return x;
            if (cmp < 0) return FloorAltTextBook(x.left, key);
            var t = FloorAltTextBook(x.right, key);
            if (t != null) return t;
            else return x;
        }
        public Node<T, V> Celing(T key)
        {
            return CelingAltTextBook(root, key);
        }
        private Node<T, V> CelingAltTextBook(Node<T, V> x, T key)
        {
//            A) Root data is equal to key. We are done, root data is ceil value.

//B) Root data < key value, certainly the ceil value can’t be in left subtree. Proceed to search on right subtree as reduced problem instance.

//C) Root data > key value, the ceil value may be in left subtree. We may find a node with is larger data than key value in left subtree, if not the root itself will be ceil node.

            if (x == null) return null;
            int cmp = key.CompareTo(x.Key);
            if (cmp == 0) return x;
            if (cmp > 0) return CelingAltTextBook(x.right, key);
            var t = CelingAltTextBook(x.left, key);
            if (t != null) return t;
            else return x;

        }
        public Node<T, V> Floor(Node<T, V> x, T key)
        {
            //assume root is not null
            Node<T, V> temp = x;
            Node< T, V > min = new Node<T, V>(GetMinValue(), default(V));
            while (temp != null)
            {
                if (temp.Key.CompareTo(key) < 0 && min.Key.CompareTo(key) < 0)
                {
                    min.Key = temp.Key;
                }
                                    
                if (temp.Key.CompareTo(key) > 0)
                {
                    temp = temp.left;
                        continue;
                }
                else if (temp.Key.CompareTo(key) < 0)
                {
                    temp = temp.right;
                        continue;
                }
                else return temp;
            }

            return min;
        }

      

        public void delete(T key)
        {
            this.root = this.Delete(this.root, key);
        }
        

        public static void InternalMain()
        {
            //BST<int, int> tree = new BST<int, int>();
            //tree.putAlt(5, 3);            
            //tree.putAlt(2, 4);
            //tree.putAlt(8, 2);
            //tree.putAlt(1, 1);
            //tree.putAlt(4, 5);
            //tree.putAlt(3, 5);
            //tree.putAlt(7, 5);           
            //tree.putAlt(10, 5);
            //tree.putAlt(9, 5);

            BST<int, int> tree = new BST<int, int>();
            tree.putAlt(5, 3);
            tree.putAlt(3, 5);
            tree.putAlt(8, 2);
            tree.putAlt(1, 1);
            tree.putAlt(2, 2);
            tree.putAlt(4, 5);

            tree.putAlt(7, 5);
            tree.putAlt(11, 5);
            tree.putAlt(9, 5);
            tree.putAlt(10, 5);

            Display(tree);

            //Console.WriteLine("Min" + tree.Min().Key);
            //Console.WriteLine("Max" + tree.Max().Key);
            //Console.WriteLine("Floor" + tree.Floor(6).Key);
            //Console.WriteLine("Floor" + tree.Floor(4).Key);
            //Console.WriteLine("Floor" + tree.Floor(2).Key);
            //Console.WriteLine("Floor" + tree.Floor(9).Key);
            //Console.WriteLine("Celining" + tree.Celing(6).Key);
            //Console.WriteLine("Celining" + tree.Celing(1).Key);
            //Console.WriteLine("Celining" + tree.Celing(11).Key);
            //Console.WriteLine("size" + tree.size());
            //Console.WriteLine("rank5" + tree.rank(5));
            //Console.WriteLine("rank6" + tree.rank(6));
            //Console.WriteLine("rank2" + tree.rank(2));
            //Console.WriteLine("rank4" + tree.rank(4));
                      
            tree.delete(8);
            Display(tree);
            Console.WriteLine();

            //tree
        }

        private static void Display(BST<int, int> tree)
        {
            foreach (var v in tree)
            {
                if (v.Key == default(int) && v.Val == default(int))
                    Console.WriteLine();
                else
                    Console.Write(v.Key + " ");
            }
        }

        public T GetMaxValue()
        {
            object maxValue = default(T);
            TypeCode typeCode = Type.GetTypeCode(typeof(T));
            switch (typeCode)
            {
                case TypeCode.Byte:
                    maxValue = byte.MaxValue;
                    break;
                case TypeCode.Char:
                    maxValue = char.MaxValue;
                    break;
                case TypeCode.DateTime:
                    maxValue = DateTime.MaxValue;
                    break;
                case TypeCode.Decimal:
                    maxValue = decimal.MaxValue;
                    break;
                case TypeCode.Double:
                    maxValue = decimal.MaxValue;
                    break;
                case TypeCode.Int16:
                    maxValue = short.MaxValue;
                    break;
                case TypeCode.Int32:
                    maxValue = int.MaxValue;
                    break;
                case TypeCode.Int64:
                    maxValue = long.MaxValue;
                    break;
                case TypeCode.SByte:
                    maxValue = sbyte.MaxValue;
                    break;
                case TypeCode.Single:
                    maxValue = float.MaxValue;
                    break;
                case TypeCode.UInt16:
                    maxValue = ushort.MaxValue;
                    break;
                case TypeCode.UInt32:
                    maxValue = uint.MaxValue;
                    break;
                case TypeCode.UInt64:
                    maxValue = ulong.MaxValue;
                    break;
                default:
                    maxValue = default(T);//set default value
                    break;
            }

            return (T)maxValue;
        }

        public T GetMinValue()
        {
            object MinValue = default(T);
            TypeCode typeCode = Type.GetTypeCode(typeof(T));
            switch (typeCode)
            {
                case TypeCode.Byte:
                    MinValue = byte.MinValue;
                    break;
                case TypeCode.Char:
                    MinValue = char.MinValue;
                    break;
                case TypeCode.DateTime:
                    MinValue = DateTime.MinValue;
                    break;
                case TypeCode.Decimal:
                    MinValue = decimal.MinValue;
                    break;
                case TypeCode.Double:
                    MinValue = decimal.MinValue;
                    break;
                case TypeCode.Int16:
                    MinValue = short.MinValue;
                    break;
                case TypeCode.Int32:
                    MinValue = int.MinValue;
                    break;
                case TypeCode.Int64:
                    MinValue = long.MinValue;
                    break;
                case TypeCode.SByte:
                    MinValue = sbyte.MinValue;
                    break;
                case TypeCode.Single:
                    MinValue = float.MinValue;
                    break;
                case TypeCode.UInt16:
                    MinValue = ushort.MinValue;
                    break;
                case TypeCode.UInt32:
                    MinValue = uint.MinValue;
                    break;
                case TypeCode.UInt64:
                    MinValue = ulong.MinValue;
                    break;
                default:
                    MinValue = default(T);//set default value
                    break;
            }

            return (T)MinValue;
        }


    }
    public class Node<T, V>
    {
        private T key;
        private V val;
        public Node<T, V> left;
        public Node<T, V> right;
        public int count;
        public bool visisted;
        public int depth;

        public T Key
        {
            get
            {
                return key;
            }

            set
            {
                key = value;
            }
        }

        public V Val
        {
            get
            {
                return val;
            }

            set
            {
                val = value;
            }
        }

        public Node(T key, V val)
        {
            this.key = key;
            this.val = val;
        }
    }
}
