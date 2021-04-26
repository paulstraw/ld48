using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable, IKillable
{
  [SerializeField]
  float damagedKnockbackForce = 50;

  [SerializeField]
  public int baseMaxHealth = 10;

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

  Rigidbody2D rb;

  void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
    MaxHealth = baseMaxHealth;
    CurrentHealth = MaxHealth;
  }

  public void Kill()
  {
    if (IsDead) return;
    IsDead = true;

    Destroy(gameObject);
  }

  public void ReceiveDamage(int damageAmount, GameObject source)
  {
    CurrentHealth -= damageAmount;

    if (CurrentHealth <= 0)
    {
      Kill();
    }
    else
    {
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
