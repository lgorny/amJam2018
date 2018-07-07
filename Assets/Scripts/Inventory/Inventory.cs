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

    public void SpawnSelected(Vector3 Position)
    {
        if (Items.Count > 0)
        {
            Items[Items.Count -1].Spawn(Position);
            RemoveItem(Items[Items.Count - 1]);
        }

    }
}
