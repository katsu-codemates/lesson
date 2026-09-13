using UnityEngine;

public class Lesson : MonoBehaviour
{
    public GameObject gameClaerText;
    public GameObject gameOverText;
    public GameObject ball;
    public BottomWall bottomWall;
    int ballCount; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ballCount = GameObject.FindGameObjectsWithTag("Block").Length;
        if (ballCount <= 0)
        {
            GameClear();
        }
        else if (bottomWall.GetIsGameOver())
        {
            GameOver();
        }
    }

    public void GameClear()
    {
        gameClaerText.SetActive(true);
        ball.SetActive(false);
    }
    void GameOver()
    {
        gameOverText.SetActive(true);
        ball.SetActive(false);
    }
}
