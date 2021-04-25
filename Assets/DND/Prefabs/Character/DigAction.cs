using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class DigAction : MonoBehaviour
{
  [SerializeField]
  LayerMask diggableMask;

  GameplayControls controls;
  Reticle reticle;

  void Start()
  {
    controls = FindObjectOfType<PlayerController>().Controls;
    reticle = GetComponentInChildren<Reticle>();

    controls.Digger.DigAction.performed += HandleDiggerActionPerformed;
  }

  void OnDestroy()
  {
    controls.Digger.DigAction.performed -= HandleDiggerActionPerformed;
  }

  void HandleDiggerActionPerformed(InputAction.CallbackContext ctx)
  {
    Vector3 reticlePos = reticle.transform.position;
    Collider2D diggableCollider = Physics2D.OverlapPoint(reticlePos, diggableMask);

    if (diggableCollider != null)
    {
      Grid grid = diggableCollider.gameObject.GetComponentInParent<Grid>();
      Tilemap tilemap = diggableCollider.gameObject.GetComponent<Tilemap>();
      Vector3Int cell = grid.WorldToCell(reticlePos);

      tilemap.SetTile(cell, null);
    }
  }
}
