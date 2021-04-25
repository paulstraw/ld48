using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  GameplayControls controls;

  [SerializeField]
  CharacterMovement diggerMovement;

  [SerializeField]
  CharacterMovement fighterMovement;

  float diggerMove;
  float fighterMove;

  bool diggerJump;
  bool fighterJump;

  void Awake()
  {
    controls = new GameplayControls();

    controls.Digger.Enable();
    controls.Fighter.Enable();

    controls.Digger.Move.started += OnDiggerMoveStart;
    controls.Digger.Move.canceled += OnDiggerMoveCancel;
    controls.Digger.Jump.started += OnDiggerJumpStart;
    controls.Digger.Jump.canceled += OnDiggerJumpCancel;

    controls.Fighter.Move.started += OnFighterMoveStart;
    controls.Fighter.Move.canceled += OnFighterMoveCancel;
    controls.Fighter.Jump.started += OnFighterJumpStart;
    controls.Fighter.Jump.canceled += OnFighterJumpCancel;
  }

  void Update()
  {

  }

  void OnDiggerMoveStart(InputAction.CallbackContext ctx)
  {
    diggerMove = ctx.ReadValue<Vector2>().x;
  }

  void OnDiggerMoveCancel(InputAction.CallbackContext ctx)
  {
    diggerMove = 0;
  }

  void OnDiggerJumpStart(InputAction.CallbackContext _ctx)
  {
    diggerJump = true;
  }

  void OnDiggerJumpCancel(InputAction.CallbackContext _ctx)
  {
    diggerJump = false;
  }

  void OnFighterMoveStart(InputAction.CallbackContext ctx)
  {
    fighterMove = ctx.ReadValue<Vector2>().x;
  }

  void OnFighterMoveCancel(InputAction.CallbackContext ctx)
  {
    fighterMove = 0;
  }

  void OnFighterJumpStart(InputAction.CallbackContext _ctx)
  {
    fighterJump = true;
  }

  void OnFighterJumpCancel(InputAction.CallbackContext _ctx)
  {
    fighterJump = false;
  }

  void FixedUpdate()
  {
    diggerMovement.Move(diggerMove * Time.fixedDeltaTime, diggerJump);
    fighterMovement.Move(fighterMove * Time.fixedDeltaTime, fighterJump);
  }
}
