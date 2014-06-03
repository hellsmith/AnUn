using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class RoomSlotBehavior : MonoBehaviour, IComparable<RoomSlotBehavior> {

	public int deckNumber;
	public RoomFunction fixedFunction = RoomFunction.None;

	private InventoryItem item;

	float neighborBonus = 0;

	public float NeighborBonus {
				get { return neighborBonus; }
				set { neighborBonus = value; }
		}

	private List<RoomSlotBehavior> neighborList = new List<RoomSlotBehavior> ();

	public void ClearNeighborList(){
				neighborList.Clear ();
		}

	public void AddNeighborRoom(RoomSlotBehavior neighbor){
				neighborList.Add (neighbor);
		}

	public float baseHitPoints = 100;
	float hitPoints;

	public InventoryItem Item {
				get { return item; }
				set { 
			item = value;
			if(item != null)
				renderer.material = chooseMaterial(item.Function);
		}
		}

	private bool isSelected = false;

	public int UnigeID = 0;

	private Material chooseMaterial(RoomSlotBehavior.RoomFunction function){
		switch (function){
		case RoomSlotBehavior.RoomFunction.Cargo:
			return EditorControllerBehavior.getRef().roomMaterials[0];
		case RoomSlotBehavior.RoomFunction.Control:
			return EditorControllerBehavior.getRef().roomMaterials[1];
		case RoomSlotBehavior.RoomFunction.LifeSupport:
			return EditorControllerBehavior.getRef().roomMaterials[2];
		case RoomSlotBehavior.RoomFunction.Machine:
			return EditorControllerBehavior.getRef().roomMaterials[3];
		case RoomSlotBehavior.RoomFunction.MedicalBay:
			return EditorControllerBehavior.getRef().roomMaterials[4];
		case RoomSlotBehavior.RoomFunction.Sensor:
			return EditorControllerBehavior.getRef().roomMaterials[5];
		case RoomSlotBehavior.RoomFunction.Shield:
			return EditorControllerBehavior.getRef().roomMaterials[6];
		case RoomSlotBehavior.RoomFunction.Teleporter:
			return EditorControllerBehavior.getRef().roomMaterials[7];
		case RoomSlotBehavior.RoomFunction.WeaponControll:
			return EditorControllerBehavior.getRef().roomMaterials[8];
		default:
			return null;
		}
	}

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

	public void Load(RoomSlotData data){
		if (UnigeID != data.uniqueID)
						print ("Warning!!! Room data Object does not fit ID " + UnigeID);
		this.Item = data.item;
		}

	public void AddItem(InventoryItem item){
		this.Item = item;
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

[Serializable]
public class RoomSlotData{
	public int uniqueID;
	public InventoryItem item;
	public RoomSlotData(RoomSlotBehavior node){
				item = node.Item;
				uniqueID = node.UnigeID;
		}
}