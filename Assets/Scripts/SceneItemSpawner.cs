using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneItemSpawner : MonoBehaviour
{
    public void Spawn(InventoryItem ItemDescription)
    {
        ItemDescription.Spawn(transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "Spawn.png");
    }
}
