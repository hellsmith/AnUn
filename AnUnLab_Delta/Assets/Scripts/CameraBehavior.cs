using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {
	
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public float camSpeed = 10f;
	float zoom = 1;
	public float Zoom {
				get { return zoom; }
		}
	public float camDistance = 100;
	public float camZoomRate = 0.1f;
	
	public float minimumX = -360F;
	public float maximumX = 360F;
	
	public float minimumY = -60F;
	public float maximumY = 60F;

	Vector3 camFocus = new Vector3(0,0,0);

	bool focused = false;

	private void translateCam(Vector3 direction){
				focused = false;
				transform.parent.parent.Translate (transform.parent.parent.localRotation * (camSpeed * zoom * Time.deltaTime * direction));
		}

	private void zoomCam(float delta){
				zoom = zoom + zoom * delta;
				transform.localPosition = new Vector3 (0, 0, -camDistance * zoom);
		}

	void Update ()
	{
		if(focused)
			if (ShipControll.getRef ().SelectedShip != null)
				camFocus = ShipControll.getRef ().SelectedShip.transform.position;


		if (Input.GetKey(KeyCode.W)){
			translateCam(Vector3.forward);
		} else if (Input.GetKey(KeyCode.S)){
			translateCam(Vector3.back);
		}
		if (Input.GetKey(KeyCode.A)){
			translateCam(Vector3.left);
		} else if (Input.GetKey(KeyCode.D)){
			translateCam(Vector3.right);
		} 
		if (Input.GetKey(KeyCode.Q)){
			translateCam(Vector3.down);
		} else if (Input.GetKey(KeyCode.E)){
			translateCam(Vector3.up);
		}

		if( Input.GetAxis("Mouse ScrollWheel") > 0)
				zoomCam (-camZoomRate);
		else if( Input.GetAxis("Mouse ScrollWheel") < 0)
			zoomCam (camZoomRate);

		this.transform.parent.parent.position = camFocus;
		if (Input.GetMouseButton(1)) {
			if (axes == RotationAxes.MouseXAndY) {
				this.transform.parent.Rotate(Input.GetAxis ("Mouse Y") * -sensitivityY * Time.deltaTime,0,0);
				this.transform.parent.parent.Rotate(0,Input.GetAxis ("Mouse X") * sensitivityX * Time.deltaTime,0);
			} else if (axes == RotationAxes.MouseX)
				this.transform.parent.parent.Rotate(0,Input.GetAxis ("Mouse X") * sensitivityX * Time.deltaTime,0);
			else 
				this.transform.parent.Rotate(Input.GetAxis ("Mouse Y") * sensitivityY * Time.deltaTime,0,0);

			Screen.lockCursor = true;
		} else if (Input.GetMouseButtonUp(1)) {
			Screen.lockCursor = false;
		}
	}
	void Start ()
	{
		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;
	}
}
