using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneItemSpawner : MonoBehaviour
{
    public void Spawn(InventoryItem ItemDescription)
    {
        var g = Instantiate(ItemDescription).Spawn(transform.position);
        g.GetComponent<SceneItem>().ItemDescription.Owner = null;
        Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "Spawn.png");
    }
}
