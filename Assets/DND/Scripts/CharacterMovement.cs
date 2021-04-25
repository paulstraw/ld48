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

  const float groundCheckRadius = 0.2f;

  bool isGrounded = false;
  Rigidbody2D rb;
  bool facingRight = true;
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
    isGrounded = false;

    Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayers);
    for (int i = 0; i < colliders.Length; i++)
    {
      if (colliders[i].gameObject != gameObject)
      {
        isGrounded = true;
      }
    }
  }

  public void Move(float move, bool wantsJump)
  {
    move *= moveSpeed;

    Vector3 targetVelocity = new Vector2(move, rb.velocity.y);
    rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);

    if (move > 0 && !facingRight || move < 0 && facingRight)
    {
      Flip();
    }

    if (wantsJump)
    {
      Vector3 newVelocity = rb.velocity;
      if (isGrounded && !lastWantsJump)
      {
        jumpExhausted = false;
        isGrounded = false;
        jumpTimeCounter = jumpTimeLimit;
        newVelocity.y = jumpForce * Time.deltaTime;
      }
      else if (!isGrounded)
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
    else if (!isGrounded)
    {
      jumpExhausted = true;
    }

    lastWantsJump = wantsJump;
  }

  void Flip()
  {
    facingRight = !facingRight;

    Vector3 newScale = transform.localScale;
    newScale.x *= -1;
    transform.localScale = newScale;
  }
}
