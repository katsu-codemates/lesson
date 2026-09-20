using Cysharp.Threading.Tasks;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameManager2D920 gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("goal");
        if(other.CompareTag("Player"))
        {
            gameManager.Win().Forget();
        }
    }
}
