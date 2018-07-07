using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public List<InventoryItem> Items = new List<InventoryItem>();

    public void RemoveItem(InventoryItem Item)
    {
        Items.Remove(Item);
    }

    public void AddItem(InventoryItem Item)
    {
        Debug.Log(Item.name);

        Items.Add(Item);
    }
}
