using System;

namespace Lesson3.Networking
{
    // サーバー(GAS)に送信するスコアデータ
    // JsonUtility.ToJson でそのままJSON文字列に変換できるように [Serializable] を付ける
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
}
