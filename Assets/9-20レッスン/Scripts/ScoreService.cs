using System;
using System.Text;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class ScoreService : MonoBehaviour
{
    [SerializeField] private string webUrl = "https://~~";

    public async UniTask<bool> SubmitScoreAsync(string playerName, int score)
    {
        var data = new ScoreData(playerName, score);
        string json = JsonUtility.ToJson(data);

        using UnityWebRequest request = new UnityWebRequest(webUrl, UnityWebRequest.kHttpVerbPOST);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        await request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"スコア送信に失敗: {request.error}");
            return false;
        }

        return true;
    }

    public async UniTask<RankingEntry[]> FetchRankingAsync()
    {
        using UnityWebRequest request = UnityWebRequest.Get(webUrl);
        await request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"ランキング取得に失敗: {request.error}");
            return new RankingEntry[0];
        }

        Debug.Log(request.downloadHandler.text);
        RankingResponse response = JsonUtility.FromJson<RankingResponse>(request.downloadHandler.text);
        return response.ranking;
    }
}
