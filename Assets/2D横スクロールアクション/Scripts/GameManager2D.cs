using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2D : MonoBehaviour
{
    public enum GameState
    {
        Playing,
        GameOver,
        Clear
    }

    [Header("UI")]
    public GameObject gameOverText;
    public GameObject clearText;
    public GameObject retryButton;

    [Header("Sound")]
    public AudioClip gameOverSound;

    public GameState currentState = GameState.Playing;
    private AudioSource gameAudioSource;
    void Start()
    {
        //ゲームマネージャーのAudioSourceを取得
        gameAudioSource = GetComponent<AudioSource>();
    }

    public void GameOver()
    {
        currentState = GameState.GameOver;
        gameOverText.SetActive(true);
        retryButton.SetActive(true);
        PlaySound(gameOverSound);
    }

    public void Clear()
    {
        currentState = GameState.Clear;
        clearText.SetActive(true);
        retryButton.SetActive(true);
    }

    public void Retry()
    {
        //今のシーンを取得して読み込み
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlaySound(AudioClip sound)
    {
        gameAudioSource.PlayOneShot(sound);
    }
}