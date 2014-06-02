using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteriorNodeBehavior : MonoBehaviour {

	List<RoomSlotBehavior> roomSlotList = new List<RoomSlotBehavior>();

	// Use this for initialization
	void Start () {
		RoomSlotBehavior [] slots = this.GetComponentsInChildren<RoomSlotBehavior> ();
		for (int i = 0; i < slots.Length; i++) {
			roomSlotList.Add(slots[i]);
				}
		roomSlotList.Sort ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
