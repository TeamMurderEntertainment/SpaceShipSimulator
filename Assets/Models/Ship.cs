using UnityEngine;
using System.Collections;

public class Ship {

	Tile[,] tiles;
	int width;
	int height;

	public Ship(int width = 10, int height = 30){
		this.width = width;
		this.height = height;

		tiles = new Tile[width, height];

		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				tiles [x, y] = new Tile (this, x, y);
			}
		}

		Debug.Log ("Ship created with " + (width * height) + " tiles");
	}

}
