using UnityEngine;
using System.Collections;

public class CurveTest : MonoBehaviour {

  public Mesh pointMesh;
  public int n;

	// Use this for initialization
	void Start () {
    PerlinCurve pc1 = new PerlinCurve();

    PerlinCurve pc2 = new PerlinCurve(layers: 5, layerRatio: 2, topLayerCount: 3);

    for (int i = 0; i < n; i++) {
      float x = (float)i / (float)n;

      makePoint(new Vector3(x, pc1.evaluate(x)), i.ToString());
    }
	}

  private void makePoint(Vector3 pos, string name = "New Game Object") {
    GameObject go = new GameObject();
    go.AddComponent<MeshFilter>().mesh = pointMesh;
    go.AddComponent<MeshRenderer>();
    go.name = name;
    go.transform.parent = transform;
    go.transform.localPosition = pos;
    go.transform.localScale = new Vector3(0.1f / transform.localScale.x, 0.1f / transform.localScale.y, 0.1f);
  }
}
