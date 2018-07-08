using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStart : MonoBehaviour
{

    private PlayerSessionManager SessionManager;
    public Text PlayerName;

    void Start()
    {
        SessionManager = FindObjectOfType<PlayerSessionManager>();     
	}

    public void UpdateContent()
    {
        PlayerName.text = "<b>" + SessionManager.CurrentPlayer.PlayerID + "</b> przygotuj się!";
    }

    public void StartGame()
    {
        SessionManager.StartRound();
        GetComponent<Canvas>().enabled = false;
    }
}
