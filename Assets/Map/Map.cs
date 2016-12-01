using UnityEngine;
using System.Collections;

public class Map{

  private int mapWidth;
  private int mapHeight;
  private Tile[,] tiles;

  public Map(int width, int height) {
    mapWidth = width;
    mapHeight = height;
    tiles = new Tile[mapWidth,mapHeight];

    for (int x = 0; x < width; x++) {
      for (int y = 0; y < height; y++) {
        tiles[x, y] = new Tile();
      }
    }

    tiles[1, 1].color = Color.red;
  }

  public Tile getTile(int x, int y) {
    if (x >= 0 && x < mapWidth && y >= 0 && y < mapHeight) {
      return tiles[x, y];
    }

    return null;
  }

  public void makeLookLikeTexture(Texture2D tex) {
    for (int x = 0; x < Width; x++) {
      for (int y = 0; y < Height; y++) {
        getTile(x, y).color = tex.GetPixel(x, y);
        
        //if (tex.GetPixel(x,y).b == 0) {
        //  getTile(x, y).color = Color.black;
        //}
        //else {
        //  getTile(x, y).color = Color.blue;
        //}
      }
    }
  }

  public int Width { get { return mapWidth; } }
  public int Height { get { return mapHeight; } }
}
