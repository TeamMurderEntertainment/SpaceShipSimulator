using UnityEngine;
using System.Collections;

public class Ship {

	Tile[,] tiles;
	int width;

	public int Width {
		get {
			return width;
		}
	}

	int height;

	public int Height {
		get {
			return height;
		}
	}

	public Ship(int width = 10, int height = 20){
		this.width = width;
		this.height = height;

		// this makes a ship locked at the maximum of what is feed here
		// in the future this will have to be expandible,in all directions
		// for now this is fine
		tiles = new Tile[width, height];

		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				tiles [x, y] = new Tile (this, x, y);
			}
		}

		Debug.Log ("Ship created with " + (width * height) + " tiles");
	}

	public Tile GetTileAt(int x, int y){
//		if ( x > width || x < 0 || y > height || y > 0 ){
//			Debug.LogError ("Tile (" + x + "," + y + ") is out of range.");
//			return null;
//		}
		Debug.Log(x+","+y);
		return tiles [x, y];
	}

}
