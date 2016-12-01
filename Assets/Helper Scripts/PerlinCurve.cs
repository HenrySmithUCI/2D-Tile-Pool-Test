using UnityEngine;
using System.Collections;

public class PerlinCurve {

  private float[][] nodes;
  private int ratioBetweenLayers;

  public PerlinCurve(int layers = 3, int topLayerCount = 5, int layerRatio = 2) {
    nodes = new float[layers][];
    ratioBetweenLayers = layerRatio;
    for(int i = 0; i < layers; i++) {
      nodes[i] = new float[topLayerCount * IntPow(layerRatio,(uint)i)];
    }

    for (int i = 0; i < nodes.Length; i++) {
      for (int j = 0; j < nodes[i].Length; j++) {
        nodes[i][j] = Random.Range(-0.5f, 0.5f);
      }
    }
  }


  public float evaluate(float x) {
    float ret = 0;
    for (int i = 0; i < nodes.Length; i++) {
      if (x >= 1) {
        ret += nodes[i][nodes[i].Length - 1];
        continue;
      }

      if (x < 0) {
        ret += nodes[i][0];
        continue;
      }

      int floorIndex = getFloorIndex(nodes[i].Length, x);
      float y1 = nodes[i][floorIndex];
      float y2 = nodes[i][floorIndex + 1];

      ret += (cosinInterpolate(y1, y2, (x * (float)(nodes[i].Length - 1)) % 1)) / (float)IntPow(ratioBetweenLayers,(uint)i);
    }

    return ret;
  }

  private int getFloorIndex(int listLength, float value) {
    if (value >= 1) {
      return listLength - 1;
    }

    if (value < 0) {
      return 0;
    }
    
    return Mathf.FloorToInt(value * (listLength - 1));
    
  }

  //Thanks paulbourke.net
  private float cosinInterpolate(float y1, float y2, float x) {
    float x2 = (1f - Mathf.Cos(x * Mathf.PI)) / 2f;
    float ret = (y1 * (1f - x2) + y2 * x2);
    return ret;
  }

  //Thanks Stack Overflow
  public static int IntPow(int x, uint pow) {
    int ret = 1;
    while (pow != 0) {
      if ((pow & 1) == 1)
        ret *= x;
      x *= x;
      pow >>= 1;
    }
    return ret;
  }
}
