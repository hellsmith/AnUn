using UnityEngine;
using System.Collections;

public class MovementTargetBehavior : MonoBehaviour {

	public bool moveModeActive = false;

	// Use this for initialization
	void Start () {
		renderer.enabled = false;
	}

	private float heightShift = 0;

	void OnPreRender() {
		GL.wireframe = true;
	}
	void OnPostRender() {
		GL.wireframe = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(1))
			renderer.enabled = false;
		else
			renderer.enabled = moveModeActive;
		if (GameControll.getRef ().getSelectedShip () != null) {
						if (Input.GetKeyDown (KeyCode.M)) {
								moveModeActive = !moveModeActive;
								renderer.enabled = moveModeActive;
								heightShift = 0;
						}
						if (moveModeActive) {
				float zoom = Camera.main.GetComponent<CameraBehavior>().Zoom;
				this.transform.localScale = new Vector3(zoom,zoom,zoom);
								Ray lookingDir = Camera.main.ViewportPointToRay (
				new Vector3 (Input.mousePosition.x / (float)Camera.main.pixelWidth,
			            Input.mousePosition.y / (float)Camera.main.pixelHeight,
			            0));
								if (Input.GetKey (KeyCode.LeftShift)) {
										Vector3 camDir = Camera.main.transform.rotation * Vector3.forward;
										float heightFactor = (Vector3.Dot (this.transform.position - lookingDir.origin, camDir)) / 
												(Vector3.Dot (lookingDir.direction, camDir));
										Vector3 targetPos = new Vector3 (this.transform.position.x, 
				                                lookingDir.origin.y + heightFactor * lookingDir.direction.y, 
				                                this.transform.position.z);
										this.transform.position = targetPos;
										heightShift = targetPos.y;
								} else {

										float distanceFactor = (Camera.main.transform.parent.parent.position.y + heightShift - lookingDir.origin.y) / lookingDir.direction.y;
										Vector3 targetLocation = lookingDir.origin + (lookingDir.direction * distanceFactor);
										this.transform.position = targetLocation;

										if (Input.GetMouseButton (0)) {
												GameControll.getRef ().getSelectedShip ().GetComponent<ShipBehavior> ().setTargetDestination (targetLocation);
												moveModeActive = false;
										}
								}
						}
				} else
						moveModeActive = false;
	}
}
