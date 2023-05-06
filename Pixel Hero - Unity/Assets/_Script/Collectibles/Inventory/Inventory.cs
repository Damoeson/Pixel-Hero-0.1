using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Damoeson
{
    public class Inventory : MonoBehaviour
    {
        public List<InventoryItem> inventory = new List<InventoryItem>();
        private Dictionary<ItemData, InventoryItem> itemDictionnary = new Dictionary<ItemData, InventoryItem>();

        private void OnEnable()
        {
            TestCoin.OnCoinCollected += Add;
        }

        private void OnDisable()
        {
            TestCoin.OnCoinCollected -= Add;
        }

        public void Add (ItemData itemData)
        {
            if (itemDictionnary.TryGetValue(itemData, out InventoryItem item))
            {
                item.AddToStack();
                Debug.Log($"{item.itemData.Name} total stack is now {item.stackSize}.");
            }

            else
            {
                InventoryItem newItem = new InventoryItem(itemData);
                inventory.Add(newItem);
                itemDictionnary.Add(itemData, newItem);
                Debug.Log($"Added {itemData.Name} to the inventory for the first time.");
            }
        }

        public void Remove (ItemData itemData)
        {
            if (itemDictionnary.TryGetValue(itemData, out InventoryItem item))
            {
                item.RemoveFromStack();

                if (item.stackSize == 0)
                {
                    inventory.Remove(item);
                    itemDictionnary.Remove(itemData);

                }
            }
        }
    }
}
