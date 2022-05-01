using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SoundButton : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GetComponent<Button>().onClick.AddListener(PlaySound);
        audioSource.clip = MainManager.Instance.soundInterractUI;
    }

    void PlaySound()
    {
        if (SceneManager.GetActiveScene().name == "Settings")
            audioSource.volume = SettingsUIHandler.settings.effectVolume;
        else
            audioSource.volume = MainManager.Instance.settings.effectVolume;
        
        audioSource.Play();
    }

}
