using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class Bonus {
	public enum BonusType{
		OxygenRefreshRate,
		FireRate,
		Damage,
		HitPoints,
		Cargospace,
		ShieldCapacity,
		ShieldRechargeRate,
		ManeuverThrust,
		MainThrust,
		ReactorCapacity,
		ReactorRechargeRate,
		WeaponTurnRate
	}

	public enum NeighborBonusType{
		None,
		NextToSame,
		NextToMedical,
		NextToMachine,
		NextToCargo,
		NextToControll,
		NextToWeapon,
		NextToShield,
		NextToTeleporter,
		NextToLife,
		NextToSensor
	}
	
	public enum BonusScope{
		OnlyThisRoom,
		EveryRoom,
		AllWeapons,
		BeamWeapons,
		ProjectileWeapons,
		MissileWeapons,
		Ship,
		ThisAndNeighbors,
		OnlyNeighbors
	}

	public enum BonusOperator{
		Mult,
		Add
	}

	public int priority = 0;
	public string name;
	public string description;
	public BonusType bonusType;
	public NeighborBonusType neighborType;
	public BonusScope bonusScope;
	public BonusOperator bonusOperator;
	public string textValue;
	public float floatValue;
	public float neighborBonus;
}

