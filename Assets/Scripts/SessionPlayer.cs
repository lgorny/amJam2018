using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionPlayer
{
    private const int PointsNoOwner = 1;
    private const int PointsOtherOwner = 3;

    public string PlayerID;
    public Inventory PlayerInventory;
    public FoodPreferenceType PreferenceType;

    public SessionPlayer(string PlayerID, FoodPreferenceType PreferenceType)
    {
        this.PlayerID = PlayerID;
        this.PreferenceType = PreferenceType;

        PlayerInventory = new Inventory();
    }

    public int GetPoints()
    {
        int Points = 0;

        foreach (KeyValuePair<InventoryItem, int> Item in PlayerInventory.Items)
        {
            if (Item.Key.Owner == null)
            {
                Points += Item.Value * Item.Key.Points * PointsNoOwner;
            }
            else if (Item.Key.Owner != this)
            {
                Points += Item.Value * Item.Key.Points * PointsOtherOwner;
            }
        }

        return Points;
    }
}
