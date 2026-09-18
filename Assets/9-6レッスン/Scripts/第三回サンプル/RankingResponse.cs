using System;

namespace Lesson3.Networking
{
    // JsonUtility はトップレベルの配列(例: [{...}, {...}])を直接読めないため、
    // { "ranking": [...] } という形でラップしたものを受け取る
    [Serializable]
    public class RankingResponse
    {
        public RankingEntry[] ranking;
    }
}
