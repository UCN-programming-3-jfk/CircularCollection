using System.Collections;
using System.Collections.Generic;

namespace CircularCollectionClassLibrary
{
    public class CompleteCircularCollection<T> : ICompleteCircularCollection<T>, IEnumerator<T>
    {
        List<T> innerList = new List<T>();
        int currentIndex = -1;
        public void Add(T item) { innerList.Add(item); }
        public void Clear() { innerList.Clear(); currentIndex = -1; }
        public T Current { get { return innerList[currentIndex]; } }

        public bool MoveNext()
        {
            currentIndex++;
            currentIndex %= innerList.Count;
            return true;
        }

        public int Count { get { return innerList.Count; } }

        public bool IsReadOnly { get { return false; } }

        object IEnumerator.Current { get { return Current; } }

        public bool Contains(T item)
        {
            return innerList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            innerList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        public bool Remove(T item)
        {
            return innerList.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public void Reset()
        {
            currentIndex = innerList.Count > 0 ? 0 : -1;
        }

        public void Dispose()
        {
            return;
        }
    }
}
