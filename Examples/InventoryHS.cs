using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HS
{
    public class InventoryHS : MonoBehaviour, IInventory<ItemHS>
    {
        InventoryBase<ItemHS> inventory = new InventoryBase<ItemHS>();

        public void AddItem(ItemHS itemKey, int count = 1)
        {
            ((IInventory<ItemHS>)inventory).AddItem(itemKey, count);
        }

        public IEnumerator<KeyValuePair<ItemHS, int>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<ItemHS, int>>)inventory).GetEnumerator();
        }

        public int GetItemCount(ItemHS itemKey)
        {
            return ((IInventory<ItemHS>)inventory).GetItemCount(itemKey);
        }

        public void RemoveItem(ItemHS itemKey, int count = 1)
        {
            ((IInventory<ItemHS>)inventory).RemoveItem(itemKey, count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)inventory).GetEnumerator();
        }
        public IDisposable Subscribe(IObserver<KeyValuePair<ItemHS, int>> observer)
        {
            return ((IObservable<KeyValuePair<ItemHS, int>>)inventory).Subscribe(observer);
        }
#if UNITY_EDITOR

        [OnStateUpdate("@_Display()")]// Delete it if you do not want auto update with high frequency
        [HideLabel]
        [FoldoutGroup("Storage")]
        [MultiLineProperty(10)]
        [ShowInInspector]
        string _display;

        [FoldoutGroup("Storage")]
        [Button("Display")]
        void _Display()
        {
            _display = "";
            foreach(var x in inventory)
            {
                _display += x.Key + ": " + x.Value + '\n';
            }
        }
#endif
    }
}