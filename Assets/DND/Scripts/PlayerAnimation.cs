using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
  Animator playerAnimator;

  PlayerController playerController;

  CharacterLifecycle lifecycle;

  Rigidbody2D rb;

  void Awake()
  {
    playerController = FindObjectOfType<PlayerController>();
    lifecycle = GetComponentInParent<CharacterLifecycle>();
    rb = GetComponentInParent<Rigidbody2D>();
    playerAnimator = GetComponent<Animator>();
  }

  void Update()
  {
    UpdateMoveAnimation();
    UpdateJumpAnimation();
  }

  void UpdateMoveAnimation()
  {
    bool isMoving = false;

    if (lifecycle.CharacterType == CharacterType.Dig)
    {
      isMoving = playerController.Controls.Digger.Move.ReadValue<Vector2>().x != 0;
    }
    else
    {
      isMoving = playerController.Controls.Fighter.Move.ReadValue<Vector2>().x != 0;
    }

    playerAnimator.SetBool("IsMoving", isMoving);
  }

  void UpdateJumpAnimation()
  {
    float minJumpVelocity = 5f;
    float maxFallVelocity = 0f;

    playerAnimator.SetBool("IsJumping", rb.velocity.y > minJumpVelocity);
    playerAnimator.SetBool("IsFalling", rb.velocity.y < maxFallVelocity);
  }
}
