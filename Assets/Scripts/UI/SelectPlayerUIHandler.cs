using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectPlayerUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI titleText;

    [SerializeField] Button manButton;
    [SerializeField] Button womanButton;

    [SerializeField] Button leftButton;
    [SerializeField] Button rightButton;

    [SerializeField] TMP_InputField playerNameField;
    [SerializeField] Button playButton;

    [SerializeField] List<GameObject> manCharacters;
    [SerializeField] List<GameObject> womanCharacters;
    int currentCharacter = 0;

    int currenSexe = 0;

    ColorBlock activeColor;
    ColorBlock inactiveColor;
    

    void Start()
    {
        if (MainManager.Instance != null && MainManager.Instance.settings != null)
        {
            ChangeLanguageText();
        }

        manButton.onClick.AddListener(delegate { SelectSexe(0); });
        womanButton.onClick.AddListener(delegate { SelectSexe(1); });

        leftButton.onClick.AddListener(PreviousCharacter);
        rightButton.onClick.AddListener(NextCharacter);

        playerNameField.onEndEdit.AddListener(SetPlayerName);

        playButton.onClick.AddListener(Play);
        playButton.interactable = false;

        manCharacters[currentCharacter].SetActive(true);

        activeColor = manButton.colors;
        inactiveColor = womanButton.colors;

    }

    void Play()
    {
        PlayerInfo playerInfo = new PlayerInfo();
        playerInfo.playerName = playerNameField.text;
        playerInfo.playerSexe = currenSexe;
        playerInfo.playerCharacter = currenSexe == 0 ? manCharacters[currentCharacter].name : womanCharacters[currentCharacter].name;

        MainManager.Instance.playerInfo = playerInfo;

        MainManager.Instance.SaveData();

        MainManager.Instance.LoadScene("Game", 0.1f);
    }

    private void ChangeLanguageText()
    {
        titleText.text = MainManager.Instance.languageText.SELECT_PLAYER_TITLE;
        playerNameField.placeholder.GetComponent<TextMeshProUGUI>().text = MainManager.Instance.languageText.ENTER_PLAYER_NAME;
        playButton.GetComponentInChildren<TextMeshProUGUI>().text = MainManager.Instance.languageText.PLAY_BUTTON;
    }

    void SetPlayerName(string playerName)
    {
        if (!string.IsNullOrEmpty(playerName))
        {
            playButton.interactable = true;
        }
        else
        {
            playButton.interactable = false;
        }
    }

    void SelectSexe(int sexe)
    {
        if(sexe == 0)
        {
            currenSexe = 0;
            currentCharacter = 0;
            SelectCharacter();

            manButton.colors = activeColor;
            womanButton.colors = inactiveColor;
        }
        else
        {
            currenSexe = 1;
            currentCharacter = 0;
            SelectCharacter();

            womanButton.colors = activeColor;
            manButton.colors = inactiveColor;
        }
    }

    void NextCharacter()
    {
        if (currenSexe == 0)
        {
            if (currentCharacter + 1 == manCharacters.Count)
                currentCharacter = 0;
            else
                currentCharacter++;

            SelectCharacter();
        }
        else
        {
            if (currentCharacter + 1 == womanCharacters.Count)
                currentCharacter = 0;
            else
                currentCharacter++;

            SelectCharacter();
        }
    }

    void PreviousCharacter()
    {
        if (currenSexe == 0)
        {
            if (currentCharacter == 0)
                currentCharacter = manCharacters.Count - 1;
            else
                currentCharacter--;

            SelectCharacter();
        }
        else
        {
            if (currentCharacter == 0)
                currentCharacter = womanCharacters.Count - 1;
            else
                currentCharacter--;

            SelectCharacter();
        }
    }

    void SelectCharacter()
    {
        DesactiveAllCharacters();

        if(currenSexe == 0)
            manCharacters[currentCharacter].SetActive(true);
        else
            womanCharacters[currentCharacter].SetActive(true);
    }

    void DesactiveAllCharacters()
    {
        foreach(GameObject character in manCharacters)
        {
            character.SetActive(false);
        }

        foreach(GameObject character in womanCharacters)
        {
            character.SetActive(false);
        }
    }
}
