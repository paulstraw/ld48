using UnityEngine;

public class FireSnakeAttack : MonoBehaviour
{
  [SerializeField]
  Transform[] attackCheckTargets;

  [SerializeField]
  float attackCheckRange;

  [SerializeField]
  LayerMask attackCheckMask;

  [SerializeField]
  GameObject fireballPrefab;

  [SerializeField]
  Transform[] fireballSpawnLocations;

  [SerializeField]
  float cooldownLength;

  [SerializeField]
  float movementPauseLength;

  float cooldownTimer;

  bool coolingDown = false;

  EnemyAI enemyAI;

  void Awake()
  {
    enemyAI = GetComponent<EnemyAI>();
  }

  void Update()
  {
    if (coolingDown)
    {
      cooldownTimer -= Time.deltaTime;

      if (cooldownTimer <= 0)
      {
        coolingDown = false;
      }

      return;
    }

    bool characterDetected = DetectCharacters();

    if (characterDetected)
    {
      Attack();
    }
  }

  bool DetectCharacters()
  {
    for (int i = 0; i < attackCheckTargets.Length; i++)
    {
      Vector3 checkPos = attackCheckTargets[i].position;

      RaycastHit2D hit = Physics2D.Raycast(transform.position, checkPos - transform.position, attackCheckRange, attackCheckMask);

      if (hit.collider == null)
      {
        continue;
      }
      else
      {
        return true;
      }
    }

    return false;
  }

  void Attack()
  {
    coolingDown = true;
    cooldownTimer = cooldownLength;

    enemyAI.PauseMovement();
    this.Invoke(() => enemyAI.UnpauseMovement(), movementPauseLength);

    Debug.Log("Totally will attack");
  }
}
