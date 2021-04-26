using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
  [SerializeField]
  Transform frontFloorCheck;

  [SerializeField]
  Transform bottomFloorCheck;

  [SerializeField]
  Transform wallCheck;

  [SerializeField]
  LayerMask pathMask;

  [SerializeField]
  float moveSpeed;

  [SerializeField]
  float maxVelocity;

  [SerializeField]
  Rigidbody2D rb;

  [SerializeField]
  bool avoidsFloorGaps = true;

  bool isFacingRight;

  bool hasFlippedSinceLastDetectedFloor;

  bool movementPaused = false;

  public void PauseMovement()
  {
    movementPaused = true;
  }

  public void UnpauseMovement()
  {
    movementPaused = false;
  }

  void FixedUpdate()
  {
    if (movementPaused) return;

    Collider2D[] frontFloorColliders = avoidsFloorGaps ? Physics2D.OverlapCircleAll(frontFloorCheck.position, 0.1f, pathMask) : new Collider2D[0];
    Collider2D[] bottomFloorColliders = Physics2D.OverlapCircleAll(bottomFloorCheck.position, 0.1f, pathMask);
    Collider2D[] wallColliders = Physics2D.OverlapCircleAll(wallCheck.position, 0.1f, pathMask);

    bool detectedFrontFloor = avoidsFloorGaps ? frontFloorColliders.Length != 0 : true;
    bool detectedBottomFloor = bottomFloorColliders.Length != 0;
    bool detectedWall = wallColliders.Length != 0;
    bool canContinueForward = detectedFrontFloor && !detectedWall;

    if (detectedFrontFloor)
    {
      hasFlippedSinceLastDetectedFloor = false;
    }

    if (canContinueForward)
    {
      MoveForward();
    }
    else if (!hasFlippedSinceLastDetectedFloor && detectedBottomFloor)
    {
      TurnAround();
      hasFlippedSinceLastDetectedFloor = true;
    }
  }

  void TurnAround()
  {
    isFacingRight = !isFacingRight;

    Vector3 newScale = transform.localScale;
    newScale.x *= -1;
    transform.localScale = newScale;
  }

  void MoveForward()
  {
    if (rb.velocity.magnitude >= maxVelocity) return;

    float speed = isFacingRight ? -moveSpeed : moveSpeed;

    rb.AddForce(Vector2.right * speed * Time.deltaTime);
  }
}
