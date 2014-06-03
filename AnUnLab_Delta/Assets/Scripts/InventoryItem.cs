using UnityEngine;
using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class InventoryItem{
	RoomSlotBehavior.RoomFunction function = RoomSlotBehavior.RoomFunction.None;
	string name;

	public Bonus [] bonusList;

	public RoomSlotBehavior.RoomFunction Function {
				get {
						return function;
				}
		}

	public string Name {
				get {
						return name;
				}
		}

	public InventoryItem(RoomSlotBehavior.RoomFunction function, string name){
		this.function = function;
		this.name = name;
	}
}
