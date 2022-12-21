using CorD.SparrowInterfaceField;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HS
{
    public class DisplayItemCountHS : DisplayItemCountBase<ItemHS>
    {
        [SerializeField]
        InterfaceField<IInventory<ItemHS>> inventory;

        private void Start()
        {
            Init(inventory.i);
        }
    }
}