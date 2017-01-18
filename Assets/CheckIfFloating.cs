using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfFloating : MonoBehaviour {
	public int colCount = 0;
	private Rigidbody rb;
	public bool justStarted = true;
	public bool floating = true;
	public GameObject[] colliders;
	public bool grounded = false;
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
		if (other.gameObject.layer == 8 && !grounded)
			grounded = true;
	}

	void OnTriggerExit(Collider other) {
		if (Valid (other)) {
			if (!isGrounded ()) {
				floating = true;
			}
		}
	}

	public bool isGrounded() {
		if (grounded)
			return true;
		foreach (GameObject current in colliders) {
			FloatCheck fc = current.GetComponent<FloatCheck> ();
			if (fc.collidingObject.GetComponent<CheckIfFloating> ().isGrounded ())
				return true;
		}
		return false;
	}

	void ToggleJustStarted() {
		if (justStarted)
			justStarted = false;
	}

	bool Valid(Collider other) {
		return other.tag == "Movable" && other.gameObject.layer != 8;
	}
}
