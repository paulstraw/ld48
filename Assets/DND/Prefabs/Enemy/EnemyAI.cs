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

  bool isFacingRight;

  bool hasFlippedSinceLastDetectedFloor;

  void Awake()
  {

  }

  void FixedUpdate()
  {
    Collider2D[] frontFloorColliders = Physics2D.OverlapCircleAll(frontFloorCheck.position, 0.1f, pathMask);
    Collider2D[] bottomFloorColliders = Physics2D.OverlapCircleAll(bottomFloorCheck.position, 0.1f, pathMask);
    Collider2D[] wallColliders = Physics2D.OverlapCircleAll(wallCheck.position, 0.1f, pathMask);

    bool detectedFrontFloor = frontFloorColliders.Length != 0;
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
