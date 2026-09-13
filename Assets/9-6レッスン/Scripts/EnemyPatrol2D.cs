using UnityEngine;

public class EnemyPatrol2D913 : MonoBehaviour
{
    [Header("Move Settings")]
    public float moveSpeed = 2f;
    public float moveDistance = 3f;

    [Header("Stomp Settings")]
    public float stompHeight = 0.3f;
    public float playBouncePower = 8f;

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
        transform.Translate(Vector2.right * moveDirectiion * moveSpeed * Time.deltaTime);

        if (transform.position.x > startPosition.x + moveDistance)
        {
            moveDirectiion = -1;
            enemySprite.flipX = true;
        }
        else if (transform.position.x < startPosition.x - moveDirectiion)
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
                playerRigidbody.linearVelocity = new Vector2(playerRigidbody.linearVelocity.x, playBouncePower);
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

        bool playerIsAboveEnemy = player.transform.position.y > transform.position.y + stompHeight;
        bool playerIsFalling = playerRigidbody.linearVelocity.y <= 0f;

        return playerIsAboveEnemy && playerIsFalling;
    }
}
