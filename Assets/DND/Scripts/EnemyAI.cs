using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
  [SerializeField]
  Transform floorCheck;

  [SerializeField]
  Transform wallCheck;

  [SerializeField]
  LayerMask pathMask;

  [SerializeField]
  float moveSpeed;

  [SerializeField]
  Rigidbody2D rb;

  bool isFacingRight;

  bool hasFlippedSinceLastDetectedFloor;

  void Awake()
  {

  }

  void FixedUpdate()
  {
    Collider2D[] floorColliders = Physics2D.OverlapCircleAll(floorCheck.position, 0.1f, pathMask);
    Collider2D[] wallColliders = Physics2D.OverlapCircleAll(wallCheck.position, 0.1f, pathMask);

    bool detectedFloor = floorColliders.Length != 0;
    bool canContinueForward = detectedFloor && wallColliders.Length == 0;

    if (detectedFloor)
    {
      hasFlippedSinceLastDetectedFloor = false;
    }

    if (canContinueForward)
    {
      MoveForward();
    }
    else if (!hasFlippedSinceLastDetectedFloor)
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
    Vector2 newVelocity = rb.velocity;
    newVelocity.x = isFacingRight ? -moveSpeed : moveSpeed;
    rb.velocity = newVelocity;
  }
}
