using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public Dictionary<InventoryItem, int> Items;

    public void RemoveItem(InventoryItem Item)
    {
        if (Items[Item] > 1)
        {
            Items[Item] -= 0;
        }
        else if(Items.ContainsKey(Item))
        {
            Items.Remove(Item);
        }
    }

    public void AddItem(InventoryItem Item)
    {
        if (Items.ContainsKey(Item))
            Items[Item] += 1;
        else
            Items.Add(Item, 1);
    }
}
