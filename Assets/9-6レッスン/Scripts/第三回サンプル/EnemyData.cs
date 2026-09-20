using UnityEngine;

// 敵の種類ごとのパラメータをまとめて持たせるScriptableObject。
// Projectウィンドウで右クリック → Create → Lesson3 → EnemyData から作成する。
[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Lesson6/EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("移動")]
    public float moveSpeed = 2f;
    public float moveDistance = 3f;

    [Header("踏みつけ")]
    public float stompHeight = 0.3f;
    public float playerBouncePower = 8f;
}
