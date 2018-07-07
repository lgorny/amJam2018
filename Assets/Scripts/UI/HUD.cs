using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text TimeText;
    public Text ScoreText;

    public GameObject ListHolder;

    public PlayerSessionManager SessionManager;

    void Start ()
    {
        SessionManager = FindObjectOfType<PlayerSessionManager>();
    }
	
	void Update ()
    {
        TimeSpan t = TimeSpan.FromSeconds(SessionManager.Timeleft);

        string time = string.Format("{0:D2}m:{1:D2}s",
                        t.Minutes,
                        t.Seconds);

        TimeText.text = time;

        ScoreText.text = "Punkty: " + SessionManager.CurrentPlayer.GetPoints();
    }

    public void UpdateList()
    {
        SessionManager = FindObjectOfType<PlayerSessionManager>();

        var p = Instantiate(SessionManager.CurrentPlayer.PreferenceType.ItemsList);

        if (ListHolder.transform.childCount > 0)
            Destroy(ListHolder.transform.GetChild(0).gameObject);

        p.transform.parent = ListHolder.transform;
        p.transform.localPosition = Vector3.zero;
        p.transform.localScale = new Vector3(300, 300, 300);
        p.transform.localRotation = Quaternion.identity;
    }
}
