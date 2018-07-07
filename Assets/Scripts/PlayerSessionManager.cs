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

    [SerializeField]
    private List<FoodPreferenceType> FoodPreferenceTypes;
    public List<FoodPreferenceType> AvaiableFoodPreferenceTypes { get; private set; }

    public SessionPlayer CurrentPlayer { get; private set; }
    public SessionRound CurrentSessionType { get; private set; }
    public List<SessionPlayer> Players { get; private set; }

    private int CurrentPlayerIndex;

    void Start()
    {
        ResetSessions();
    }

    public void AddPlayer(string PlayerID, FoodPreferenceType PreferenceType)
    {
        AvaiableFoodPreferenceTypes.Remove(PreferenceType);
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
        AvaiableFoodPreferenceTypes = new List<FoodPreferenceType>(FoodPreferenceTypes);
        CurrentPlayerIndex = -1;
    }
}
