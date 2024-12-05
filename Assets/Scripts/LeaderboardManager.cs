using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    private string filePath;
    public Leaderboard leaderboard;

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/leaderboard.json";
        LoadLeaderboard();
    }

    public void AddEntry(string name, int score)
    {
        // add new score
        leaderboard.entries.Add(new LeaderboardEntry(name, score));
        // sort leaderboard
        leaderboard.entries.Sort((entry1, entry2) => entry2.score.CompareTo(entry1.score));


    }

    public void SaveLeaderboard()
    {
        string jsonFile = JsonUtility.ToJson(leaderboard, true);
        File.WriteAllText(filePath, jsonFile);
    }

    public Leaderboard LoadLeaderboard()
    {
        if(File.Exists(filePath))
        {
            string jsonFile = File.ReadAllText(filePath);
            leaderboard = JsonUtility.FromJson<Leaderboard>(jsonFile);
        }
        else
        {
            leaderboard = new Leaderboard();
        }

        return leaderboard;
    }
}
