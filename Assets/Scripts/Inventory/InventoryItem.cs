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

    public Vector3 InventoryScale = new Vector3(500f, 500f, 500f);

    [HideInInspector]
    public SessionPlayer Owner;

    public GameObject Spawn(Vector3 Position)
    {
        SceneItem Item = Instantiate(Prefab).GetComponent<SceneItem>();
        Item.transform.position = Position;

        Item.Init(this);
        return Item.gameObject;
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
