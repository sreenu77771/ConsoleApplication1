using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class MyLinkedListNode
    {
        int data;
        MyLinkedListNode next;
        MyLinkedListNode random;

        public MyLinkedListNode()
        {

        }
        public MyLinkedListNode(int pData)
        {
            this.data = pData;
        }

        public MyLinkedListNode(int pData, MyLinkedListNode pNext)
        {
            this.data = pData;
            this.next = pNext;
        }
        public MyLinkedListNode(int pData, MyLinkedListNode pNext, MyLinkedListNode pRand)
        {
            this.data = pData;
            this.next = pNext;
            this.random = pRand;
        }

        public static MyLinkedListNode CreateTestLinkList()
        {
            //1(random-3)-->2-->3-->4(random-2)-->5
            MyLinkedListNode node1 = new MyLinkedListNode(1);
            MyLinkedListNode node2 = new MyLinkedListNode(2);
            MyLinkedListNode node3 = new MyLinkedListNode(3);
            MyLinkedListNode node4 = new MyLinkedListNode(4);
            MyLinkedListNode node5 = new MyLinkedListNode(5);

            node1.next = node2;
            node1.random = node3;

            node2.next = node3;

            node3.next = node4;

            node4.next = node5;
            node4.random = node2;

            node5.next = null;

            return node1;
        }

        public static MyLinkedListNode CreateTestLinkList_1()
        {
            //1(random-3)-->2-->3-->4(random-2)-->5
            MyLinkedListNode node1 = new MyLinkedListNode(1);
            MyLinkedListNode node2 = new MyLinkedListNode(2);
            MyLinkedListNode node3 = new MyLinkedListNode(3);
            MyLinkedListNode node4 = new MyLinkedListNode(4);
            MyLinkedListNode node5 = new MyLinkedListNode(5);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = null;

            return node1;
        }

        public static void PrintLinkedList(MyLinkedListNode head)
        {
            while (head != null)
            {
                Console.Write(string.Format("{0}(rand:{1})-->", head.data, (head.random == null ? -1 : head.random.data)));
                head = head.next;
            }

            Console.WriteLine();
        }

        public static MyLinkedListNode ImmutableClone(MyLinkedListNode head)
        {
            Dictionary<MyLinkedListNode, MyLinkedListNode> dict = new Dictionary<MyLinkedListNode, MyLinkedListNode>();
            MyLinkedListNode temphead = null;
            MyLinkedListNode newHead = null;
            MyLinkedListNode origHead = head;

            if (head != null)
            {
                temphead = new MyLinkedListNode(head.data);
                newHead = temphead;
                dict.Add(head, temphead);
            }

            while (head != null)
            {
                head = head.next;
                MyLinkedListNode prev = temphead;

                temphead = (head == null ? null : new MyLinkedListNode(head.data));
                if (head != null)
                    dict.Add(head, temphead);

                prev.next = temphead;
            }

            head = origHead;
            temphead = newHead;
            while (head != null)
            {
                if (head.random != null)
                {
                    temphead.random = dict[head.random];
                }

                head = head.next;
                temphead = temphead.next;
            }

            return newHead;
        }

        public static MyLinkedListNode MutableClone(MyLinkedListNode head)
        {
            MyLinkedListNode origHead = null;
            MyLinkedListNode newOrigHead = null;            
            //travese and insert clone nodes in between nodes

            if (head != null)
            {
                origHead = head;
            }

            while (head != null)
            {
                MyLinkedListNode next = head.next;
                MyLinkedListNode temp = new MyLinkedListNode(head.data);
                head.next = temp;
                temp.next = next;

                head = head.next.next;
            }

            head = origHead;
            MyLinkedListNode.PrintLinkedList(head);

            while (head != null)
            {
                if (head.random != null)
                {
                    head.next.random = head.random.next;
                }
                head = head.next.next;
            }

            head = origHead;
            MyLinkedListNode.PrintLinkedList(head);
            newOrigHead = head.next;
            MyLinkedListNode tempCloneHead = head.next;           
            while (head!= null && head.next != null)
            {
                MyLinkedListNode headNext = head.next.next;
                MyLinkedListNode tempCloneHeadNext = (tempCloneHead.next != null) ? tempCloneHead.next.next : null;
                head.next = headNext;
                tempCloneHead.next = tempCloneHeadNext;
                head = head.next;
                tempCloneHead = tempCloneHead.next;

            }

            return newOrigHead;
        }

        public static MyLinkedListNode RotateLinkListAtKthNode(MyLinkedListNode head, int k)
        {
            if ((head == null) || (k < 0))
                return null;
            MyLinkedListNode origHead = head;
            MyLinkedListNode last = head;
            MyLinkedListNode prev = null;
            MyLinkedListNode begin = last;
            bool setHead = false;
            while (last != null)
            {
                              
                int i = 0;
                while (i < k-1  && last != null &&  last.next != null)
                {
                    i++;
                    prev = last;
                    last = last.next;
                }

                prev.next = last.next;
                if(begin != last)
                    last.next = begin;
                if (!setHead)
                {
                    origHead = last;
                    setHead = true;
                }
                last = prev.next;
                prev = last;
                begin = last;
            }

            return origHead;
        }

        public static MyLinkedListNode Reverse(MyLinkedListNode node)
        {
            MyLinkedListNode prev = null;
            MyLinkedListNode current = node;
            MyLinkedListNode next = null;

            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            return prev;
        }

        public static MyLinkedListNode ReverseLastKElements(MyLinkedListNode node, int k)
        {
            //check for node null 
            //if (node == null) throw ArgumentException();
            MyLinkedListNode orig = node;
            MyLinkedListNode first = node;
            MyLinkedListNode second = node;

            int i = 0;
            while (i <= (k) && first != null)
            {
                first = first.next;
                i++;
            }

            if (first != null)
            {
                while (first != null)
                {
                    first = first.next;
                    second = second.next;
                }


                MyLinkedListNode reversedHeadOfKElements = Reverse(second.next);
                second.next = reversedHeadOfKElements;
                return node;
            }

            return Reverse(second.next); 
        }

        public static void InternalMain()
        {
            MyLinkedListNode n = CreateTestLinkList();
            PrintLinkedList(n);

            //PrintLinkedList(Reverse(n));

            PrintLinkedList(ReverseLastKElements(n, 6));
        }
    }
}
