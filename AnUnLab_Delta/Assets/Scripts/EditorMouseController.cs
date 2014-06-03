using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EditorMouseController : MonoBehaviour {

	public LayerMask interiorLayer;

	// Use this for initialization
	void Start () {
	
	}

	private Rect windowRect = new Rect (0, 0, 200, 240);
	private Vector2 scrollWindowPos = Vector2.zero;

	RoomSlotBehavior selectedRoom;
	
	// Update is called once per frame
	void Update () {

		Vector2 mousePos = new Vector2 (Input.mousePosition.x, Screen.height - Input.mousePosition.y);

		if ((selectedRoom != null && !windowRect.Contains (mousePos)) || selectedRoom == null) {
						if (Input.GetMouseButtonDown (0)) {
				print ("rect" + windowRect + "  mouse " + mousePos);
								RaycastHit hit;
								Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
								if (Physics.Raycast (ray, out hit, 10000, interiorLayer)) {

										RoomSlotBehavior room = hit.collider.GetComponent<RoomSlotBehavior> ();
										if (room != null) {
												selectedRoom = room;
										}

								} else {
										selectedRoom = null;
								}
						}
				}
	}

	void PaintRoomSelection(int windowID){
		List<InventoryItem> selectableList = new List<InventoryItem> ();
		if (selectedRoom.fixedFunction != RoomSlotBehavior.RoomFunction.None) {
						for (int i = 0; i < Inventory.getRef().itemList.Count; i++)
								if (Inventory.getRef ().itemList [i].Function == selectedRoom.fixedFunction)
										selectableList.Add (Inventory.getRef ().itemList [i]);
				} else {
						selectableList = Inventory.getRef ().itemList;
				}

		if (selectedRoom.Item != null)
						GUI.Label (new Rect (10, 15, windowRect.width - 20, 25), selectedRoom.Item.Name);

		scrollWindowPos = GUI.BeginScrollView (new Rect (5, 45, windowRect.width - 10, windowRect.height - 35), scrollWindowPos, new Rect (0, 0, Screen.width - 40, selectableList.Count * 40));

		int spacer = 0;

		for(int i = 0; i < selectableList.Count; i++){
			if(GUI.Button(new Rect(5,i * 34 + 5, windowRect.width - 30, 30), selectableList[i].Name)){
				selectedRoom.AddItem(Inventory.getRef().itemList[i]);
			}
		}
		GUI.EndScrollView();
		}

	void OnGUI(){
		if (selectedRoom != null) {
			Vector3 windowPos = Camera.main.WorldToScreenPoint(selectedRoom.transform.position);
			windowRect.position = new Vector2(windowPos.x,Screen.height - windowPos.y);
			GUI.Window (0, windowRect, PaintRoomSelection, "Select");
		}
	}
}
