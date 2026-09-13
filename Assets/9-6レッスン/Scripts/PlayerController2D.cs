using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2D906 : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpPower = 8f;

    [Header("Ground Check Settings")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Animation Settings")]
    public float walkAnimationSpeed = 1f;

    private Rigidbody2D playerRigidbody;
    private float horizontalInput;
    private bool isGrounded;
    private SpriteRenderer playerSprite;
    private Animator playerAnimator;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalInput = 0f;
        playerAnimator.speed = 0f;

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1f;
            playerSprite.flipX = true;
            playerAnimator.speed = walkAnimationSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1f;
            playerSprite.flipX = false;
            playerAnimator.speed = walkAnimationSpeed;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidbody.linearVelocity = new Vector2(playerRigidbody.linearVelocity.x, jumpPower);
        }

        if (!isGrounded)
        {
            playerAnimator.speed = 0f;
        }

    }

    void FixedUpdate()
    {
        playerRigidbody.linearVelocity = new Vector2(horizontalInput * moveSpeed, playerRigidbody.linearVelocity.y);
    }
}
