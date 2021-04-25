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

    EnableDigControls();
    EnableDuelControls();

    controls.Digger.Move.started += OnDiggerMoveStart;
    controls.Digger.Move.canceled += OnDiggerMoveCancel;
    controls.Digger.Jump.started += OnDiggerJumpStart;
    controls.Digger.Jump.canceled += OnDiggerJumpCancel;

    controls.Fighter.Move.started += OnFighterMoveStart;
    controls.Fighter.Move.canceled += OnFighterMoveCancel;
    controls.Fighter.Jump.started += OnFighterJumpStart;
    controls.Fighter.Jump.canceled += OnFighterJumpCancel;

    CharacterLifecycle.OnCharacterSpawned += OnCharacterSpawned;
    CharacterLifecycle.OnCharacterKilled += OnCharacterKilled;
  }

  void Update()
  {

  }

  void OnDestroy()
  {
    CharacterLifecycle.OnCharacterSpawned -= OnCharacterSpawned;
    CharacterLifecycle.OnCharacterKilled -= OnCharacterKilled;
  }

  void EnableDigControls()
  {
    controls.Digger.Enable();
  }

  void EnableDuelControls()
  {
    controls.Fighter.Enable();
  }

  void DisableDigControls()
  {
    controls.Digger.Disable();
  }

  void DisableDuelControls()
  {
    controls.Fighter.Disable();
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

  void OnCharacterSpawned(CharacterLifecycle characterLifecycle)
  {
    if (characterLifecycle.CharacterType == CharacterType.Dig)
    {
      EnableDigControls();
      diggerMovement = characterLifecycle.GetComponent<CharacterMovement>();
    }
    else if (characterLifecycle.CharacterType == CharacterType.Duel)
    {
      EnableDuelControls();
      fighterMovement = characterLifecycle.GetComponent<CharacterMovement>();
    }
  }

  void OnCharacterKilled(CharacterLifecycle characterLifecycle)
  {
    if (characterLifecycle.CharacterType == CharacterType.Dig)
    {
      DisableDigControls();
    }
    else if (characterLifecycle.CharacterType == CharacterType.Duel)
    {
      DisableDuelControls();
    }
  }

  void FixedUpdate()
  {
    if (controls.Digger.enabled)
    {
      diggerMovement.Move(diggerMove * Time.fixedDeltaTime, diggerJump);
    }

    if (controls.Fighter.enabled)
    {
      fighterMovement.Move(fighterMove * Time.fixedDeltaTime, fighterJump);
    }
  }
}
