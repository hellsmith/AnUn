using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	private static Inventory reference;

	public static Inventory getRef (){
				return reference;
		}

	public List<InventoryItem> itemList = new List<InventoryItem>();

	// Use this for initialization
	void Start () {
		reference = this;

		// should load list here

		itemList.Add(new InventoryItem(RoomSlotBehavior.RoomFunction.Machine, "Machineroom"));
		itemList.Add(new InventoryItem(RoomSlotBehavior.RoomFunction.Machine, "Machine Mk2"));
		itemList.Add(new InventoryItem(RoomSlotBehavior.RoomFunction.Control, "Controlroom"));
		itemList.Add(new InventoryItem(RoomSlotBehavior.RoomFunction.LifeSupport, "Lifesupport"));
		itemList.Add(new InventoryItem(RoomSlotBehavior.RoomFunction.Cargo, "Cargoroom"));
		itemList.Add(new InventoryItem(RoomSlotBehavior.RoomFunction.MedicalBay, "Medical Bay"));
		itemList.Add(new InventoryItem(RoomSlotBehavior.RoomFunction.Sensor, "Sensorroom"));
		itemList.Add(new InventoryItem(RoomSlotBehavior.RoomFunction.Shield, "Shieldgenerator"));
		itemList.Add(new InventoryItem(RoomSlotBehavior.RoomFunction.Teleporter, "Teleporter"));
		itemList.Add(new InventoryItem(RoomSlotBehavior.RoomFunction.WeaponControll, "Weaponcontrol"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
