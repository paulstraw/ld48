using UnityEngine;

public class RespawnManager : MonoBehaviour
{
  [SerializeField]
  Transform defaultSpawnPoint;

  [SerializeField]
  GameObject digPrefab;

  [SerializeField]
  GameObject duelPrefab;

  [SerializeField]
  float respawnDelay = 3;

  Transform currentSpawnPoint;

  void Awake()
  {
    currentSpawnPoint = defaultSpawnPoint;

    Character.OnCharacterKilled += OnCharacterKilled;
    Checkpoint.OnCheckpointReached += OnCheckpointReached;
  }

  void OnDestroy()
  {
    Character.OnCharacterKilled -= OnCharacterKilled;
    Checkpoint.OnCheckpointReached -= OnCheckpointReached;
  }

  void OnCharacterKilled(Character character)
  {
    this.Invoke(() => RespawnCharacter(character.CharacterType), respawnDelay);
  }

  void OnCheckpointReached(Checkpoint checkpoint)
  {
    currentSpawnPoint = checkpoint.transform;
  }

  private void RespawnCharacter(CharacterType characterType)
  {
    GameObject prefab = characterType == CharacterType.Dig
      ? digPrefab
      : duelPrefab;

    Instantiate(prefab, currentSpawnPoint.position, currentSpawnPoint.rotation);
  }
}
