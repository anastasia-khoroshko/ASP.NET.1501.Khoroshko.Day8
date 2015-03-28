using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class CustomQueue<T>:IEnumerable<T>,IEnumerable
    {
        private T[] q;
        private int head, tail, capacity, size;
        private const int defaultCapacity = 3;
        public int Count
        {
            get
            {
                return this.size;
            }
        }
            public int Length
            {
                get
                {
                    return this.capacity;
                }
            }

            public CustomQueue()
            {
                this.capacity = defaultCapacity;
                this.q = new T[defaultCapacity];
                this.size = 0;
                this.head = -1;
                this.tail = 0;
            }

            public CustomQueue(CustomQueue<T> ob)
            {
                size = ob.size;
                head = ob.head;
                tail = ob.tail;
                q = new T[size];
                for (int i = 0; i < size; i++)
                    q[i] = ob.q[i];
            }
            public void Enqueuee(T elem)
            {
                if (this.size == this.capacity)
                {
                    T[] newQueuee = new T[capacity * 2];
                    Array.Copy(this.q, 0, newQueuee, 0, size);
                    q = newQueuee;
                    capacity *= 2;
                    size++;
                    q[tail++ % capacity] = elem;
                }
                else
                {
                    size++;
                    q[tail++ % capacity] = elem;
                }
            }

            public T Dequeuee()
            {
                if (this.size == 0)
                    throw new InvalidOperationException();
                else
                {
                    size--;
                    return q[++head % capacity];
                }
            }
            
            public T Peek()
            {
                if (this.size == 0)
                    throw new InvalidOperationException();
                else
                {
                    return this.q[head+1];
                }
            }
            public IEnumerator<T> GetEnumerator()
            {
                while(size>0)
                    yield return Dequeuee();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
            }
    }
}
