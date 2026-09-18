using UnityEngine;

// ゴールポールなどに付けて使うトリガー。
// Collider2Dの「Is Trigger」にチェックを入れておくこと。
public class GoalTrigger2D : MonoBehaviour
{
    public GameManager2D916 gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.Win();
        }
    }
}
