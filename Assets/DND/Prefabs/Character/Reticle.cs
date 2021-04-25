using UnityEngine;

public class Reticle : MonoBehaviour
{
  [SerializeField]
  float distanceMultiplier = 1;

  CharacterMovement movement;

  CharacterLifecycle lifecycle;

  PlayerController playerController;

  void Awake()
  {
    playerController = FindObjectOfType<PlayerController>();
    movement = GetComponentInParent<CharacterMovement>();
    lifecycle = GetComponentInParent<CharacterLifecycle>();
  }

  void Update()
  {
    bool moving = lifecycle.CharacterType == CharacterType.Dig ? playerController.diggerMoving : playerController.fighterMoving;


    Vector2 move;
    if (moving)
    {
      move = lifecycle.CharacterType == CharacterType.Dig
        ? playerController.controls.Digger.Move.ReadValue<Vector2>()
        : playerController.controls.Fighter.Move.ReadValue<Vector2>();

      if (!movement.isFacingRight)
      {
        move.x = -move.x;
      }
    }
    else
    {
      move = new Vector2(1, 0);
    }

    transform.localPosition = Vector3.MoveTowards(transform.localPosition, move * distanceMultiplier, 0.1f);
  }
}
