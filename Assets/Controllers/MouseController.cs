using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {

	public GameObject circleCursor;

	Vector3 lastFramePosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Gets mouse position in world at start of update
		Vector3 currFramePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		currFramePosition.z = 0;

		// Update the circle cursor posion
		Tile tileUnderMouse = GetTileAtWorldCoord( currFramePosition );
		Vector3 curserPosition = new Vector3( tileUnderMouse.X, tileUnderMouse.Y, 0 );
		circleCursor.transform.position = curserPosition;

		// Handle left mouse clicks
		if(Input.GetMouseButtonUp(0)){
			if(tileUnderMouse!=null)
			{
				if(tileUnderMouse.Type == Tile.TileType.Empty)
				{
					tileUnderMouse.Type = Tile.TileType.Floor;

				} 
				else
				{
					tileUnderMouse.Type = Tile.TileType.Empty;
				}
			}
		}


		// Handle screen dragging
		if(Input.GetMouseButton(2) ){

			Vector3 diff = lastFramePosition - currFramePosition;
			Camera.main.transform.Translate (diff);
		}

		// Gets mouse position in world at end of update
		lastFramePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		lastFramePosition.z = 0;
	}

	Tile GetTileAtWorldCoord(Vector3 coord){
		int x = Mathf.FloorToInt(coord.x);
		int y = Mathf.FloorToInt(coord.y);

		return ShipController.Instance.ship.GetTileAt(x, y);
	}
}
