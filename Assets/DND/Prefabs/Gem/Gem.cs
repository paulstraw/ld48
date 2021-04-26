using UnityEngine;

public class Gem : MonoBehaviour
{
  public static event System.Action<CharacterType> OnGemCollected = delegate { };

  void OnTriggerEnter2D(Collider2D collider)
  {
    Character character = collider.gameObject.GetComponent<Character>();

    if (character != null)
    {
      Destroy(gameObject);
      OnGemCollected(character.CharacterType);
    }
  }
}
