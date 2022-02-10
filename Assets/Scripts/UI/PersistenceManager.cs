using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;
    public string bestPlayer = "Name";
    public string currentPlayer;
    public int bestScore = 0;
    public TMP_Text scoreToBeatText;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }


    [System.Serializable]
    class SaveData
    {
        public string bestPlayer;
        public int bestScore; 
    }
    void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestPlayer = data.bestPlayer;
            bestScore = data.bestScore;


            scoreToBeatText.text = "Score to Beat : " + bestPlayer +
                " : " + bestScore;
            scoreToBeatText.gameObject.SetActive(true);
        }
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestPlayer = bestPlayer;
        data.bestScore = bestScore;

    string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
