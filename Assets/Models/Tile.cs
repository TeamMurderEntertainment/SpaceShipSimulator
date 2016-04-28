using UnityEngine;
using System.Collections;

public class Tile {

	public enum TileType { Empty, Floor };

	TileType type = TileType.Empty;

	public TileType Type {
		get {
			return type;
		}
		set {
			type = value;
		}
	}

	LooseObject looseObject;
	InstalledObject installeObject;

	Ship ship;
	int x;

	public int X {
		get {
			return x;
		}
	}

	int y;

	public int Y {
		get {
			return y;
		}
	}

	public Tile( Ship ship, int x, int y ) {
		this.ship = ship;
		this.x = x;
		this.y = y;
	}
}
