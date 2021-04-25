using System.Globalization;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  public GameplayControls controls
  {
    get;
    private set;
  }

  [SerializeField]
  CharacterMovement diggerMovement;

  [SerializeField]
  CharacterMovement fighterMovement;

  public bool diggerMoving;
  public bool fighterMoving;

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
  { <<
    <<<<< HEAD
    diggerMoving = true; ==
    == == =
    diggerMove = ctx.ReadValue<Vector2>().x;
    digAnimator.SetBool("IsRunning", true); >>
    >>>>> 7 ca2f0f(Add run animations to Dig)
  }

  void OnDiggerMoveCancel(InputAction.CallbackContext ctx)
  { <<
    <<<<< HEAD
    diggerMoving = false; ==
    == == =
    diggerMove = 0;
    digAnimator.SetBool("IsRunning", false); >>
    >>>>> 7 ca2f0f(Add run animations to Dig)
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
    fighterMoving = true;
  }

  void OnFighterMoveCancel(InputAction.CallbackContext ctx)
  {
    fighterMoving = false;
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
      float diggerMove = controls.Digger.Move.ReadValue<Vector2>().x;
      diggerMovement.Move(diggerMove * Time.fixedDeltaTime, diggerJump);
    }

    if (controls.Fighter.enabled)
    {
      float fighterMove = controls.Fighter.Move.ReadValue<Vector2>().x;
      fighterMovement.Move(fighterMove * Time.fixedDeltaTime, fighterJump);
    }
  }
}
