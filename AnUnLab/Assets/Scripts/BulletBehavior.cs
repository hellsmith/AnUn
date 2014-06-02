using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {


	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info){
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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
