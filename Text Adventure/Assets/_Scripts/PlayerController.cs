using System.Collections.Generic;

namespace _Scripts
{
    public class PlayerController
    {
        public List<Item> Inventory { get; } = new();


        public void AddToInventory(Item item)
        {
            Inventory.Add(item);
        }

        public void RemoveFromInventory(Item item)
        {
            if (Inventory.Contains(item))
            {
                Inventory.Remove(item);
            }
        }
    }
}