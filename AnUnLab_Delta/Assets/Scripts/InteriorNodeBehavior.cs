using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

public class InteriorNodeBehavior : MonoBehaviour {

	public GameObject roomSlotPrefab;

	public List<RoomSlotBehavior> roomSlotList = new List<RoomSlotBehavior>();

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
		if (Input.GetKeyDown (KeyCode.K)) {
			Save ("ship.dat");
				}
		else if (Input.GetKeyDown (KeyCode.L)) {
			Load ("ship.dat");
		}
	}

	public void RecalculateNeighborBonus(){
		for (int i = 0; i < roomSlotList; i++) {
			for (int k = 0; k < roomSlotList; k++) {
				if((roomSlotList[i].transform.position - roomSlotList[k].transform.position).magnitude < 11){ // neighbors
					roomSlotList[i].AddNeighborRoom(roomSlotList[k]);
				}
			}
		}
	}

	public void RecalculateInteriorBoni(){
		for (int i = 0; i < roomSlotList; i++) {
				}

		}

	public void Save(string fileName){
		BinaryFormatter bf = new BinaryFormatter ();
		if (File.Exists (Application.absoluteURL + "/save/" + fileName)) 
						print ("exists");
		FileStream file = File.Open (Application.dataPath + "/save/" + fileName, FileMode.OpenOrCreate, FileAccess.Write);

		InteriorData data = new InteriorData (this);
		for (int i = 0; i < data.rooms.Length; i++) {
			data.rooms[i] = new RoomSlotData(roomSlotList[i]);
		}

		bf.Serialize (file, data);
		file.Close ();
		}

	public void Load(string fileName){
		if (File.Exists (Application.dataPath + "/save/" + fileName)) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.dataPath + "/save/" + fileName, FileMode.Open, FileAccess.Read);
			InteriorData data = (InteriorData) bf.Deserialize(file);
			file.Close();

			for (int i = 0; i < data.rooms.Length; i++) {
				roomSlotList[i].Load(data.rooms[i]);
			}
				}
	}
}

[Serializable]
public class InteriorData{
	public InteriorData(InteriorNodeBehavior node){
		rooms = new RoomSlotData[node.roomSlotList.Count];

		}

	public RoomSlotData[] rooms;
}