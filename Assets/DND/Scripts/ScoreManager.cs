using UnityEngine;

public class ScoreManager : MonoBehaviour
{
  [SerializeField]
  int deathScoreDecrease = 25;

  [SerializeField]
  int gemScoreIncrease = 50;

  public int Score
  {
    get;
    private set;
  }

  void Awake()
  {
    Gem.OnGemCollected += OnGemCollected;
    Character.OnCharacterKilled += OnCharacterKilled;
  }

  void OnGemCollected(CharacterType characterType)
  {
    Score += gemScoreIncrease;
  }

  void OnCharacterKilled(Character character)
  {
    Score = (int)Mathf.Clamp(Score - deathScoreDecrease, 0, Mathf.Infinity);
  }
}
