using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectPlayerUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TMP_InputField playerNameField;
    [SerializeField] Button playButton;

    [SerializeField] List<GameObject> characters;
    int currentCharacter = 0;

    void Start()
    {
        if (MainManager.Instance != null && MainManager.Instance.settings != null)
        {
            ChangeLanguageText();
        }

        characters[currentCharacter].SetActive(true);
    }



    private void ChangeLanguageText()
    {
        titleText.text = MainManager.Instance.languageText.SELECT_PLAYER_TITLE;
        playerNameField.placeholder.GetComponent<TextMeshProUGUI>().text = MainManager.Instance.languageText.ENTER_PLAYER_NAME;
        playButton.GetComponentInChildren<TextMeshProUGUI>().text = MainManager.Instance.languageText.PLAY_BUTTON;
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            NextCharacter();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            PreviousCharacter();
        }

    }

    void NextCharacter()
    {
        if (currentCharacter + 1 == characters.Count)
            currentCharacter = 0;
        else
            currentCharacter++;

        DesactiveAllCharacters();
        characters[currentCharacter].SetActive(true);
    }

    void PreviousCharacter()
    {
        if (currentCharacter == 0)
            currentCharacter = characters.Count - 1;
        else
            currentCharacter--;

        DesactiveAllCharacters();
        characters[currentCharacter].SetActive(true);
    }

    void DesactiveAllCharacters()
    {
        foreach(GameObject character in characters)
        {
            character.SetActive(false);
        }
    }
}
