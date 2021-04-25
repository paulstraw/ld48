using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  public GameplayControls Controls
  {
    get;
    private set;
  }

  [SerializeField]
  CharacterMovement diggerMovement;

  [SerializeField]
  CharacterMovement fighterMovement;

  public bool DiggerMoving;
  public bool FighterMoving;

  bool diggerJump;
  bool fighterJump;

  void Awake()
  {
    Controls = new GameplayControls();

    EnableDigControls();
    EnableDuelControls();

    Controls.Digger.Move.started += OnDiggerMoveStart;
    Controls.Digger.Move.canceled += OnDiggerMoveCancel;
    Controls.Digger.Jump.started += OnDiggerJumpStart;
    Controls.Digger.Jump.canceled += OnDiggerJumpCancel;

    Controls.Fighter.Move.started += OnFighterMoveStart;
    Controls.Fighter.Move.canceled += OnFighterMoveCancel;
    Controls.Fighter.Jump.started += OnFighterJumpStart;
    Controls.Fighter.Jump.canceled += OnFighterJumpCancel;

    Character.OnCharacterSpawned += OnCharacterSpawned;
    Character.OnCharacterKilled += OnCharacterKilled;
  }

  void Update()
  {

  }

  void OnDestroy()
  {
    Character.OnCharacterSpawned -= OnCharacterSpawned;
    Character.OnCharacterKilled -= OnCharacterKilled;
  }

  void EnableDigControls()
  {
    Controls.Digger.Enable();
  }

  void EnableDuelControls()
  {
    Controls.Fighter.Enable();
  }

  void DisableDigControls()
  {
    Controls.Digger.Disable();
  }

  void DisableDuelControls()
  {
    Controls.Fighter.Disable();
  }

  void OnDiggerMoveStart(InputAction.CallbackContext ctx)
  {
    DiggerMoving = true;
  }

  void OnDiggerMoveCancel(InputAction.CallbackContext ctx)
  {
    DiggerMoving = false;
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
    FighterMoving = true;
  }

  void OnFighterMoveCancel(InputAction.CallbackContext ctx)
  {
    FighterMoving = false;
  }

  void OnFighterJumpStart(InputAction.CallbackContext _ctx)
  {
    fighterJump = true;
  }

  void OnFighterJumpCancel(InputAction.CallbackContext _ctx)
  {
    fighterJump = false;
  }

  void OnCharacterSpawned(Character character)
  {
    if (character.CharacterType == CharacterType.Dig)
    {
      EnableDigControls();
      diggerMovement = character.GetComponent<CharacterMovement>();
    }
    else if (character.CharacterType == CharacterType.Duel)
    {
      EnableDuelControls();
      fighterMovement = character.GetComponent<CharacterMovement>();
    }
  }

  void OnCharacterKilled(Character character)
  {
    if (character.CharacterType == CharacterType.Dig)
    {
      DisableDigControls();
    }
    else if (character.CharacterType == CharacterType.Duel)
    {
      DisableDuelControls();
    }
  }

  void FixedUpdate()
  {
    if (Controls.Digger.enabled)
    {
      float diggerMove = Controls.Digger.Move.ReadValue<Vector2>().x;
      diggerMovement.Move(diggerMove * Time.fixedDeltaTime, diggerJump);
    }

    if (Controls.Fighter.enabled)
    {
      float fighterMove = Controls.Fighter.Move.ReadValue<Vector2>().x;
      fighterMovement.Move(fighterMove * Time.fixedDeltaTime, fighterJump);
    }
  }
}
