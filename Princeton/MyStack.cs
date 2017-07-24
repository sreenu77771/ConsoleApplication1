using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    class MyStackLinkedList
    {
        private LinkedList<int> data = new LinkedList<int>();

        private void push(int element)
        {
            //LinkedListNode<int> newhead = new LinkedListNode<int>(element);
            data.AddFirst(element);
        }

        private int pop()
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

    class MyStackArray
    {
        private int capacity;
        private int[] data;
        private int nextPointer;
        MyStackArray(int capacity)
        {
            this.capacity = capacity;
            data = new int[capacity];
        }

        private void push(int element)
        {           
            if(nextPointer < data.Length)
            {
                data[nextPointer++] = element;
            }
        }

        private int pop()
        {
            if (!isEmpty())
            {
                return data[--nextPointer];
            }
            else
            {
                throw new Exception("dd");
            }
        }

        private bool isEmpty()
        {
            return (nextPointer == 0);
        }
    }
}
