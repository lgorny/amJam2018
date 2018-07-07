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
    private int RoundTime = 5;
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

    public void StartRound()
    {
        StartCoroutine(StartRoundCounter());
    }

    public void InitNextRound()
    {
        CurrentPlayerIndex += 1;

        if (CurrentPlayerIndex < Players.Count)
        {
            CurrentPlayer = Players[CurrentPlayerIndex];

            var PlayerStartUI = FindObjectOfType<PlayerStart>();
            PlayerStartUI.UpdateContent();
            PlayerStartUI.GetComponent<Canvas>().enabled = true;
        }
        else if(CurrentSessionType == SessionRound.Hide)
        {
            CurrentSessionType = SessionRound.Seek;
            CurrentPlayerIndex = -1;

            InitNextRound();
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

    public void SessionEnded()
    {
        Debug.Log("Session Ended");
        InitNextRound();
    }

    IEnumerator StartRoundCounter()
    {
        for (int i = RoundTime; i >= 0 ; i--)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log(i);
        }

        SessionEnded();
    }
}
