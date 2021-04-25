using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
  [SerializeField]
  Transform defaultSpawnPoint;

  public Transform GetSpawnPoint(CharacterType characterType)
  {
    return defaultSpawnPoint;
  }
}
