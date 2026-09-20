using System;
using UnityEngine;

[Serializable]
public class ScoreData
{
    public string playerName;
    public int score;

    public ScoreData(string playerName, int score)
    {
        this.playerName = playerName;
        this.score = score;
    }
}
