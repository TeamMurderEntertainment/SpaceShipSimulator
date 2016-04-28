using UnityEngine;
using System.Collections;

public class Tile {

	public enum TileType { Empty, Floor };

	TileType type = TileType.Empty;

	LooseObject looseObject;
	InstalledObject installeObject;

	Ship ship;
	int x;
	int y;

	public Tile( Ship ship, int x, int y ) {
		this.ship = ship;
		this.x = x;
		this.y = y;
	}
}
