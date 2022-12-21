using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HS
{
    public class ItemUserBase<T> : MonoBehaviour, IInteractable, IItemUser<T>
    {
        [Header("Required items for interaction")]
        [SerializeField]
        List<ItemInfo> targetItems = new List<ItemInfo>();
        [SerializeField]
        bool isConsumeTargetItems = true;

        [SerializeField]
        UnityEvent onItemsUsed;
        public bool TryInteract(GameObject initiator)
        {
            if (!initiator.TryGetComponent(out IInventory<T> inventory))
                return false;

            return TryUseItems(inventory);
        }

        public bool TryUseItems(IInventory<T> inventory)
        {
            foreach (var x in targetItems)
            {
                if (inventory.GetItemCount(x.itemKey) < x.count)
                {
                    return false;
                }
            }

            if(isConsumeTargetItems)
                targetItems.ForEach((x) => inventory.RemoveItem(x.itemKey, x.count));

            onItemsUsed.Invoke();
            return true;
        }

        [Serializable]
        struct ItemInfo
        {
            public T itemKey;
            public int count;
        }
    }
}