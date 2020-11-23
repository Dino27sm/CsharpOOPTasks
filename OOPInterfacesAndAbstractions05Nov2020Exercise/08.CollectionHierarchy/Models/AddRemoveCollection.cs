namespace _08.CollectionHierarchy.Models
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    public class AddRemoveCollection<T> : AddCollection<T>
    {
        public override int Add(T element)
        {
            this.internalList.Insert(0, element);
            return 0;
        }

        public virtual T Remove()
        {
            T removedElement = this.internalList.LastOrDefault();
            this.internalList.RemoveAt(this.internalList.Count - 1);
            return removedElement;
        }
    }
}
