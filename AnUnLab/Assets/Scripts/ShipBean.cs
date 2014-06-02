using UnityEngine;
using System.Collections;

public class ShipBean : MonoBehaviour {

	private GameObject gameController;
	private string shipName;

	public string ShipName {
		get {
			return shipName;
		}
		set {
			networkView.RPC("TellShipName", RPCMode.All,value);
		}
	}



	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		gameController.GetComponent<GameControll> ().ShipList.Add (this.gameObject);
		if (!networkView.isMine)
			networkView.RPC ("CallShipName", RPCMode.Server);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnDestroy(){
		if (!networkView.isMine && !this.gameObject.Equals(null) ) {
			gameController.GetComponent<GameControll> ().ShipList.Remove (this.gameObject);
		}
		Debug.Log ("Ich werde destroyed..");
	}

	[RPC]
	void TellShipName (string name)
	{
		shipName = name;
	}

	[RPC]
	void CallShipName ()
	{
		networkView.RPC("TellShipName", RPCMode.All,shipName);
	}

}

