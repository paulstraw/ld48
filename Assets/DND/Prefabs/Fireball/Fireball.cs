using UnityEngine;

public class Fireball : MonoBehaviour
{
  [SerializeField]
  float speed;

  public bool Flipped = false;

  Rigidbody2D rb;

  void Awake()
  {
    this.Invoke(() => Destroy(gameObject), 3f);
  }

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    rb.velocity = transform.TransformDirection(new Vector2(Flipped ? speed : -speed, 0));

    if (Flipped)
    {
      Vector3 newScale = transform.localScale;
      newScale.x *= -1;
      transform.localScale = newScale;
    }
  }
}
