using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "InventoryItem", order = 1)]
public class InventoryItem : ScriptableObject
{
    public FoodCategory[] Category;
    public FoodPreferenceType[] AcceptablePreferences;

    public int Points;
    public GameObject Prefab;

    public SessionPlayer Owner;

    public void Spawn(Vector3 Position, Quaternion Rotation)
    {
        SceneItem Item = Instantiate(Prefab).GetComponent<SceneItem>();
        Item.transform.position = Position;
        Item.transform.rotation = Rotation;

        Item.Init(this);
    }

    public bool CanIEatThat(FoodPreferenceType Preference)
    {
        for (int i = 0; i < AcceptablePreferences.Length; i++)
        {
            if (AcceptablePreferences[i].GetType() == Preference.GetType())
                return true;
        }

        return false;
    }
}
