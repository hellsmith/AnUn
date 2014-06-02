using UnityEngine;
using System.Collections;

public class CannonBehavior : MonoBehaviour {

	public Vector3 barrelPosition = new Vector3(0,1,2);
	public GameObject barrel;
	public GameObject projectile;
	public GameObject nozzleFire;

	public Vector3 nozzleLocation;
	public float reloadTime = 0.8f;
	public float projectileSpeed = 5f;
	private float shotTimer = 0;


	// Use this for initialization
	void Start () {
	
	}

	bool targetingOn = true;
	public Vector3 targetDestination = new Vector3(100,100,100);

	public Vector3 angularRotationSpeed = new Vector3(10,10,1);

	private void fireShot(){
		if (shotTimer > reloadTime) {
			Quaternion projectileDirection = barrel.transform.rotation;
			Vector3 origin = barrel.transform.position + projectileDirection * nozzleLocation;
			//GameObject bullet = (GameObject) Instantiate(projectile,origin,projectileDirection);
			GameObject bullet = Network.Instantiate(projectile,origin,projectileDirection,0) as GameObject;
			bullet.rigidbody.velocity = projectileDirection * Vector3.forward * projectileSpeed;
			shotTimer = 0;
				}
		}
	
	// Update is called once per frame
	void Update () {
		shotTimer += Time.deltaTime;
		if(targetingOn) {
			Vector3 toTarget = targetDestination - transform.position;
			float distance = toTarget.magnitude;
			toTarget = toTarget.normalized;
			Vector3 turretFront = transform.rotation * Vector3.forward;
			Vector3 barrelFront = barrel.transform.rotation * Vector3.forward;
			float barrelScalar = Vector3.Dot(barrelFront,toTarget);
			float turretScalar = Vector3.Dot(turretFront,toTarget);
			Vector3 localRight = transform.rotation * Vector3.right;
			if(barrelScalar < 0.97){
				Vector3 barrelUp = barrel.transform.rotation * Vector3.up;

				float tiltFactor = -(toTarget.x * localRight.x + toTarget.y * localRight.y + toTarget.z * localRight.z) /
					(localRight.x * localRight.x + localRight.y * localRight.y + localRight.z * localRight.z);

				Vector3 projectedTilt = (toTarget + tiltFactor * localRight).normalized;

				//hoch runter
				float tiltScalar = Vector3.Dot(barrelUp,projectedTilt);

				if(Mathf.Abs(tiltScalar) > 0.01){
					barrel.transform.Rotate(angularRotationSpeed.x * Time.deltaTime * (-Mathf.Sign(tiltScalar)),0,0);
				}
			}
			if(turretScalar < 0.97){
				Vector3 localUp = transform.rotation * Vector3.up;
				float yawFactor = -(toTarget.x * localUp.x + toTarget.y * localUp.y + toTarget.z * localUp.z) /
					(localUp.x * localUp.x + localUp.y * localUp.y + localUp.z * localUp.z);

				Vector3 projectedYaw = (toTarget + yawFactor * localUp).normalized;

				//links rechts
				float yawScalar = projectedYaw.x * localRight.x + projectedYaw.y * localRight.y + projectedYaw.z * localRight.z;

				if(Mathf.Abs(yawScalar) > 0.01){
					transform.Rotate(0,angularRotationSpeed.y * Time.deltaTime * Mathf.Sign(yawScalar),0);
				}

			}
		}

		if (Input.GetKey (KeyCode.Space))
						fireShot ();
	}
}
