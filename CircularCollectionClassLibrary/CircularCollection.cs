using System.Collections.Generic;

namespace CircularCollectionClassLibrary
{
    public class CircularCollection<T> : ICircularCollection<T>
    {
        private List<T> innerList = new List<T>();
        private int currentIndex = 0;
        public void Add(T item) { innerList.Add(item); }
        public void Clear() { innerList.Clear(); currentIndex = 0; }
        public T Current { get { return innerList[currentIndex]; } }
        public int Count { get { return innerList.Count; } }
        public void MoveNext()
        {
            currentIndex++;
            currentIndex %= innerList.Count;
        }
    }
}
