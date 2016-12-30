using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfFloating : MonoBehaviour {
	public int colCount = 0;
	private Rigidbody rb;
	public bool justStarted = true;

	void Start() {
		rb = transform.parent.gameObject.GetComponent<Rigidbody> ();
	}
	// Update is called once per frame
	void Update () {
		if ( !justStarted && colCount <= 0) {
			rb.constraints = RigidbodyConstraints.None;
			rb.useGravity = true;

		}
	}

	void OnTriggerEnter(Collider other) {
		if (Valid (other)) {
			ToggleJustStarted ();
			colCount++;
		}
	}

	void OnTriggerExit(Collider other) {
		if (Valid (other)) {
			ToggleJustStarted ();
			colCount--;
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
