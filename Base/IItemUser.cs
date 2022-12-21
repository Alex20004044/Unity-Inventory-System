using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HS
{
    public interface IItemUser<T>
    {
        bool TryUseItems(IInventory<T> inventory);
    }
}