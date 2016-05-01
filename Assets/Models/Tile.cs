using UnityEngine;
using System.Collections;
using System;

public class Tile {

	public enum TileType { Empty, Floor };

	TileType type = TileType.Empty;

	Action<Tile> cbTileTypeChanged;

	public TileType Type {
		get {return type;}
		set {
			TileType oldType = type;
			type = value;

			if (cbTileTypeChanged != null && oldType != type)
				cbTileTypeChanged(this);
		}
	}

	// LooseObject is somthing that is not fixed in location, and can be picked up move
	LooseObject looseObject;

	// InstalledObject is somthing that is fix in place,like furnature or machinery
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
