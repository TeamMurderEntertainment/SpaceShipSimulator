using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {

	public GameObject circleCursor;

	Vector3 lastFramePosition;
	Vector3 dragStartPosition;

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
		// Start Drag
		if ( Input.GetMouseButtonDown(0) )
		{
			dragStartPosition = currFramePosition;
		}

		// End Drag
		if(Input.GetMouseButtonUp(0)){
			int start_x = 	Mathf.FloorToInt( dragStartPosition.x );
			int end_x =	Mathf.FloorToInt( curserPosition.x );
			if ( end_x < start_x )
			{
				int tmp = end_x;
				end_x = start_x;
				start_x = tmp;
			}

			int start_y = 	Mathf.FloorToInt( dragStartPosition.y );
			int end_y =	Mathf.FloorToInt( curserPosition.y );
			if ( end_y < start_y )
			{
				int tmp = end_y;
				end_y = start_y;
				start_y = tmp;
			}

			for ( int x = 0 ; start_x <= end_x ; x++ )
			{
				for ( int y = start_y ; y <= end_y ; y++ )
				{
					Tile t = ShipController.Instance.ship.GetTileAt( x, y );
					if ( t != null )
					{
						t.Type = Tile.TileType.Floor;
					}
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
