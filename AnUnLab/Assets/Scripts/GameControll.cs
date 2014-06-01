using UnityEngine;
using System.Collections;

public class GameControll : MonoBehaviour {

	public GameObject playerShip;

	static GameControll reference;

	public static GameControll getRef(){
		return reference;
	}

	private GameObject selectedShip = null;

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

	// Use this for initialization
	void Start () {
		reference = this;
		selectedShip = (GameObject) GameObject.Instantiate (playerShip);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
