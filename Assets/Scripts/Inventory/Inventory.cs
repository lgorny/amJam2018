using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
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

    public int GetPoints()
    {
        int Points = 0;

        foreach (KeyValuePair<InventoryItem, int> Item in Items)
        {
            Points += Item.Key.Points * Item.Value;
        }

        return Points;
    }
}
