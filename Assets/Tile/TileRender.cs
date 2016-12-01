using UnityEngine;
using System.Collections;

public class TileRender : MonoBehaviour {

  public Tile tile;
  public Vector2 position;

  private new MeshRenderer renderer;
  private new BoxCollider2D collider;

  void OnEnable() {
    if (renderer == null)
      renderer = GetComponentInChildren<MeshRenderer>();

    if(collider == null)
      collider = GetComponentInChildren<BoxCollider2D>();

    renderer.material.color = tile.color;
  }

  void Update() {
    if(RectFunctions.colliderSeenByOrthographicCamera(collider, Camera.main) == false) {
      tile.IsRendering = false;
      gameObject.SetActive(false);
    }
  }

}
