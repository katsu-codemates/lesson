using UnityEngine;

// 既存の EnemyPatrol2D913.cs から、個別のpublicフィールドを
// EnemyData(ScriptableObject)への参照に置き換えた参考実装。
// 差分は "// 追加" コメントの部分。
//
// 使い方:
// 1. EnemyData.cs から「素早い敵」「硬い敵」など複数のアセットを作る
// 2. 敵オブジェクトのInspectorで enemyData に使いたいアセットをセットする
// 3. 同じスクリプト・同じプレハブのまま、アセットを差し替えるだけで挙動を変えられる
public class EnemyPatrol2D920new : MonoBehaviour
{
    [Header("パラメータ(ScriptableObject)")]
    public EnemyData enemyData;
    public GameManager2D916 gameManeger;

    private Vector2 startPosition;
    private int moveDirectiion = 1;
    private SpriteRenderer enemySprite;

    void Start()
    {
        startPosition = transform.position;
        enemySprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * moveDirectiion * enemyData.moveSpeed * Time.deltaTime);

        if (transform.position.x > startPosition.x + enemyData.moveDistance)
        {
            moveDirectiion = -1;
            enemySprite.flipX = true;
        }
        else if (transform.position.x < startPosition.x - enemyData.moveDistance)
        {
            moveDirectiion = 1;
            enemySprite.flipX = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (IsStompedByPlayer(collision.gameObject))
            {
                Destroy(gameObject);
                Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
                playerRigidbody.linearVelocity = new Vector2(playerRigidbody.linearVelocity.x, enemyData.playerBouncePower);
            }
            else
            {
                gameManeger.GameOver();
            }
        }
    }

    bool IsStompedByPlayer(GameObject player)
    {
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
        bool playerIsAboveEnemy = player.transform.position.y > transform.position.y + enemyData.stompHeight;
        bool playerIsFalling = playerRigidbody.linearVelocity.y <= 0f;
        return playerIsAboveEnemy && playerIsFalling;
    }
}
