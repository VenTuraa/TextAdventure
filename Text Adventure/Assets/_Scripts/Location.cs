using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace _Scripts
{
    public class Location : MonoBehaviour
    {
        [SerializeField] private List<Item> items = new();

        public List<Item> Items => items;

        public string GetItemsText()
        {
            if (items.Count == 0) return "";

            bool first = true;
            StringBuilder result = new StringBuilder("You see ");
            foreach (var item in items)
            {
                if (!first) result.Append(" and ");
                result.Append(item.Name.ToLower());
                first = false;
            }

            result.Append("\n");
            return result.ToString();
        }

        public bool HasItem(string itemToCheck)
        {
            return items.Any(item => item.Name.ToLower() == itemToCheck);
        }

        public void RemoveItem(Item item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
            }
        }
    }
}