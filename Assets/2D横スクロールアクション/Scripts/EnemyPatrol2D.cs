using UnityEngine;

public class EnemyPatrol2D : MonoBehaviour
{
    [Header("Move Settings")]
    public float moveSpeed = 2f;
    public float moveDistance = 3f;

    [Header("Stomp Settings")]
    public float stompHeight = 0.3f;
    public float playerBouncePower = 8f;

    private Vector2 startPosition;
    private int moveDirection = 1;
    private SpriteRenderer enemySprite;
    private GameManager2D GameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //最初の位置を保存
        startPosition = transform.position;
        //スライムのSpriteRendererを取得
        enemySprite = GetComponent<SpriteRenderer>();
        //GameManager2Dをシーン内から探して取得
        GameManager = FindAnyObjectByType<GameManager2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //敵を動かす
        transform.Translate(Vector2.right * moveDirection * moveSpeed * Time.deltaTime);

        //反復移動させる
        if (transform.position.x > startPosition.x + moveDistance)
        {
            moveDirection = -1;
            enemySprite.flipX = true;
        }
        else if (transform.position.x < startPosition.x - moveDistance)
        {
            moveDirection = 1;
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
                playerRigidbody.linearVelocity = new Vector2(playerRigidbody.linearVelocity.x, playerBouncePower);
            }
            else
            {
                GameManager.GameOver();
            }
        }
    }

    bool IsStompedByPlayer(GameObject player)
    {
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();

        bool playerIsAboveEnemy = player.transform.position.y > transform.position.y + stompHeight;
        bool playerIsFalling = playerRigidbody.linearVelocity.y <= 0f;

        return playerIsAboveEnemy && playerIsFalling;
    }
}