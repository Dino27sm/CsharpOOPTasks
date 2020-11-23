namespace _08.CollectionHierarchy
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    public class AddCollection<T> : IEnumerable<T>
    {
        protected List<T> internalList;

        public AddCollection()
        {
            this.internalList = new List<T>();
        }
        private int Count => this.internalList.Count;

        public T this[int index] 
        {
            get
            {
                ValidateIndex(index);
                return this.internalList[index];
            }
            set
            {
                ValidateIndex(index);
                this.internalList[index] = value;
            }
        }

        private bool ValidateIndex(int currentIndex)
        {
            if (currentIndex < 0 || currentIndex >= this.Count)
                throw new ArgumentOutOfRangeException();
            return true;
        }
        public virtual int Add(T element)
        {
            this.internalList.Add(element);
            return this.internalList.Count - 1;
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (var item in this.internalList)
            {
                yield return item;
            }
        }
    }
}
