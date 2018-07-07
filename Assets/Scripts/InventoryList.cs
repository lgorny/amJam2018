using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryList : MonoBehaviour
{
    // Use this for initialization
    private PlayerSessionManager SessionManager;

    void Start()
    {
        SessionManager = FindObjectOfType<PlayerSessionManager>();        
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateList();

    }

    public void UpdateList()
    {
        var childs = GetComponentsInChildren<Transform>();

        for (int i = 0; i < childs.Length; i++)
        {
            if(childs[i].gameObject != gameObject)
                Destroy(childs[i].gameObject);
        }

        float currY = 0f;

        for (int i = 0; i < SessionManager.CurrentPlayer.PlayerInventory.Items.Count; i++)
        {           
            var it = Instantiate(SessionManager.CurrentPlayer.PlayerInventory.Items[i].Prefab);
            it.transform.parent = transform;
            it.transform.localPosition = new Vector3(i % 2 * 50f, 50f * currY, 0f);
            it.transform.localScale = new Vector3(20f, 20f, 20f);
            it.layer = 12;

            if (i % 2 == 1)
                currY += 1;
        }
    }
}
