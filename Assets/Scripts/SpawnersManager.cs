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
        Spawners.AddRange(GameObject.FindObjectsOfType<SceneItemSpawner>());

        SpawnRandomItems(5);
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
