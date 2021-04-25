using UnityEngine;

public class CharacterLifecycle : MonoBehaviour, IKillable
{
  public static event System.Action<CharacterLifecycle> OnCharacterSpawned = delegate { };
  public static event System.Action<CharacterLifecycle> OnCharacterKilled = delegate { };

  [SerializeField]
  GameObject prefab;

  public CharacterType CharacterType;

  SpawnPointManager spawnPointManager;


  public bool IsDead
  {
    get;
    private set;
  }

  void Awake()
  {
    spawnPointManager = FindObjectOfType<SpawnPointManager>();
    OnCharacterSpawned(this);
  }

  public void Kill()
  {
    if (IsDead)
    {
      return;
    }
    IsDead = true;

    OnCharacterKilled(this);

    Transform spawnPoint = spawnPointManager.GetSpawnPoint(CharacterType);

    Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);

    Destroy(this.gameObject);
  }
}
