using UnityEngine;
using System.Collections;

public class InventoryItem {
	RoomSlotBehavior.RoomFunction function = RoomSlotBehavior.RoomFunction.None;
	string name;

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
