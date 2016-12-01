using UnityEngine;
using System.Collections;

[System.Serializable]
public class Tile{
  public Color color;
  private bool isRendering;

  public bool IsRendering {
    get { return isRendering; }
    set { isRendering = value; }
  }
}
