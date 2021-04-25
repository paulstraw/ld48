using UnityEngine;

public class Character : MonoBehaviour, IKillable
{
  public static event System.Action<Character> OnCharacterSpawned = delegate { };
  public static event System.Action<Character> OnCharacterKilled = delegate { };


  public CharacterType CharacterType;

  public bool IsDead
  {
    get;
    private set;
  }

  void Awake()
  {
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
