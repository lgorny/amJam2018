using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text TimeText;
    public Text ScoreText;

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

    }
}
