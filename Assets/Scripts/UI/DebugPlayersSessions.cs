using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugPlayersSessions : MonoBehaviour {

    // Use this for initialization
    private PlayerSessionManager SessionManager;

    void Start()
    {
        SessionManager = FindObjectOfType<PlayerSessionManager>();

    }
	
	// Update is called once per frame
	void Update ()
    {
       var t = GetComponent<Text>();
        t.text = "";

        for (int i = 0; i < SessionManager.Players.Count; i++)
        {
            t.text += "\n<b>" + SessionManager.Players[i].PlayerID + ":</b> " + SessionManager.Players[i].PreferenceType.DisplayName;
        }
	}
}
