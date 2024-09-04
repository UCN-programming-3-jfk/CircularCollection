using System.Collections.Generic;

namespace CircularCollectionClassLibrary
{
    public interface ICompleteCircularCollection<T> :  ICollection<T>, IEnumerator<T>
    {
    }
}