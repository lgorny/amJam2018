using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SessionPlayer
{
    private const int PointsNoOwner = 1;
    private const int PointsOtherOwner = 3;
    private const int PointsHidePenalty = 1;
    private const int PointsWrongItemPenalty = 1;

    public string PlayerID;
    public Inventory PlayerInventory;
    public Inventory PlayerHideInventory;
    public FoodPreferenceType PreferenceType;

    public SessionPlayer(string PlayerID, FoodPreferenceType PreferenceType)
    {
        this.PlayerID = PlayerID;
        this.PreferenceType = PreferenceType;

        PlayerInventory = new Inventory();
        PlayerHideInventory = new Inventory();
    }

    public int GetPoints()
    {
        int Points = 0;

        for (int i = 0; i < PlayerInventory.Items.Count; i++)
        {
            if (PlayerInventory.Items[i].CanIEatThat(PreferenceType))
            {
                if (PlayerInventory.Items[i].Owner == null)
                {
                    Points += PlayerInventory.Items[i].Points * PointsNoOwner;
                }
                else if (PlayerInventory.Items[i].Owner != this)
                {
                    Points += PlayerInventory.Items[i].Points * PointsOtherOwner;
                }
            }
            else
            {
                Points -= PointsWrongItemPenalty;
            }

        }

        Points -= PlayerHideInventory.Items.Count * PointsHidePenalty;

        return Points;
    }
}
