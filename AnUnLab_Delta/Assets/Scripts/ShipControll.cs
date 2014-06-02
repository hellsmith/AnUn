using UnityEngine;
using System.Collections;

public class ShipControll : MonoBehaviour {

	private static ShipControll reference;

	public static ShipControll getRef(){
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

	// Use this for initialization
	void Start () {
		reference = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
