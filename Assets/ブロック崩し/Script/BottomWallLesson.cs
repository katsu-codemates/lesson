using UnityEngine;

public class BottomWallLesson : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject ball;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            GameOver();
        }
    }
    void GameOver()
    {
        gameOverText.SetActive(true);
        ball.SetActive(false);
    }
}
