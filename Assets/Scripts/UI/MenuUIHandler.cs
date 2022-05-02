using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] Button newGameButton;
    [SerializeField] Button continueButton;
    [SerializeField] Button settingsButton;
    [SerializeField] Button quitButton;

    private void Start()
    {
        if(MainManager.Instance != null && MainManager.Instance.settings != null)
        {
            ChangeLanguageText();

            if (MainManager.Instance.playerInfo == null || string.IsNullOrEmpty(MainManager.Instance.playerInfo.playerName))
                continueButton.interactable = false;
        }

        newGameButton.onClick.AddListener(NewGame);
        continueButton.onClick.AddListener(Continue);
        settingsButton.onClick.AddListener(Settings);
        quitButton.onClick.AddListener(Quit);

    }

    public void NewGame()
    {
        // Clear Data
        MainManager.Instance.LoadScene("SelectPlayer", 0.1f);
    }

    public void Continue()
    {
        // Load Data
        MainManager.Instance.LoadScene("Game", 0.1f);
    }

    public void Settings()
    {
        MainManager.Instance.LoadScene("Settings", 0.1f);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }


    private void ChangeLanguageText()
    {
        newGameButton.GetComponentInChildren<TextMeshProUGUI>().text = MainManager.Instance.languageText.NEW_GAME_BUTTON;
        continueButton.GetComponentInChildren<TextMeshProUGUI>().text = MainManager.Instance.languageText.CONTINUE_BUTTON;
        settingsButton.GetComponentInChildren<TextMeshProUGUI>().text = MainManager.Instance.languageText.SETTINGS_BUTTON;
        quitButton.GetComponentInChildren<TextMeshProUGUI>().text = MainManager.Instance.languageText.QUIT_BUTTON;
    }
}
