namespace HS
{
    public interface IItemUser<T>
    {
        bool TryUseItems(IInventory<T> inventory);
    }
}
