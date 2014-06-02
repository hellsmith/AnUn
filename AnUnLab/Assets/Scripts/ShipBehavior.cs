using UnityEngine;
using System.Collections;

public class ShipBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	Vector3 targetDestination = new Vector3(50,50,100);
	bool destinationActive = false;
	public Vector3 angularRotationSpeed = new Vector3(1,1,1);
	public float maxAcceleration = 1f;
	public float maxDecceleration = 0.6f;
	public float maxShift = 0.3f;

	public void setTargetDestination(Vector3 pos){
		networkView.RPC("TellTargetDestination",RPCMode.All, pos);
		}

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		Quaternion 	_syncDirection 	= Quaternion.identity;
		Vector3 	_syncPosition	= Vector3.zero;
		Vector3 	_syncVelocity 	= Vector3.zero;

		if (stream.isWriting)
		{

			_syncDirection = this.transform.rotation;
			_syncPosition = this.transform.position;
			_syncVelocity = this.rigidbody.velocity;

			stream.Serialize(ref _syncDirection);	
			stream.Serialize(ref _syncPosition);
			stream.Serialize(ref _syncVelocity);
		}
		else
		{
			stream.Serialize(ref _syncDirection);
			stream.Serialize(ref _syncPosition);
			stream.Serialize(ref _syncVelocity);
			if(Quaternion.Angle(this.transform.rotation,_syncDirection) > 10   ){
				this.gameObject.transform.rotation = Quaternion.Lerp(this.transform.rotation, _syncDirection,5 );
			}
			if( Vector3.Distance(this.transform.position,_syncPosition) > 10 ){
				this.gameObject.transform.position = Vector3.Lerp(this.transform.position, _syncPosition,5);
			}
			if(Vector3.Distance(this.rigidbody.velocity,_syncVelocity)> 10){
				this.rigidbody.velocity = Vector3.Lerp(this.rigidbody.velocity, _syncVelocity , 5);
			}

		}
	}


	// Update is called once per frame
	void Update () {

	}


	// LateUpdate is called once per frame
	void LateUpdate () {
		if(destinationActive) {
			Vector3 toTarget = targetDestination - transform.position;
			float distance = toTarget.magnitude;
			toTarget = toTarget.normalized;
			Vector3 localFront = transform.localRotation * Vector3.forward;
			float angleScalar = localFront.x * toTarget.x + localFront.y * toTarget.y + localFront.z * toTarget.z;
			if(angleScalar < 0.97){

				Vector3 localUp = transform.localRotation * Vector3.up;
				Vector3 localRight = transform.localRotation * Vector3.right;

				float yawFactor = -(toTarget.x * localUp.x + toTarget.y * localUp.y + toTarget.z * localUp.z) /
					(localUp.x * localUp.x + localUp.y * localUp.y + localUp.z * localUp.z);

				float tiltFactor = -(toTarget.x * localRight.x + toTarget.y * localRight.y + toTarget.z * localRight.z) /
					(localRight.x * localRight.x + localRight.y * localRight.y + localRight.z * localRight.z);

				Vector3 projectedYaw = (toTarget + yawFactor * localUp).normalized;
				Vector3 projectedTilt = (toTarget + tiltFactor * localRight).normalized;

				//links rechts
				float yawScalar = projectedYaw.x * localRight.x + projectedYaw.y * localRight.y + projectedYaw.z * localRight.z;
				//hoch runter
				float tiltScalar = projectedTilt.x * localUp.x + projectedTilt.y * localUp.y + projectedTilt.z * localUp.z;

				if(Mathf.Abs(yawScalar) > 0.01){
					rigidbody.AddRelativeTorque(new Vector3(0,angularRotationSpeed.y * Mathf.Sign(yawScalar),0));
				}
				if(Mathf.Abs(tiltScalar) > 0.01){
					rigidbody.AddRelativeTorque(new Vector3(angularRotationSpeed.x * (-Mathf.Sign(tiltScalar)),0,0));
				}
			}



			if(distance > 10){
				if(angleScalar < 0.95)
					this.rigidbody.AddForce(toTarget * maxShift);
				else
					this.rigidbody.AddForce(localFront * maxAcceleration);
			} else {
				destinationActive = false;
			}
		}
	}

	[RPC]
	void TellTargetDestination (Vector3 targetdestination)
	{
		targetDestination = targetdestination;
		destinationActive = true;
		Debug.Log ("Setzte neuen Kurs");
	}
}
