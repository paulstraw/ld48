using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Checkpoint : MonoBehaviour
{
  [SerializeField]
  LayerMask characterMask;

  [SerializeField]
  Light2D light;

  [SerializeField]
  float capturedLightRadius;

  public static event System.Action<Checkpoint> OnCheckpointReached = delegate { };

  Animator animator;

  bool isCaptured = false;

  void Awake()
  {
    animator = GetComponent<Animator>();
  }

  void OnTriggerEnter2D(Collider2D collider)
  {
    if (isCaptured) return;

    if (characterMask.Contains(collider.gameObject.layer))
    {
      isCaptured = true;
      animator.SetBool("IsCaptured", true);
      light.pointLightOuterRadius = capturedLightRadius;

      OnCheckpointReached(this);
    }
  }
}
