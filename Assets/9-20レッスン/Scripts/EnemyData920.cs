using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData920 : ScriptableObject
{
    [Header("Move Settings")]
    public float moveSpeed = 2f;
    public float moveDistance = 3f;

    [Header("Stomp Settings")]
    public float stompHeight = 0.3f;
    public float playerBouncePower = 8f;
}
