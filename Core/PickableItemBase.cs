using UnityEngine;
using UnityEngine.Events;

namespace HS
{
    public class PickableItemBase<T> : MonoBehaviour, IInteractable
    {
        [SerializeField]
        T itemKey;
        [SerializeField]
        int itemCount = 1;
        [SerializeField]
        UnityEvent onInteract;

        public bool TryInteract(GameObject initiator)
        {
            if (!initiator.TryGetComponent(out IInventory<T> inventory))
                return false;

            inventory.AddItem(itemKey, itemCount);
            onInteract.Invoke();
            return true;
        }
    }
}