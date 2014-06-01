using UnityEngine;
using System.Collections;

public class ForceFieldBehavior : MonoBehaviour {

	public float forceFieldPower = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other){
				Vector3 force = (other.transform.position - this.transform.position).normalized * forceFieldPower;
				other.rigidbody.AddForce (force);
		}
}
