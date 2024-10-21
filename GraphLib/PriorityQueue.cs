using System;
using System.Collections.Generic;

namespace GraphLib
{
    public class PriorityQueue<T>
    {
        private List<(T Item, int Priority)> data;

        public PriorityQueue()
        {
            this.data = new List<(T, int)>();
        }

        public void Enqueue(T item, int priority)
        {
            data.Add((item, priority));
            int childIndex = data.Count - 1;

            // Percolate up
            while (childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2;
                if (data[childIndex].Priority >= data[parentIndex].Priority)
                    break; 
                Swap(childIndex, parentIndex);
                childIndex = parentIndex;
            }
        }

        public T Dequeue()
        {
            if (data.Count == 0) throw new InvalidOperationException("Priority queue is empty.");

            int lastIndex = data.Count - 1;
            (T Item, int Priority) frontItem = data[0];

            // Replace root with the last element
            data[0] = data[lastIndex];
            data.RemoveAt(lastIndex);

            // Percolate down
            int parentIndex = 0;
            lastIndex = data.Count - 1;

            while (true)
            {
                int leftChildIndex = 2 * parentIndex + 1;
                int rightChildIndex = 2 * parentIndex + 2;
                if (leftChildIndex > lastIndex) 
                    break;

                int smallerChildIndex = (rightChildIndex > lastIndex || data[leftChildIndex].Priority < data[rightChildIndex].Priority)
                    ? leftChildIndex
                    : rightChildIndex;

                if (data[parentIndex].Priority <= data[smallerChildIndex].Priority) 
                    break;

                Swap(parentIndex, smallerChildIndex);
                parentIndex = smallerChildIndex;
            }

            return frontItem.Item;
        }

        public T Peek()
        {
            if (data.Count == 0) 
                throw new InvalidOperationException("Priority queue is empty.");
            return data[0].Item;
        }

        public int Count => data.Count;

        private void Swap(int index1, int index2)
        {
            (data[index2], data[index1]) = (data[index1], data[index2]);
        }
    }

}
