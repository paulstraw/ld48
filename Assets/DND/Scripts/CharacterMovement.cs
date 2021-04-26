using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
  [SerializeField]
  float jumpForce = 150f;

  [SerializeField]
  float jumpTimeLimit;

  [Range(0, 0.3f)]
  [SerializeField]
  float movementSmoothing = 0.05f;

  [SerializeField]
  LayerMask groundLayers;

  [SerializeField]
  float moveSpeed;

  [SerializeField]
  private Transform groundCheck;

  [SerializeField]
  float descendTerminalVelocity = 20;

  [SerializeField]
  float ascendTerminalVelocity = Mathf.Infinity;

  const float groundCheckRadius = 0.2f;
  public bool isFacingRight
  {
    get;
    private set;
  } = true;

  public bool IsGrounded { get; private set; } = false;
  Rigidbody2D rb;
  Vector3 velocity = Vector3.zero;
  float jumpTimeCounter;
  bool lastWantsJump = true;
  bool jumpExhausted = true;

  void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate()
  {
    IsGrounded = false;

    Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayers);
    for (int i = 0; i < colliders.Length; i++)
    {
      if (colliders[i].gameObject != gameObject)
      {
        IsGrounded = true;
      }
    }
  }

  public void Move(float move, bool wantsJump)
  {
    move *= moveSpeed;

    Vector3 targetVelocity = new Vector2(move, Mathf.Clamp(rb.velocity.y, -descendTerminalVelocity, ascendTerminalVelocity));
    rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);

    if (move > 0 && !isFacingRight || move < 0 && isFacingRight)
    {
      Flip();
    }

    if (wantsJump)
    {
      Vector3 newVelocity = rb.velocity;
      if (IsGrounded && !lastWantsJump)
      {
        jumpExhausted = false;
        IsGrounded = false;
        jumpTimeCounter = jumpTimeLimit;
        newVelocity.y = jumpForce * Time.deltaTime;
      }
      else if (!IsGrounded)
      {
        if (jumpTimeCounter > 0 && !jumpExhausted)
        {
          newVelocity.y = jumpForce * Time.deltaTime;
          jumpTimeCounter -= Time.deltaTime;
        }
        else
        {
          jumpExhausted = true;
        }
      }

      rb.velocity = newVelocity;
    }
    else if (!IsGrounded)
    {
      jumpExhausted = true;
    }

    lastWantsJump = wantsJump;
  }

  void Flip()
  {
    isFacingRight = !isFacingRight;

    Vector3 newScale = transform.localScale;
    newScale.x *= -1;
    transform.localScale = newScale;
  }
}
