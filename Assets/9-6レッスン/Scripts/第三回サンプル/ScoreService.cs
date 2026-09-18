using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Lesson3.Networking
{
    // Google Apps Script(GAS)で作った簡易Web APIとやり取りするサービス。
    // GameManager2D916 などにアタッチして使う想定。

    // デプロイID = "AKfycbx8sZMOQf0235xo14DFqb4wVdQ2O-H1NCxB7YIwj9W3LzqgbQPLpO4PP8piKj3Dqdu8"
    // デプロイURL = "https://script.google.com/a/macros/stu.hosei.ac.jp/s/AKfycbx8sZMOQf0235xo14DFqb4wVdQ2O-H1NCxB7YIwj9W3LzqgbQPLpO4PP8piKj3Dqdu8/exec"
    public class ScoreService : MonoBehaviour
    {
        [Header("GASでデプロイしたウェブアプリのURL")]
        [SerializeField] private string webAppUrl = "https://script.google.com/macros/s/xxxxxxxx/exec";

        // スコアを送信する
        public async Task<bool> SubmitScoreAsync(string playerName, int score)
        {
            var data = new ScoreData(playerName, score);
            string json = JsonUtility.ToJson(data);

            using UnityWebRequest request = new UnityWebRequest(webAppUrl, UnityWebRequest.kHttpVerbPOST);
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            await request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"スコア送信に失敗しました: {request.error}");
                return false;
            }

            return true;
        }

        // ランキングを取得する(上位10件を想定)
        public async Task<RankingEntry[]> FetchRankingAsync()
        {
            using UnityWebRequest request = UnityWebRequest.Get(webAppUrl);
            await request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"ランキング取得に失敗しました: {request.error}");
                return new RankingEntry[0];
            }

            RankingResponse response = JsonUtility.FromJson<RankingResponse>(request.downloadHandler.text);
            return response.ranking;
        }
    }
}
