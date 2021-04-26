using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
  [SerializeField]
  TextMeshProUGUI text;

  [SerializeField]
  ScoreManager scoreManager;

  void Update()
  {
    text.text = $"Score: {scoreManager.Score}";
  }
}
