using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
  Animator playerAnimator;

  PlayerController playerController;

  Character character;

  Rigidbody2D rb;

  CharacterMovement movement;

  void Awake()
  {
    playerController = FindObjectOfType<PlayerController>();
    character = GetComponentInParent<Character>();
    rb = GetComponentInParent<Rigidbody2D>();
    playerAnimator = GetComponent<Animator>();
    movement = GetComponentInParent<CharacterMovement>();
  }

  void Update()
  {
    UpdateMoveAnimation();
    UpdateJumpAnimation();
  }

  void UpdateMoveAnimation()
  {
    bool isMoving = false;

    if (character.CharacterType == CharacterType.Dig)
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
    playerAnimator.SetBool("IsJumping", rb.velocity.y > 0 && !movement.IsGrounded);
    playerAnimator.SetBool("IsFalling", rb.velocity.y <= 0 && !movement.IsGrounded);
  }
}
