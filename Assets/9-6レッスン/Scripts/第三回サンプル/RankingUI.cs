using System.Text;
using TMPro;
using UnityEngine;
using Lesson3.Networking;

// 取得したランキングをTextMeshProのテキストに表示するだけのシンプルなUI
public class RankingUI : MonoBehaviour
{
    [SerializeField] private TMP_Text rankingText;

    public void ShowRanking(RankingEntry[] ranking)
    {
        var sb = new StringBuilder();
        sb.AppendLine("=== ランキング ===");

        for (int i = 0; i < ranking.Length; i++)
        {
            sb.AppendLine($"{i + 1}位  {ranking[i].playerName}  {ranking[i].score}pt");
        }

        rankingText.text = sb.ToString();
    }
}
