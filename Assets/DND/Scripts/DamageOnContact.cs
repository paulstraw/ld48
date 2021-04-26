using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
  [SerializeField]
  LayerMask mask;

  [SerializeField]
  int damageAmount;

  void OnCollisionEnter2D(Collision2D collision)
  {
    IDamageable damageable = collision.gameObject.GetComponentInChildren<IDamageable>();

    if (damageable != null && mask.Contains(collision.gameObject.layer))
    {
      damageable.ReceiveDamage(damageAmount, gameObject);
    }
  }
}
