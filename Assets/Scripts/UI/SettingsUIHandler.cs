using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SettingsUIHandler : MonoBehaviour
{
    List<Language> languages = new List<Language>() { Language.English, Language.French};

    [SerializeField] TextMeshProUGUI textTitle;
    [SerializeField] TextMeshProUGUI textMusicVolume;
    [SerializeField] TextMeshProUGUI textEffectVolume;
    
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider effectVolumeSlider;

    [SerializeField] Button languageButton;
    [SerializeField] Button saveButton;
    [SerializeField] Button cancelButton;


    public static Settings settings;

    private void Start()
    {
        if (MainManager.Instance != null && MainManager.Instance.settings != null)
        {
            settings = new Settings();
            settings.musicVolume = MainManager.Instance.settings.musicVolume;
            settings.effectVolume = MainManager.Instance.settings.effectVolume;
            settings.language = MainManager.Instance.settings.language;

            musicVolumeSlider.value = settings.musicVolume;
            effectVolumeSlider.value = settings.effectVolume;

            ChangeLanguageText();
        }

        musicVolumeSlider.onValueChanged.AddListener(UpdateMusicVolume);
        effectVolumeSlider.onValueChanged.AddListener(UpdateEffectVolume);

        languageButton.onClick.AddListener(ChangeLanguage);
        saveButton.onClick.AddListener(Save);
        cancelButton.onClick.AddListener(Cancel);

    }

    public void Save()
    {
        MainManager.Instance.settings = settings;
        
        MainManager.Instance.SaveData();

        MainManager.Instance.LoadScene("Menu", 0.1f);
    }

    public void Cancel()
    {
        MainManager.Instance.LoadLanguage(settings.language);
        MainManager.Instance.audioSource.volume = MainManager.Instance.settings.musicVolume;

        MainManager.Instance.LoadScene("Menu", 0.1f);
    }

    private void UpdateMusicVolume(float value)
    {
        settings.musicVolume = value;
        MainManager.Instance.audioSource.volume = settings.musicVolume;
    }

    private void UpdateEffectVolume(float value)
    {
        settings.effectVolume = value;
    }

    public void ChangeLanguage()
    {
        int indexLanguage = languages.IndexOf(settings.language);
        if(indexLanguage == languages.Count - 1)
        {
            indexLanguage = 0;
        }
        else
        {
            indexLanguage++;
        }

        settings.language = languages[indexLanguage];

        ChangeLanguageText();
    }

    private void ChangeLanguageText()
    {
        MainManager.Instance.LoadLanguage(settings.language);

        textTitle.text = MainManager.Instance.languageText.SETTINGS_TITLE;
        textMusicVolume.text = MainManager.Instance.languageText.MUSIC_VOLUME;
        textEffectVolume.text = MainManager.Instance.languageText.EFFECT_VOLUME;

        languageButton.GetComponentInChildren<TextMeshProUGUI>().text = MainManager.Instance.languageText.LANGUAGE;
        saveButton.GetComponentInChildren<TextMeshProUGUI>().text = MainManager.Instance.languageText.SAVE_BUTTON;
        cancelButton.GetComponentInChildren<TextMeshProUGUI>().text = MainManager.Instance.languageText.CANCEL_BUTTON;
    }
}
