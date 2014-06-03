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

		InventoryItem item1 = new InventoryItem (RoomSlotBehavior.RoomFunction.Machine, "Fastengine");
		Bonus fastEngineBonus = new Bonus ();
		fastEngineBonus.bonusOperator = Bonus.BonusOperator.Mult;
		fastEngineBonus.bonusScope = Bonus.BonusScope.Ship;
		fastEngineBonus.bonusType = Bonus.BonusType.MainThrust;
		fastEngineBonus.description = "Increases maximum Speed by 5% + 1% for every neigbor of the same type";
		fastEngineBonus.name = "Max Speed Bonus";
		fastEngineBonus.floatValue = 5;
		fastEngineBonus.neighborBonus = 1;
		item1.bonusList = new Bonus[1];
		item1.bonusList [0] = fastEngineBonus;
		itemList.Add(item1);

		InventoryItem item2 = new InventoryItem (RoomSlotBehavior.RoomFunction.Machine, "Maneuverengine");
		Bonus accEngineBonus = new Bonus ();
		accEngineBonus.bonusOperator = Bonus.BonusOperator.Mult;
		accEngineBonus.bonusScope = Bonus.BonusScope.Ship;
		accEngineBonus.bonusType = Bonus.BonusType.ManeuverThrust;
		accEngineBonus.description = "Increases maneuver thrust by 5% + 1% for every neigbor of the same type";
		accEngineBonus.name = "Maneuver Bonus";
		accEngineBonus.floatValue = 5;
		accEngineBonus.neighborBonus = 1;
		item2.bonusList = new Bonus[1];
		item2.bonusList [0] = accEngineBonus;
		itemList.Add(item2);

		InventoryItem item3 = new InventoryItem (RoomSlotBehavior.RoomFunction.Machine, "Weaponcontroll");
		Bonus weaponBonus = new Bonus ();
		weaponBonus.bonusOperator = Bonus.BonusOperator.Mult;
		weaponBonus.bonusScope = Bonus.BonusScope.AllWeapons;
		weaponBonus.bonusType = Bonus.BonusType.ManeuverThrust;
		weaponBonus.description = "Increases weapon damage by 5% + 1% for every neigbor of the same type";
		weaponBonus.name = "Damage Bonus";
		weaponBonus.floatValue = 5;
		weaponBonus.neighborBonus = 1;
		item3.bonusList = new Bonus[1];
		item3.bonusList [0] = weaponBonus;
		itemList.Add(item3);

		InventoryItem item4 = new InventoryItem (RoomSlotBehavior.RoomFunction.Machine, "Shieldgenerator Alpha");
		Bonus shieldBonus = new Bonus ();
		shieldBonus.bonusOperator = Bonus.BonusOperator.Mult;
		shieldBonus.bonusScope = Bonus.BonusScope.Ship;
		shieldBonus.bonusType = Bonus.BonusType.ShieldCapacity;
		shieldBonus.description = "Increases shield capacity by 5% + 1% for every neigbor of the same type";
		shieldBonus.name = "Capacity Bonus";
		shieldBonus.floatValue = 5;
		shieldBonus.neighborBonus = 1;
		item4.bonusList = new Bonus[1];
		item4.bonusList [0] = shieldBonus;
		itemList.Add(item4);

		InventoryItem item5 = new InventoryItem (RoomSlotBehavior.RoomFunction.Machine, "Shieldgenerator Beta");
		Bonus rechargeBonus = new Bonus ();
		rechargeBonus.bonusOperator = Bonus.BonusOperator.Mult;
		rechargeBonus.bonusScope = Bonus.BonusScope.Ship;
		rechargeBonus.bonusType = Bonus.BonusType.ShieldRechargeRate;
		rechargeBonus.description = "Increases shield recharge rate by 5% + 1% for every neigbor of the same type";
		rechargeBonus.name = "Recharge Bonus";
		rechargeBonus.floatValue = 5;
		rechargeBonus.neighborBonus = 1;
		item5.bonusList = new Bonus[1];
		item5.bonusList [0] = rechargeBonus;
		itemList.Add(item5);

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
