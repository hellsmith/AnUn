using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControll : MonoBehaviour {

	//-----------------------------------------------------
	// Variables for the Game.
	//-----------------------------------------------------

	public GameObject 	playerShip;
	static GameControll reference;
	private GameObject selectedShip = null;
	public List<GameObject> ShipList;
	
	//----------------------------------------------------------------------------------------------------------
	//-- Variables End
	//----------------------------------------------------------------------------------------------------------

	//----------------------------------------------------------------------------------------------------------
	//-- Getter & Setter
	//----------------------------------------------------------------------------------------------------------
	public static GameControll getRef(){
		return reference;
	}

	public GameObject SelectedShip {
				get {
						return selectedShip;
				}
				set {
						selectedShip = value;
				}
		}
	public GameObject getSelectedShip(){
		return selectedShip;
	}

	//----------------------------------------------------------------------------------------------------------
	//-- Start function
	//----------------------------------------------------------------------------------------------------------
	void Start () {
		ShipList = new List<GameObject>();
		reference = this;
	//	selectedShip = (GameObject) GameObject.Instantiate (playerShip);


	}

	//----------------------------------------------------------------------------------------------------------
	// Update is called once per frame
	//----------------------------------------------------------------------------------------------------------
	void Update () {

	}
}
