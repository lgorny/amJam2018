using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersManager : MonoBehaviour
{
    public List<InventoryItem> SpawnableRandomItems;

    private List<SceneItemSpawner> Spawners;

    void Start ()
    {
        Spawners = new List<SceneItemSpawner>();
        Spawners.AddRange(FindObjectsOfType<SceneItemSpawner>());
    }

    public void SpawnItems(List<InventoryItem> Items)
    {
        List<SceneItemSpawner> SpawnersTemp = new List<SceneItemSpawner>();
        SpawnersTemp.AddRange(Spawners);

        while (Items.Count > 0 && SpawnersTemp.Count > 0)
        {
            int Index = Random.Range(0, SpawnersTemp.Count - 1);
            int ItemIndex = Random.Range(0, Items.Count - 1);

            SceneItemSpawner Spawner = SpawnersTemp[Index];
            Spawner.Spawn(Items[ItemIndex]);

            SpawnersTemp.RemoveAt(Index);
            Items.RemoveAt(ItemIndex);
        }
    }

    public void SpawnRandomItems(int Number)
    {
        List<SceneItemSpawner> SpawnersTemp = new List<SceneItemSpawner>();
        SpawnersTemp.AddRange(Spawners);

        while (Number > 0 && SpawnersTemp.Count > 0)
        {
            int Index = Random.Range(0, SpawnersTemp.Count - 1);
            SceneItemSpawner Spawner = SpawnersTemp[Index];
            Spawner.Spawn(SpawnableRandomItems[Random.Range(0, SpawnableRandomItems.Count - 1)]);

            SpawnersTemp.RemoveAt(Index);
            Number--;
        }
    }
}
