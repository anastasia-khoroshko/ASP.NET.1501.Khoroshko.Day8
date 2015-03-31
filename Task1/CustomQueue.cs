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
        private int head, tail;
        private const int defaultCapacity = 3;
        public int Count { get; private set; }
            public int Length
            {
                get
                {
                    return q.Length;
                }
            }

            public CustomQueue()
            {
                Count = 0;
                q = new T[defaultCapacity];
                head = -1;
                tail = 0;
            }

            public CustomQueue(CustomQueue<T> ob)
            {
                head = ob.head;
                tail = ob.tail;
                q = new T[ob.Count];
                for (int i = 0; i < ob.Count; i++)
                    q[i] = ob.q[i];
            }
            public void Enqueuee(T elem)
            {
                if (Length==Count)
                {
                    ChangeSize(Count*2);
                }
                    Count++;
                    q[tail++%Length] = elem;
                    if (tail > Length) tail = 1;
            }

            private void ChangeSize(int p)
            {
                if (p < Count)
                    throw new ArgumentException("Invalid size");
                T[] newQueuee = new T[p];
                for (int i = 0; i < Count;i++ )
                {
                    if (head < Length - 1) head++;
                    else head = 0;
                    newQueuee[i] = q[head];                    
                }
                q = newQueuee;
                head = -1;
                tail = Count;
            }

            public T Dequeuee()
            {
                if (Count == 0)
                    throw new InvalidOperationException();
                else
                {
                    Count--;
                    T returnValue = q[++head % Length];
                    q[head] = default(T);
                    return returnValue ;
                }
            }
            
            public T Peek()
            {
                if (Count == 0)
                    throw new InvalidOperationException();
                else
                {
                    return this.q[head+1];
                }
            }
            public IEnumerator<T> GetEnumerator()
            {
                return new CustomEnumerator(this);
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
            }

            public class CustomEnumerator:IEnumerator<T>
            {
            private readonly CustomQueue<T> collection;
            private int currentIndex;
            private int currentCount;

            internal CustomEnumerator(CustomQueue<T> collection)
            {
                this.currentIndex = collection.head;
                this.collection = collection;
                this.currentCount = 0;
            }

            public T Current
            {
                get
                {
                    currentIndex = currentIndex >= collection.Length - 1 ? 0 : ++currentIndex;
                    return collection.q[currentIndex];
                }
            }

            public void Reset()
            {
                currentIndex = collection.head;
            }

            public bool MoveNext()
            {
                return ++currentCount <= collection.Count;
            }


            public void Dispose() { }

            object IEnumerator.Current
            {
                get { throw new NotImplementedException(); }
            }
            }
    }
}
