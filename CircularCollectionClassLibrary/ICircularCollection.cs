namespace CircularCollectionClassLibrary
{
    public interface ICircularCollection<T>
    {
        public int Count { get; }
        T Current { get; }
        void Add(T item);
        void Clear();
        void MoveNext();
    }
}