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
    private List<InventoryItem> Items;

    [SerializeField]
    private List<FoodPreferenceType> FoodPreferenceTypes;
    private int RoundTime = 5;
    public List<FoodPreferenceType> AvaiableFoodPreferenceTypes { get; private set; }

    public SessionPlayer CurrentPlayer { get; private set; }
    public SessionRound CurrentSessionType { get; private set; }
    public List<SessionPlayer> Players { get; private set; }

    public GameObject PlayerController;
    public GameObject PlayerControllerInstance;

    public PlayerStart PlayerStartUI;

    public ScoreUI ScoreUIObject;

    public int Timeleft;

    private int CurrentPlayerIndex;

    void Start()
    {
        ResetSessions();
    }

    public void AddPlayer(string PlayerID, FoodPreferenceType PreferenceType)
    {
        AvaiableFoodPreferenceTypes.Remove(PreferenceType);

        var Player = new SessionPlayer(PlayerID, PreferenceType);
        Players.Add(Player);
    }

    public void StartRound()
    {
        PlayerControllerInstance = Instantiate(PlayerController, Vector3.zero, Quaternion.identity);
        PlayerControllerInstance.GetComponentInChildren<FirstPersonRaycastComponent>().CurrentPlayer = CurrentPlayer;

        StartCoroutine(StartRoundCounter());
    }

    public void SetupPlayers()
    {
        for (int i = 0; i < Players.Count; i++)
        {
            var p = Players[i];

            for (int j = 0; j < Players.Count; j++)
            {
                if (p != Players[j])
                {
                    var item = Instantiate(GetRandomItemByFoodPreference(Players[j].PreferenceType));
                    item.Owner = p;
                    p.PlayerInventory.AddItem(item);
                }
            }
        }
    }

    public void InitNextRound()
    {
        CurrentPlayerIndex += 1;

        if (CurrentPlayerIndex < Players.Count)
        {
            CurrentPlayer = Players[CurrentPlayerIndex];

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
            ScoreUIObject.GetComponent<Canvas>().enabled = true;
            ScoreUIObject.enabled = true;
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
        Destroy(PlayerControllerInstance);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Debug.Log("Session Ended");
        InitNextRound();
    }

    IEnumerator StartRoundCounter()
    {
        for (int i = RoundTime; i >= 0 ; i--)
        {
            Timeleft = i;
            yield return new WaitForSeconds(1f);
            Debug.Log(i);
        }

        SessionEnded();
    }

    public InventoryItem GetRandomItemByFoodPreference(FoodPreferenceType Preference)
    {
        List<InventoryItem> AcceptableItems = new List<InventoryItem>();
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].CanIEatThat(Preference))
            {
                AcceptableItems.Add(Items[i]);
            }
        }

        return AcceptableItems[Random.Range(0, AcceptableItems.Count - 1)];
    }
}
