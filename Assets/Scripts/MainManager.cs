using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }

    public Settings settings;

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
    }


    [System.Serializable]
    class PersistantData
    {
        public Settings settings;
    }


    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PersistantData data = JsonUtility.FromJson<PersistantData>(json);

            settings = data.settings;

        }
    }

    public void SaveData()
    {
        PersistantData persistantData = new PersistantData();
        persistantData.settings = settings;

        string json = JsonUtility.ToJson(persistantData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        LoadData();
    }
}
