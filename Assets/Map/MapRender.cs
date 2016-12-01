using UnityEngine;
using System.Collections;

public class MapRender : MonoBehaviour {

  public int width;
  public int height;
  public Sprite sprite;

  private Map map;
  private ObjectPool objPool;

	void Start () {
    map = new Map(width, height);
    map.makeLookLikeTexture(sprite.texture);
    objPool = GetComponent<ObjectPool>();
    print(objPool);
  }

	void Update () {
    int[] intCameraRect = RectFunctions.roundRectToInts(RectFunctions.getCameraRect(Camera.main));

    for (int x = intCameraRect[0]; x <= intCameraRect[2]; x++) {
      for (int y = intCameraRect[1]; y <= intCameraRect[3]; y++) {

        Tile tile = map.getTile(x, y);
        if (tile == null) {
          continue;
        }

        if (tile.IsRendering == false) {
          GameObject obj = objPool.GetPooledObject();
          TileRender tileRender = obj.GetComponent<TileRender>();
          tileRender.tile = tile;
          tileRender.tile.IsRendering = true;
          tileRender.transform.position = new Vector2(x, y);
          tileRender.gameObject.SetActive(true);
        }
      }
    }
	}
}
