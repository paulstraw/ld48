using UnityEngine;

public class BottomlessPit : MonoBehaviour
{
  [SerializeField]
  LayerMask mask;

  void OnTriggerEnter2D(Collider2D collider)
  {
    IKillable killable = collider.gameObject.GetComponentInChildren<IKillable>();

    if (killable != null)
    {
      killable.Kill();
    }
  }
}
