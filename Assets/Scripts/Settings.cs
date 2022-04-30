using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Settings
{
    public Language language = Language.English;

    public float musicVolume = 1f;
    public float effectVolume = 1f;
}


public enum Language
{
    English,
    French
}