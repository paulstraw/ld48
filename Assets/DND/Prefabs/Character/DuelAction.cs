using UnityEngine;
using UnityEngine.InputSystem;

public class DuelAction : MonoBehaviour
{
  [SerializeField]
  float attackRange = 1;

  [SerializeField]
  int attackDamage = 4;

  [SerializeField]
  LayerMask attackMask;

  GameplayControls controls;
  Reticle reticle;

  void Start()
  {
    controls = FindObjectOfType<PlayerController>().Controls;
    reticle = GetComponentInChildren<Reticle>();

    controls.Fighter.DuelAction.performed += HandleDuelActionPerformed;
  }

  void OnDestroy()
  {
    controls.Fighter.DuelAction.performed -= HandleDuelActionPerformed;
  }

  void HandleDuelActionPerformed(InputAction.CallbackContext ctx)
  {
    Vector3 reticlePos = reticle.transform.position;

    RaycastHit2D hit = Physics2D.Raycast(transform.position, reticlePos - transform.position, attackRange, attackMask);

    if (hit.collider == null) return;

    IDamageable damageable = hit.collider.gameObject.GetComponent<IDamageable>();


    if (damageable != null)
    {
      damageable.ReceiveDamage(attackDamage, gameObject);
    }
  }
}
