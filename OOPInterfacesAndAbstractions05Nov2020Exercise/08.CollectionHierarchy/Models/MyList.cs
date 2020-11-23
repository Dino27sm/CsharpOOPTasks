namespace _08.CollectionHierarchy.Models
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    public class MyList<T> : AddRemoveCollection<T>
    {
        public int Used => this.internalList.Count;

        public override T Remove()
        {
            T removedElement = this.internalList[0];
            this.internalList.RemoveAt(0);
            return removedElement;
        }
    }
}
