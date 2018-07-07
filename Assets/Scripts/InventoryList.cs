using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryList : MonoBehaviour
{
    // Use this for initialization
    private PlayerSessionManager SessionManager;

    float t = 0;

    void Start()
    {
        SessionManager = FindObjectOfType<PlayerSessionManager>();
        UpdateList();
    }
	
	// Update is called once per frame
	void Update ()
    {
        t += Time.deltaTime;
        if (t > 1f)
        {
            UpdateList();
            t = 0;
        }

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

        for (int i = 0; i < SessionManager.CurrentPlayer.PlayerHideInventory.Items.Count; i++)
        {           
            var it = Instantiate(SessionManager.CurrentPlayer.PlayerHideInventory.Items[i].Prefab);
            it.transform.parent = transform;
            it.transform.localPosition = new Vector3(i % 2 * 50f, -50f * currY, 0f);
            it.transform.localScale = SessionManager.CurrentPlayer.PlayerHideInventory.Items[i].InventoryScale;
            it.transform.localRotation = Quaternion.identity;
            it.layer = 12;

            Destroy(it.GetComponent<Rigidbody>());

            var c = it.GetComponentsInChildren<Transform>();

            for (var j = 0; j < c.Length; j++)
            {

                c[j].gameObject.layer = 12;
            }

            if (i % 2 == 1)
                currY += 1;
        }
    }
}
