using System;

namespace Lesson3.Networking
{
    // ランキング1件分のデータ
    [Serializable]
    public class RankingEntry
    {
        public string playerName;
        public int score;
    }
}
