using CorD.SparrowInterfaceField;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HS
{
    public class ItemsAdder : MonoBehaviour
    {
        [SerializeField]
        InterfaceField<IInventory<ItemHS>> inventory;
        [Button]
        void Add(ItemHS item, int count)
        {
            inventory.i.AddItem(item, count);
        }
    }
}