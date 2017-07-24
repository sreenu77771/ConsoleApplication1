using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    class MyQueueLinkedList
    {
        private LinkedList<int> data = new LinkedList<int>();

        private void Enqueue(int element)
        {
            data.AddLast(element);
        }

        private int Dequeue()
        {
            if (!isEmpty())
            {
                int first = data.First();
                data.RemoveFirst();
                return first;
            }
            else
            {
                throw new Exception("dd");
            }
        }

        private bool isEmpty()
        {
            return (data.Count == 0);
        }
    }

    class MyQueueArray
    {
        private int capacity;        
        private int[] data;
        private int head, tail, size;

        MyQueueArray(int capacity)
        {
            this.capacity = capacity;
            data = new int[capacity];
            head = 0; tail = 0; size = 0;
        }

        private void push(int element)
        {

            if (!isFull())
            {
                data[tail] = element;
                tail = (tail + 1) % capacity;
                size++;
            }
            else
            {
                throw new Exception("dd");
            }


        }

        private int pop()
        {
            if (!isEmpty())
            {
                int element = data[head];
                size--;
                head = (head + 1) % capacity;
                return element;
            }
            else
            {
                throw new Exception("dd");
            }
        }

        private bool isEmpty()
        {
            return (size == 0);
        }

        private bool isFull()
        {
            return (size == capacity);
        }

        public static void Main(string[] args)
        {
            MyQueueArray q = new MyQueueArray(4);
            q.push(1);
            q.push(2);
            q.push(3);
            q.push(4);

            while (!q.isEmpty())
            {
                Console.Write(q.pop() + " -->");
            }
            q.pop();

        }
    }
}
