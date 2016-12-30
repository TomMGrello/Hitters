using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledSurroundingRigidbodies : MonoBehaviour {
	private int colCount = 0;
	public float forceThreshold = 50f;

	private Rigidbody thisRB;
	// Update is called once per frame

	void Start() {
		thisRB = GetComponent<Rigidbody> ();
	}

	void EnableRB(GameObject obj) {
		Rigidbody rb = obj.GetComponent<Rigidbody> ();
		rb.constraints = RigidbodyConstraints.None;
		rb.useGravity = true;
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Movable" && other.gameObject.layer != 8 && !(other.gameObject.Equals(GetComponentInChildren<Transform>().gameObject))) {
			if(thisRB.mass*thisRB.velocity.magnitude > forceThreshold)
				EnableRB (other.gameObject);
		}
	}
}
