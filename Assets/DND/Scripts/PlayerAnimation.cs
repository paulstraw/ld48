using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
  [SerializeField]
  Material defaultMaterial;

  [SerializeField]
  Material damagedMaterial;

  Animator playerAnimator;

  PlayerController playerController;

  Character character;

  Rigidbody2D rb;

  CharacterMovement movement;

  SpriteRenderer spriteRenderer;

  void Awake()
  {
    playerController = FindObjectOfType<PlayerController>();
    rb = GetComponentInParent<Rigidbody2D>();
    playerAnimator = GetComponent<Animator>();
    movement = GetComponentInParent<CharacterMovement>();
    spriteRenderer = GetComponentInParent<SpriteRenderer>();

    character = GetComponentInParent<Character>();
    character.OnDamaged += HandleCharacterDamaged;
  }

  void OnDestroy()
  {
    character.OnDamaged -= HandleCharacterDamaged;
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

  void HandleCharacterDamaged(float damagedInvulnerabilityDuration)
  {
    SetDamagedMaterial();

    CancelInvoke("SetDefaultMaterial");
    Invoke("SetDefaultMaterial", damagedInvulnerabilityDuration);
  }

  void SetDamagedMaterial()
  {
    spriteRenderer.material = damagedMaterial;
  }

  void SetDefaultMaterial()
  {
    spriteRenderer.material = defaultMaterial;
  }
}
