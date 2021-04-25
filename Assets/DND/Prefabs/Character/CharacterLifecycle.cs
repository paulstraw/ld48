using UnityEngine;

public class CharacterLifecycle : MonoBehaviour, IKillable
{
  public static event System.Action<CharacterLifecycle> OnCharacterSpawned = delegate { };
  public static event System.Action<CharacterLifecycle> OnCharacterKilled = delegate { };


  public CharacterType CharacterType;

  RespawnManager respawnManager;


  public bool IsDead
  {
    get;
    private set;
  }

  void Awake()
  {
    respawnManager = FindObjectOfType<RespawnManager>();
    OnCharacterSpawned(this);
  }

  public void Kill()
  {
    if (IsDead) return;
    IsDead = true;

    OnCharacterKilled(this);

    Destroy(gameObject);
  }
}
