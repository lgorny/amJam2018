using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersJoin : MonoBehaviour
{
    public InputField PlayerNameInput;
    public Dropdown FoodPreferenceDropdown;

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
}
