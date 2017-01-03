using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfFloating : MonoBehaviour {
	public int colCount = 0;
	private Rigidbody rb;
	public bool justStarted = true;
	public bool floating = true;

	void Start() {
		rb = transform.parent.gameObject.GetComponent<Rigidbody> ();
	}
	// Update is called once per frame
	void Update () {
		if ( !justStarted && floating) {
			rb.constraints = RigidbodyConstraints.None;
			rb.useGravity = true;

		}
	}

	/*void OnTriggerEnter(Collider other) {
		if (Valid (other)) {
			ToggleJustStarted ();
			colCount++;
		}
	}*/

	void OnTriggerStay(Collider other) {
		if (Valid (other) && floating)
			floating = false;
	}

	void OnTriggerExit(Collider other) {
		if (Valid (other)) {
			floating = true;
		}
	}

	void ToggleJustStarted() {
		if (justStarted)
			justStarted = false;
	}

	bool Valid(Collider other) {
		return other.tag == "Movable" && other.gameObject.layer != 8;
	}
}
