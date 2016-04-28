using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	public Sprite floorSprite;

	Ship ship;

	// Use this for initialization
	void Start () {
		Debug.Log ("Making new ship");
		ship = new Ship();

		//Create a GameObject to Show visualy
		for (int x = 0; x < ship.Width; x++) {
			for (int y = 0; y < ship.Height; y++) {
				Tile tile_data = ship.GetTileAt (x, y);

				GameObject tile_go = new GameObject();
				tile_go.name = "Tile_" + x + "_" + y;
				tile_go.transform.position = new Vector3 (tile_data.X, tile_data.Y, 0);

				SpriteRenderer tile_sr = tile_go.AddComponent<SpriteRenderer>();

				if (tile_data.Type == Tile.TileType.Floor) {
					tile_sr.sprite = floorSprite;
				}
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTileTypeChanged(Tile tile_data, GameObject tile_go){

		if (tile_data.Type == Tile.TileType.Floor) {
			tile_go.GetComponent<SpriteRenderer> ().sprite = floorSprite;
		} else if (tile_data.Type == Tile.TileType.Empty) {
			tile_go.GetComponent<SpriteRenderer> ().sprite = null;
		} else {
			Debug.LogError ("OnTileTypeChanged - Unrecognized tile type.");
		}
	}
}
