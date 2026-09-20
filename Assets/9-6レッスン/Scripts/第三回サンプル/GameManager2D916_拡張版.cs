// using UnityEngine;
// using UnityEngine.SceneManagement;
// using Lesson3.Networking;

// // 既存の GameManager2D916.cs に「// 追加」のコメントが付いた部分を足したリファレンス実装。
// // このファイルをそのまま上書きするのではなく、差分を見ながら既存のスクリプトに手を加える想定。
// public class GameManager2D916new : MonoBehaviour
// {
//     public enum GameState
//     {
//         Playing,
//         GameOver,
//         Cleared // 追加: クリア状態
//     }

//     [Header("UI")]
//     public GameObject gameOverText;
//     public GameObject retryButton;
//     public GameObject clearText;      // 追加
//     public RankingUI rankingUI;       // 追加

//     [Header("Sound")]
//     public AudioClip gameOverSound;
//     public AudioClip clearSound;      // 追加

//     [Header("Score")]                 // 追加
//     public string playerName = "プレイヤー"; // 追加

//     public GameState currentState = GameState.Playing;

//     private AudioSource gameAudioSource;
//     private ScoreService scoreService; // 追加
//     private float startTime;           // 追加: 経過時間からスコアを計算する例

//     void Start()
//     {
//         gameAudioSource = GetComponent<AudioSource>();
//         scoreService = GetComponent<ScoreService>(); // 追加
//         startTime = Time.time;                       // 追加
//     }

//     public void GameOver()
//     {
//         currentState = GameState.GameOver;
//         gameOverText.SetActive(true);
//         retryButton.SetActive(true);
//         PlaySound(gameOverSound);
//     }

//     // 追加: ゴール到達時に呼ぶ
//     public async void Win()
//     {
//         if (currentState != GameState.Playing) return;

//         currentState = GameState.Cleared;
//         clearText.SetActive(true);
//         retryButton.SetActive(true);
//         PlaySound(clearSound);

//         // クリアタイムが早いほど高スコアになる簡単な例
//         int score = Mathf.Max(0, 1000 - Mathf.RoundToInt((Time.time - startTime) * 10f));

//         bool success = await scoreService.SubmitScoreAsync(playerName, score);
//         if (success)
//         {
//             RankingEntry[] ranking = await scoreService.FetchRankingAsync();
//             rankingUI.ShowRanking(ranking);
//         }
//     }

//     public void Retry()
//     {
//         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//     }

//     public void PlaySound(AudioClip sound)
//     {
//         gameAudioSource.PlayOneShot(sound);
//     }
// }
