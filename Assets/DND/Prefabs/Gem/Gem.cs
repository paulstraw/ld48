using UnityEngine;

public class Gem : MonoBehaviour
{
  public static event System.Action<CharacterType> OnGemCollected = delegate { };

  bool isCollected = false;

  void OnTriggerEnter2D(Collider2D collider)
  {
    if (isCollected) return;

    Character character = collider.gameObject.GetComponent<Character>();

    if (character != null)
    {
      isCollected = true;
      Destroy(gameObject);
      OnGemCollected(character.CharacterType);
    }
  }
}
