using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersJoin : MonoBehaviour
{
    public InputField PlayerNameInput;
    public Dropdown FoodPreferenceDropdown;
    public Button StartButton;
    public Button JoinButton;
    public Toggle CheckB;

    public int MinumumNumOfPlayers = 2;
    public int MaximumNumOfPlayers = 5;

    private PlayerSessionManager SessionManager;

    void Start ()
    {
        SessionManager = FindObjectOfType<PlayerSessionManager>();
        UpdateFoodPreferenceDropdown();
    }
	

    public void Join()
    {
        SessionManager.AddPlayer(PlayerNameInput.text, SessionManager.AvaiableFoodPreferenceTypes[FoodPreferenceDropdown.value]);
        PlayerNameInput.text = "";
        UpdateFoodPreferenceDropdown();

        
    }

    public void StartGame()
    {
        SessionManager.SetupPlayers();
        SessionManager.InitNextRound();
        GetComponent<Canvas>().enabled = false;
    }

    public void UpdateFoodPreferenceDropdown()
    {
        FoodPreferenceDropdown.options = new List<Dropdown.OptionData>();

        for (int i = 0; i < SessionManager.AvaiableFoodPreferenceTypes.Count; i++)
        {
            Dropdown.OptionData Data = new Dropdown.OptionData();
            Data.text = SessionManager.AvaiableFoodPreferenceTypes[i].DisplayName;
            FoodPreferenceDropdown.options.Add(Data);
        }

        FoodPreferenceDropdown.value = 0;
        FoodPreferenceDropdown.RefreshShownValue();
    }

    void Update()
    {
        if (PlayerNameInput.text.Length <= 0)
        {
            JoinButton.enabled = false;
            JoinButton.image.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            JoinButton.enabled = true;
            JoinButton.image.color = new Color(1, 1, 1, 1);
        }


        if (SessionManager.Players.Count >= MaximumNumOfPlayers)
        {
            PlayerNameInput.gameObject.SetActive(false);
            FoodPreferenceDropdown.gameObject.SetActive(false);
            JoinButton.gameObject.SetActive(false);
        }

        if (SessionManager.Players.Count >= MinumumNumOfPlayers && CheckB.isOn)
        {
            StartButton.gameObject.SetActive(true);
        }
        else
        {
            StartButton.gameObject.SetActive(false);
        }
    }
}
