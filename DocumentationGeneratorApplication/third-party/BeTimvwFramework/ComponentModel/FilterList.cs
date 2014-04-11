//This file comes from the Be.Timvw.Framework
//The Be.Timvw.Framework was created by Tim Van Wassenhove and is distributed under the Apache 2.0 license.
//http://betimvwframework.codeplex.com/

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Be.Timvw.Framework.ComponentModel
{
    public class FilterList<T> : SortableBindingList<T>
    {
        readonly List<T> allItems = new List<T>();

        public FilterList()
        {
        }

        public FilterList(IEnumerable<T> elements)
            : base(elements)
        {
            allItems.AddRange(elements);
        }

        public void Filter(Predicate<T> filter)
        {
            if (ReferenceEquals(filter, null)) throw new ArgumentNullException("filter");

            ApplyFilter(filter);
            if (IsSortedCore)ApplySortCore(SortPropertyCore, SortDirectionCore);
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected virtual void ApplyFilter(Predicate<T> filter)
        {
            var wantedItems = this.allItems.FindAll(filter);
           
            Items.Clear();
            foreach (var item in wantedItems) Items.Add(item);
        }

        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            allItems.Add(Items[index]);
        }

        protected override void RemoveItem(int index)
        {
            allItems.Remove(Items[index]);
            base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            base.ClearItems();
            allItems.Clear();
        }

        protected override void SetItem(int index, T item)
        {
            allItems[allItems.IndexOf(Items[index])] = item;
            base.SetItem(index, item);
        }
    }
}
