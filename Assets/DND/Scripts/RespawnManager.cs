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

  [SerializeField]
  GameObject gameOverScreen;

  Transform currentSpawnPoint;

  bool isDigDead = false;
  bool isDuelDead = false;

  void Awake()
  {
    currentSpawnPoint = defaultSpawnPoint;

    Character.OnCharacterKilled += OnCharacterKilled;
    Character.OnCharacterSpawned += OnCharacterSpawned;
    Checkpoint.OnCheckpointReached += OnCheckpointReached;
  }

  void OnDestroy()
  {
    Character.OnCharacterKilled -= OnCharacterKilled;
    Character.OnCharacterSpawned -= OnCharacterSpawned;
    Checkpoint.OnCheckpointReached -= OnCheckpointReached;
  }

  void OnCharacterKilled(Character character)
  {
    if (character.CharacterType == CharacterType.Dig) isDigDead = true;
    if (character.CharacterType == CharacterType.Duel) isDuelDead = true;

    if (isDigDead && isDuelDead)
    {
      CancelInvoke("RespawnDig");
      CancelInvoke("RespawnDuel");
      gameOverScreen.SetActive(true);
    }
    else
    {
      Invoke(character.CharacterType == CharacterType.Dig ? "RespawnDig" : "RespawnDuel", respawnDelay);
    }
  }

  void OnCharacterSpawned(Character character)
  {
    if (character.CharacterType == CharacterType.Dig) isDigDead = false;
    if (character.CharacterType == CharacterType.Duel) isDuelDead = false;
  }

  void OnCheckpointReached(Checkpoint checkpoint)
  {
    currentSpawnPoint = checkpoint.transform;
  }

  void RespawnDig()
  {
    RespawnCharacter(CharacterType.Dig);
  }

  void RespawnDuel()
  {
    RespawnCharacter(CharacterType.Duel);
  }

  void RespawnCharacter(CharacterType characterType)
  {
    GameObject prefab = characterType == CharacterType.Dig
      ? digPrefab
      : duelPrefab;

    Instantiate(prefab, currentSpawnPoint.position, currentSpawnPoint.rotation);
  }
}
