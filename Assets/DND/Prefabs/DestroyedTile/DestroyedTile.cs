using UnityEngine;

public class DestroyedTile : MonoBehaviour
{
  [SerializeField]
  float selfDestructTimeoutLength = 1;

  void Awake()
  {
    this.Invoke(() =>
    {
      Destroy(gameObject);
    }, selfDestructTimeoutLength);
  }
}
