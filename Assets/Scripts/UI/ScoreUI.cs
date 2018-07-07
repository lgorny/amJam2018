using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{

    private PlayerSessionManager SessionManager;
    public Text PlayerName;

    void Start()
    {
        SessionManager = FindObjectOfType<PlayerSessionManager>();

        List<SessionPlayer> PlayerSorted = SessionManager.Players.OrderBy(o => o.GetPoints()).ToList();       
        PlayerName.text = "";

        Debug.Log("PlayerSorted: " + PlayerSorted.Count);

        for (int i = PlayerSorted.Count - 1; i >= 0; i--)
        {
            Debug.Log(PlayerSorted[i].GetPoints());

            if(i == PlayerSorted.Count - 1)
                PlayerName.text += "<color=" + '"'.ToString() + "#ff0000ff" + '"'.ToString() + ">" + PlayerSorted[i].PlayerID + ": " + PlayerSorted[i].GetPoints() + "</color>\n";
            else
                PlayerName.text += PlayerSorted[i].PlayerID + ": " + PlayerSorted[i].GetPoints() + "\n";
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
