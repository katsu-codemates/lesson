using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using System.Text;

public class GameManager2D920 : MonoBehaviour
{
    public enum GameState
    {
        Playing,
        GameOver,
        GameClear
    }

    [Header("UI")]
    public GameObject gameOverText;
    public GameObject clearText;
    public GameObject retryButton;
    public GameObject rankingUI;
    public TextMeshProUGUI rankingText;

    [Header("Score")]
    public string playerName = "player";

    [Header("Sound")]
    public AudioClip gameOverSound;

    public GameState currentState = GameState.Playing;

    private AudioSource gameAudioSource;
    private ScoreService scoreService;
    private float startTime;
    void Start()
    {
        gameAudioSource = GetComponent<AudioSource>();
        scoreService = GetComponent<ScoreService>();
        startTime = Time.time;
    }

    public void GameOver()
    {
        currentState = GameState.GameOver;
        gameOverText.SetActive(true);
        retryButton.SetActive(true);
        PlaySound(gameOverSound);
    }

    public async UniTask Win()
    {
        if (currentState != GameState.Playing)
        {
            return;
        }

        currentState = GameState.GameClear;
        clearText.SetActive(true);
        retryButton.SetActive(true);

        int score = Mathf.Max(0, 1000 - Mathf.RoundToInt((Time.time - startTime) * 10f));

        bool success = await scoreService.SubmitScoreAsync(playerName, score);
        if (success)
        {
            RankingEntry[] rankings = await scoreService.FetchRankingAsync();

            var sb = new StringBuilder();
            for (int i = 0; i < rankings.Length; i++)
            {
                sb.AppendLine($"{i + 1}: {rankings[i].playerName} {rankings[i].score}pt");
            }
            rankingText.text = sb.ToString();
            rankingUI.SetActive(true);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlaySound(AudioClip sound)
    {
        gameAudioSource.PlayOneShot(sound);
    }
}
