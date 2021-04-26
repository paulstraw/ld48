using UnityEngine;

public class Character : MonoBehaviour, IKillable, IDamageable
{
  public static event System.Action<Character> OnCharacterSpawned = delegate { };
  public static event System.Action<Character> OnCharacterKilled = delegate { };

  public event System.Action<float> OnDamaged = delegate { };

  [SerializeField]
  public int baseMaxHealth = 10;

  [SerializeField]
  float damagedInvulnerabilityDuration = 2;

  [SerializeField]
  float damagedKnockbackForce = 50;

  [SerializeField]
  GameObject deathAnimationPrefab;

  [SerializeField]
  Sprite deathSprite;

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

  public int MaxHealth
  {
    get;
    private set;
  }

  void Awake()
  {
    rb = GetComponent<Rigidbody2D>();

    MaxHealth = baseMaxHealth;
    CurrentHealth = MaxHealth;
    OnCharacterSpawned(this);
  }

  public void Kill()
  {
    if (IsDead) return;
    IsDead = true;

    OnCharacterKilled(this);

    GameObject deathAnimation = Instantiate(deathAnimationPrefab, transform.position, Quaternion.identity);
    deathAnimation.GetComponent<SpriteRenderer>().sprite = deathSprite;

    Destroy(gameObject);
  }

  public void ReceiveDamage(int damageAmount, GameObject source)
  {
    if (isInvulnerable)
    {
      return;
    }

    isInvulnerable = true;
    this.Invoke(() => isInvulnerable = false, damagedInvulnerabilityDuration);

    CurrentHealth -= damageAmount;

    if (CurrentHealth <= 0)
    {
      Kill();
    }
    else
    {
      OnDamaged(damagedInvulnerabilityDuration);
      KnockBack(damageAmount, source);
    }
  }

  void KnockBack(int damageAmount, GameObject source)
  {
    float xKnockback = source.transform.position.x > transform.position.x
      ? -damagedKnockbackForce
      : damagedKnockbackForce;

    rb.AddForce(new Vector2(xKnockback, damagedKnockbackForce), ForceMode2D.Impulse);
  }
}
