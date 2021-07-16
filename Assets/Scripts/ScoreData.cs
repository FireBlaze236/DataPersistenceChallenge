using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[DefaultExecutionOrder(-1000)]
public class ScoreData : MonoBehaviour
{
    public static ScoreData Instance;

    private string filename = "/dpc_highscore.json";

    public string bestPlayer = "";
    public int currentHighscore = 0;
    public string playerName = "NoName";
    public int playerScore = 0;


    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadHighScore();
        }
    }

    public void SetCurrentPlayerName(string newName)
    {
        this.playerName = newName;
    }

    public class SaveData
    {
        public string name = "default";
        public int score = 0;

        public SaveData(string n, int s)
        {
            name = n;
            score = s;
        }
    }

    public void SaveHighScore(int newScore)
    {
        if (currentHighscore >= newScore) return;

        currentHighscore = newScore;
        bestPlayer = playerName;

        SaveData sd = new SaveData(playerName, newScore);

        string data = JsonUtility.ToJson(sd);
        string path = Application.persistentDataPath + filename;

        File.WriteAllText(path, data);

        
    }
    private SaveData LoadHighScore()
    {
        string path = Application.persistentDataPath + filename;
        if(File.Exists(path))
        {
            string data = File.ReadAllText(path);
            SaveData sd = JsonUtility.FromJson<SaveData>(data);
            currentHighscore = sd.score;
            bestPlayer = sd.name;
            return sd;
        }
        else
        {
            return new SaveData("", 0);
        }
    }
}
