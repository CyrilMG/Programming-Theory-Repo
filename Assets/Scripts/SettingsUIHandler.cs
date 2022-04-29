using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsUIHandler : MonoBehaviour
{
    [SerializeField] Slider musicVolumeSlider;
    Settings settings;

    private void Start()
    {
        if(MainManager.Instance != null && MainManager.Instance.settings != null)
        {
            settings = new Settings();
            settings.musicVolume = MainManager.Instance.settings.musicVolume;

            musicVolumeSlider.value = settings.musicVolume;

        }

        musicVolumeSlider.onValueChanged.AddListener((value) => settings.musicVolume = value );
    }

    public void Save()
    {
        MainManager.Instance.settings = settings;
        
        MainManager.Instance.SaveData();

        BackToMenu();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
