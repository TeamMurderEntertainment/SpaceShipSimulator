using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	static ShipController _instance;
	public static ShipController Instance { get; protected set;}

	public Sprite floorSprite;

	public Ship ship { get; protected set;}

	// Use this for initialization
	void Start () {
		Instance = this;

		Debug.Log ("Making new ship");
		ship = new Ship();

		//Create a GameObject to Show visualy
		for (int x = 0; x < ship.Width; x++) {
			for (int y = 0; y < ship.Height; y++) {
				Tile tile_data = ship.GetTileAt (x, y);

				GameObject tile_go = new GameObject();
				tile_go.name = "Tile_" + x + "_" + y;
				tile_go.transform.position = new Vector3 (tile_data.X, tile_data.Y, 0);
				tile_go.transform.SetParent(this.transform, true);

				tile_go.AddComponent<SpriteRenderer>();
				//Debug.Log("Registering callback for "+tile_go.name);
				tile_data.RegisterTileTypeChangedCallback( (tile) => { OnTileTypeChanged(tile,tile_go);});
				tile_data.Type = Tile.TileType.Floor;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTileTypeChanged(Tile tile_data, GameObject tile_go){
		Debug.Log("Checking " + tile_go.name + ", Type is "+tile_data.Type);

		if (tile_data.Type == Tile.TileType.Floor) {
			Debug.Log("Setting tile sprite to floor.");
			tile_go.GetComponent<SpriteRenderer>().sprite = floorSprite;
		} else if (tile_data.Type == Tile.TileType.Empty) {
			tile_go.GetComponent<SpriteRenderer>().sprite = null;
		} else {
			Debug.LogError ("OnTileTypeChanged - Unrecognized tile type.");
		}
	}
}
