using UnityEngine;
using Cinemachine;

public class BrothersVCamTarget : MonoBehaviour
{
  CinemachineTargetGroup targetGroup;

  void Awake()
  {
    targetGroup = GetComponent<CinemachineTargetGroup>();

    CharacterLifecycle.OnCharacterSpawned += OnCharacterSpawned;
    CharacterLifecycle.OnCharacterKilled += OnCharacterKilled;
  }

  void OnDestroy()
  {
    CharacterLifecycle.OnCharacterSpawned -= OnCharacterSpawned;
    CharacterLifecycle.OnCharacterKilled -= OnCharacterKilled;
  }

  void OnCharacterSpawned(CharacterLifecycle characterLifecycle)
  {
    if (characterLifecycle.CharacterType == CharacterType.Dig)
    {
      targetGroup.m_Targets[0].target = characterLifecycle.transform;
    }
    else if (characterLifecycle.CharacterType == CharacterType.Duel)
    {
      targetGroup.m_Targets[1].target = characterLifecycle.transform;
    }
  }

  void OnCharacterKilled(CharacterLifecycle characterLifecycle)
  {
    if (characterLifecycle.CharacterType == CharacterType.Dig)
    {
      targetGroup.m_Targets[0].target = null;
    }
    else if (characterLifecycle.CharacterType == CharacterType.Duel)
    {
      targetGroup.m_Targets[1].target = null;
    }
  }
}
