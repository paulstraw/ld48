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

  void Awake()
  {
    Character.OnCharacterKilled += OnCharacterKilled;
  }

  void OnDestroy()
  {
    Character.OnCharacterKilled -= OnCharacterKilled;
  }

  void OnCharacterKilled(Character character)
  {
    this.Invoke(() => RespawnCharacter(character.CharacterType), respawnDelay);
  }

  private void RespawnCharacter(CharacterType characterType)
  {
    Transform spawnPoint = GetSpawnPoint(characterType);

    GameObject prefab = characterType == CharacterType.Dig
      ? digPrefab
      : duelPrefab;

    Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
  }

  private Transform GetSpawnPoint(CharacterType characterType)
  {
    return defaultSpawnPoint;
  }
}
