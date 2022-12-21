using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace HS
{
    public class InventoryBase<T> : IInventory<T>
    {
        Dictionary<T, int> items = new Dictionary<T, int>();
        Subject<KeyValuePair<T, int>> subject = new Subject<KeyValuePair<T, int>>();
        public void AddItem(T itemKey, int count = 1)
        {
            if (count > 0)
            {
                if (!items.TryAdd(itemKey, count))
                {
                    count = items[itemKey] + count;
                    items[itemKey] = count;
                }     
            }
            else if (count < 0)
            {
                count = items[itemKey] + count;
                if (count < 0)
                    throw new ArgumentOutOfRangeException($"Attempt to substract more {itemKey.ToString()} then contains in inventory");
                else if (count == 0)
                    items.Remove(itemKey);
                else
                {
                    items[itemKey] = count;
                }
            }
            subject.OnNext(new KeyValuePair<T, int>(itemKey, count));
        }
        public int GetItemCount(T itemKey)
        {
            return items.GetValueOrDefault(itemKey, 0);
        }
        public void RemoveItem(T itemKey, int count = 1)
        {
            AddItem(itemKey, -count);
        }
        public IEnumerator<KeyValuePair<T, int>> GetEnumerator()
        {
            return items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IDisposable Subscribe(IObserver<KeyValuePair<T, int>> observer)
        {
            return subject.Subscribe(observer);
        }
    }
}