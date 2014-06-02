using UnityEngine;
using System.Collections;
using System;

public class RoomSlotBehavior : MonoBehaviour, IComparable<RoomSlotBehavior> {

	public int deckNumber;
	public RoomFunction fixedFunction = RoomFunction.None;

	private InventoryItem item;

	public InventoryItem Item {
				get { return item; }
				set { item = Item; }
		}

	private bool isSelected = false;

	public int UnigeID = 0;

	public enum RoomFunction {
		None,
		Machine,
		Control,
		Shield,
		WeaponControll,
		Teleporter,
		Cargo,
		Sensor,
		MedicalBay,
		LifeSupport
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddItem(InventoryItem item){
				this.item = item;
		}

	public int CompareTo(RoomSlotBehavior other){
		if (other == null)
						return 1;
		if (other.UnigeID == this.UnigeID && other != this) {
			print ("Warning: Two roomSlots with same ID " + this.UnigeID);
			return 0;
		}
		return this.UnigeID - other.UnigeID;
		}
}
