using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataPersistenceMangager : MonoBehaviour
{
    public static DataPersistenceMangager instance {
        get;
        private set;
    }

    public string userName = "";
    public int higestScore = 0;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [Serializable]
    class SaveData
    {
        public string userName;
        public int higestScore;
    }

    public void SaveUserData()
    {
        SaveData data = new SaveData();
        data.userName = userName;
        data.higestScore = higestScore;
        String json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/save_data.json", json);
    }

    public void LoadUserData()
    {
        string path = Application.persistentDataPath + "/save_data.json";
        if (File.Exists(path))
        {
            SaveData data = JsonUtility.FromJson<SaveData>(File.ReadAllText(path));
            userName = data.userName;
            higestScore = data.higestScore;
        }
    }
}
