using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	Ship ship;

	// Use this for initialization
	void Start () {
		Debug.Log ("Making new ship");
		ship = new Ship();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
