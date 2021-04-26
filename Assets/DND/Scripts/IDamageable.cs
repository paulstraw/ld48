using UnityEngine;

public interface IDamageable
{
  void ReceiveDamage(int amount, GameObject source);
  int CurrentHealth { get; }
  int MaxHealth { get; }
}
