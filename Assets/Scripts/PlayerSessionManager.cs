using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSessionManager : MonoBehaviour
{
    public enum SessionRound
    {
        Hide,
        Seek
    }

    public SessionPlayer CurrentPlayer { get; private set; }
    public SessionRound CurrentSessionType { get; private set; }

    private List<SessionPlayer> Players;
    private int CurrentPlayerIndex;

    public void AddPlayer(string PlayerID, FoodPreferenceType PreferenceType)
    {
        Players.Add(new SessionPlayer(PlayerID, PreferenceType));
    }

    public void StartNextRound()
    {
        CurrentPlayerIndex += 1;

        if (CurrentPlayerIndex < Players.Count)
        {
            CurrentPlayer = Players[CurrentPlayerIndex];
        }
        else if(CurrentSessionType == SessionRound.Hide)
        {
            CurrentSessionType = SessionRound.Seek;
            CurrentPlayerIndex = -1;

            StartNextRound();
        }
        else
        {
            //END GAME?
        }
    }

    public void ResetSessions()
    {
        Players = new List<SessionPlayer>();
        CurrentPlayerIndex = -1;
    }
}
