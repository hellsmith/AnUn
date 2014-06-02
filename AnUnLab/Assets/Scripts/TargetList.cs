using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetList : MonoBehaviour {

	private List<GameObject> shiplist;
	private GameObject gameController;
	private Rect WindowRect = new Rect(0,0,0,0);
	private int leftIndent;
	private int topIndent;
	private int WindowWidth = 220;
	private int WindowHeight= 300;


	// Use this for initialization
	void Start () {
		shiplist = new List<GameObject> ();
		gameController = GameObject.FindGameObjectWithTag ("GameController");
	}
	
	// Update is called once per frame
	void Update () {

		foreach (GameObject i in gameController.GetComponent<GameControll>().ShipList)
						if (!shiplist.Contains (i))
								shiplist.Add (i);

		if (shiplist.Contains (null))
						shiplist.Remove (null);
	}

	void LateUpdate(){

	}

	void OnGUI (){

		leftIndent = Screen.width - WindowWidth -10 ;
		
		topIndent = 10;
		
		WindowRect = new Rect(leftIndent, topIndent, WindowWidth,
		                                WindowHeight);
		
		WindowRect = GUI.Window(3, WindowRect, shipWindow,"ShipList");
	}

	void shipWindow(int windowID)
	{
		float offset = 0f;
		foreach(GameObject i in shiplist){
			if(!i.Equals(null)){
				GUI.Button(new Rect(10,20+offset,200,35),i.GetComponent<ShipBean>().ShipName);
				offset += 35;
			}
		}
	}
}
