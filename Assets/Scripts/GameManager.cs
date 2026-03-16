using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string playerName;
    public int playerScore;


    public int highScore = 0;
    public string highScorePlayerName = "None";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [System.Serializable]
    class HighScoreData
    {
        public string playerName;
        public int playerScore;
    }

    public void SaveHighScore(string playerName, int playerScore)
    {
        if (playerScore > highScore)
        {
            highScorePlayerName = playerName;
            highScore = playerScore;

            HighScoreData data = new HighScoreData();
            data.playerName = playerName;
            data.playerScore = playerScore;
            string json = JsonUtility.ToJson(data);
            Debug.Log(Application.persistentDataPath);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }

    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);

            highScorePlayerName = data.playerName;
            highScore = data.playerScore;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
        }
    }

}