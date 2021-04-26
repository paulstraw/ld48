using UnityEngine;

public class Character : MonoBehaviour, IKillable, IDamageable
{
  public static event System.Action<Character> OnCharacterSpawned = delegate { };
  public static event System.Action<Character> OnCharacterKilled = delegate { };

  public event System.Action<float> OnDamaged = delegate { };

  [SerializeField]
  int maxHealth = 10;

  [SerializeField]
  float damagedInvulnerabilityDuration = 2;

  [SerializeField]
  float damagedKnockbackForce = 50;

  public CharacterType CharacterType;

  bool isInvulnerable = false;

  Rigidbody2D rb;

  public bool IsDead
  {
    get;
    private set;
  }

  public int CurrentHealth
  {
    get;
    private set;
  }

  void Awake()
  {
    rb = GetComponent<Rigidbody2D>();

    CurrentHealth = maxHealth;
    OnCharacterSpawned(this);
  }

  public void Kill()
  {
    if (IsDead) return;
    IsDead = true;

    OnCharacterKilled(this);

    Destroy(gameObject);
  }

  public void ReceiveDamage(int amount, GameObject source)
  {
    if (isInvulnerable)
    {
      return;
    }

    isInvulnerable = true;
    this.Invoke(() => isInvulnerable = false, damagedInvulnerabilityDuration);

    CurrentHealth -= amount;

    if (CurrentHealth <= 0)
    {
      Kill();
    }
    else
    {
      OnDamaged(damagedInvulnerabilityDuration);

      float xKnockback = source.transform.position.x > transform.position.x
        ? -damagedKnockbackForce
        : damagedKnockbackForce;

      rb.AddForce(new Vector2(xKnockback, damagedKnockbackForce));
    }
  }
}
