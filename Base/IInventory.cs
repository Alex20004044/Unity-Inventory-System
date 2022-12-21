using System;
using System.Collections.Generic;

namespace HS
{
    /// <summary>
    /// Emits even when some item has been changed
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IInventory<T>: IEnumerable<KeyValuePair<T, int>>, IObservable<KeyValuePair<T, int>>
    {
        void AddItem(T itemKey, int count = 1);
        void RemoveItem(T itemKey, int count = 1);
        int GetItemCount(T itemKey);
    }
}