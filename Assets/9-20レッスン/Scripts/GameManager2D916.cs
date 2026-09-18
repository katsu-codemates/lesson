using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager2D920 : MonoBehaviour
{
    public enum GameState
    {
        Playing,
        GameOver
    }

    [Header("UI")]
    public GameObject gameOverText;
    public GameObject retryButton;

    [Header("Sound")]
    public AudioClip gameOverSound;

    public GameState currentState = GameState.Playing;

    private AudioSource gameAudioSource;
    void Start()
    {
        gameAudioSource = GetComponent<AudioSource>();
    }

    public void GameOver()
    {
        currentState = GameState.GameOver;
        gameOverText.SetActive(true);
        retryButton.SetActive(true);
        PlaySound(gameOverSound);
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
