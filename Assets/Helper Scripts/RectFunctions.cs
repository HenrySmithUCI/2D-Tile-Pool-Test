using UnityEngine;
using System.Collections;

public class RectFunctions{

  public static float cameraRectBuffer = 1.1f;

	public static bool colliderSeenByOrthographicCamera(BoxCollider2D col, Camera cam) {
    Rect colliderRect = new Rect();
    colliderRect.size = new Vector2(col.size.x * col.transform.lossyScale.x, col.size.y * col.transform.lossyScale.y);
    colliderRect.center = new Vector2(col.offset.x + col.transform.position.x, col.offset.y + col.transform.position.y);

    Rect cameraRect = getCameraRect(cam);

    return colliderRect.Overlaps(cameraRect);
  }

  public static Rect getCameraRect(Camera cam) {

    Rect cameraRect = new Rect();
    cameraRect.size = ((cam.ViewportToWorldPoint(new Vector3(1f, 1f)) - cam.transform.position) * 2) * cameraRectBuffer;
    cameraRect.center = cam.transform.position;

    return cameraRect;
  }

  //Left, bottom, right, top
  public static int[] roundRectToInts(Rect rect) {
    int[] sides = new int[4];
    sides[0] = Mathf.RoundToInt(rect.xMin);
    sides[1] = Mathf.RoundToInt(rect.yMin);
    sides[2] = Mathf.RoundToInt(rect.xMax);
    sides[3] = Mathf.RoundToInt(rect.yMax);
    return sides;
  }
}
