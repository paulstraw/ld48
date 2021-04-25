using UnityEngine;
using Cinemachine;

public class BrothersVCamTarget : MonoBehaviour
{
  CinemachineTargetGroup targetGroup;

  void Awake()
  {
    targetGroup = GetComponent<CinemachineTargetGroup>();

    Character.OnCharacterSpawned += OnCharacterSpawned;
    Character.OnCharacterKilled += OnCharacterKilled;
  }

  void OnDestroy()
  {
    Character.OnCharacterSpawned -= OnCharacterSpawned;
    Character.OnCharacterKilled -= OnCharacterKilled;
  }

  void OnCharacterSpawned(Character character)
  {
    if (character.CharacterType == CharacterType.Dig)
    {
      targetGroup.m_Targets[0].target = character.transform;
    }
    else if (character.CharacterType == CharacterType.Duel)
    {
      targetGroup.m_Targets[1].target = character.transform;
    }
  }

  void OnCharacterKilled(Character character)
  {
    if (character.CharacterType == CharacterType.Dig)
    {
      targetGroup.m_Targets[0].target = null;
    }
    else if (character.CharacterType == CharacterType.Duel)
    {
      targetGroup.m_Targets[1].target = null;
    }
  }
}
