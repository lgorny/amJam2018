using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneItem : MonoBehaviour
{
    public InventoryItem ItemDescription;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Init(InventoryItem Descripton)
    {
        ItemDescription = Descripton;
    }

    public void Collect()
    {
        Destroy(gameObject);
    }
}
