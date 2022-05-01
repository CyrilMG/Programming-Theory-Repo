using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SoundSlider : MonoBehaviour, IPointerUpHandler
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = MainManager.Instance.soundInterractUI;
    }

    public void OnPointerUp(PointerEventData data)
    {
        PlaySound();
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
