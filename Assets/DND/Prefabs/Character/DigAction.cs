using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class DigAction : MonoBehaviour
{
  [SerializeField]
  LayerMask diggableMask;

  [SerializeField]
  GameObject destroyedTilePrefab;

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

      SpawnDestroyedTile(tilemap, cell);
      tilemap.SetTile(cell, null);
    }
  }

  void SpawnDestroyedTile(Tilemap tilemap, Vector3Int cell)
  {
    Sprite sprite = tilemap.GetSprite(cell);
    if (sprite == null || sprite.texture == null) return;

    Color centerColor = sprite.texture.GetPixel(
      (int)sprite.textureRect.center.x,
      (int)sprite.textureRect.center.y
    );

    GameObject destroyedTile = Instantiate(
      destroyedTilePrefab,
      cell + new Vector3(0.5f, 0.5f, 0),
      Quaternion.identity
    );
    ParticleSystem particles = destroyedTile.GetComponent<ParticleSystem>();

    particles.GetComponent<Renderer>().material.color = centerColor;
  }
}
