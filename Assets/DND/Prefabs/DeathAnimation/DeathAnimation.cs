using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
  [SerializeField]
  float selfDestuctTimeoutLength = 3;

  [SerializeField]
  float upwardForce = 30;

  void Awake()
  {
    this.Invoke(() => Destroy(gameObject), selfDestuctTimeoutLength);

    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, upwardForce), ForceMode2D.Impulse);
  }
}
