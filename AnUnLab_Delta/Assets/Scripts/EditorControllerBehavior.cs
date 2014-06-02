using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EditorControllerBehavior : MonoBehaviour {

	public List<GameObject> spawnableList = new List<GameObject> ();

	public static GameObject shipToEdit;

	private List<Material> materialBackup = new List<Material>();



	public Material transparentMaterial;

	private Vector2 classSelectionPos = Vector2.zero;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnShip(){
		shipToEdit = (GameObject) Instantiate (shipToEdit);

		Transform node = shipToEdit.transform.Find ("ExteriorNode");
		if (node != null) {
						Renderer [] renderers = node.GetComponentsInChildren<Renderer> ();
						foreach (Renderer rend in renderers) {
								/*for (int i = 0; i < rend.materials.Length; i++) {
										materialBackup.Add (rend.materials [i]);
										rend.materials [i] = transparentMaterial;
								}*/
				rend.material = transparentMaterial;
						}
				}
		}

	void OnGUI(){
		if (shipToEdit == null) {
			GUI.Box(new Rect(10,10,Screen.width - 20, Screen.height - 20),"Choose a ship class");
			classSelectionPos = GUI.BeginScrollView (new Rect (20, 55, Screen.width - 40, Screen.height - 75), classSelectionPos, new Rect (0, 0, Screen.width - 40, spawnableList.Count * 40));
			for(int i = 0; i < spawnableList.Count; i++){
				if(GUI.Button(new Rect(5,i * 44 + 5, Screen.width - 50, 40), spawnableList[i].GetComponent<ShipBehavior>().ShipClass)){
					shipToEdit = spawnableList[i];
					SpawnShip();
				}
			}
			GUI.EndScrollView();
		} else {
		}
	}
}
