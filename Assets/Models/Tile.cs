using UnityEngine;
using System.Collections;
using System;

public class Tile {

	public enum TileType { Empty, Floor };

	TileType type = TileType.Empty;

	Action<Tile> cbTileTypeChanged;

	public TileType Type {
		get {
			return type;
		}
		set {
			type = value;

			if (cbTileTypeChanged != null)
				cbTileTypeChanged(this);
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

	public void RegisterTileTypeChangedCallback(Action<Tile> callback){
		cbTileTypeChanged += callback;
	}

	public void UnregisterTileTypeChangedCallback(Action<Tile> callback){
		cbTileTypeChanged -= callback;
	}
}
