using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [Header("Move Settings")]
    public float moveSpeed = 5f;
    public float jumpPower = 8f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Animation")]
    public float walkAnimationSpeed = 1f;

    [Header("Death")]
    public float fallY = -10f;

    private Rigidbody2D playerRigidbody;
    private float horizontalInput;
    private bool isGrounded;
    private SpriteRenderer playerSprite;
    private Animator playerAnimator;
    private GameManager2D GameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //プレイヤーのRigidbody2Dを取得
        playerRigidbody = GetComponent<Rigidbody2D>();
        //プレイヤーのSpriteRendererを取得
        playerSprite = GetComponent<SpriteRenderer>();
        //プレイヤーのAnimatorを取得
        playerAnimator = GetComponent<Animator>();
        //GameManager2Dをシーン内から探して取得
        GameManager = FindAnyObjectByType<GameManager2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームの状態を確認
        if (GameManager.currentState != GameManager2D.GameState.Playing)
        {
            //状態がPlayingでなければ処理終了
            horizontalInput = 0f;
            playerAnimator.speed = 0f;
            return;
        }

        //プレイヤーの落下判定
        if(transform.position.y < fallY)
        {
            GameManager.GameOver();
        }

        // 入力、-1：左、0：なし、1：右、のように扱います
        horizontalInput = 0f;

        playerAnimator.speed = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1f;
            playerSprite.flipX = true;
            //アニメーションを再生
            playerAnimator.speed = walkAnimationSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1f;
            playerSprite.flipX = false;
            //アニメーションを再生
            playerAnimator.speed = walkAnimationSpeed;
        }

        //GroundCheckに小さな円を作成、Groundレイヤーに接触しているか確認
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidbody.linearVelocity = new Vector2(playerRigidbody.linearVelocity.x, jumpPower);
        }

        //地面にいないならアニメーションを止める
        if (!isGrounded)
        {
            playerAnimator.speed = 0f;
        }
    }

    void FixedUpdate()
    {
        // Rigidbody2Dの速度を変更して、左右に移動します。
        playerRigidbody.linearVelocity = new Vector2(horizontalInput * moveSpeed, playerRigidbody.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Death"))
        {
            GameManager.GameOver();
        }
    }
}