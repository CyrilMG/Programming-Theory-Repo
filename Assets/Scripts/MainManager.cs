using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; } 

    public Settings settings;
    public PlayerInfo playerInfo;

    public LanguageText languageText;

    public AudioSource audioSource;
    public AudioClip soundInterractUI;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();

        audioSource.volume = settings.musicVolume;
    }


    [System.Serializable]
    class PersistantData
    {
        public Settings settings;
        public PlayerInfo playerInfo;
    }


    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PersistantData data = JsonUtility.FromJson<PersistantData>(json);

            settings = data.settings;
            playerInfo = data.playerInfo;

            LoadLanguage(settings.language);
        }
        else
        {
            LoadLanguage(Language.English);
        }

    }

    public void SaveData()
    {
        PersistantData persistantData = new PersistantData();
        persistantData.settings = settings;
        persistantData.playerInfo = playerInfo;

        string json = JsonUtility.ToJson(persistantData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        LoadData();
    }

    public void LoadLanguage(Language language)
    {
        var jsonFile = Resources.Load<TextAsset>("Localization/" + language.ToString());
        if (jsonFile != null)
        {;
            languageText = JsonUtility.FromJson<LanguageText>(jsonFile.text);
        }
    }

    public void LoadScene(string sceneName, float delay = 0f)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName, delay));
    }

    IEnumerator LoadSceneCoroutine(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
