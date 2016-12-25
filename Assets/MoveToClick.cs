using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClick : MonoBehaviour {
	public float accel = 200f;
	private Vector3 pos;
	private bool shouldMove = false;
	// Update is called once per frame

	void Start() {
		pos = transform.position;
	}

	void Update () {
		if (Input.GetMouseButton (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.tag == "Movable") {
					pos = hit.point;
					shouldMove = true;
				}
			}
		}
		MoveToPos ();
	}

	void MoveToPos() {
		if (Vector3.Distance (transform.position, pos) > 1 && shouldMove) {
			GetComponent<Rigidbody> ().AddForce ((pos - transform.position).normalized * accel);
		} else {
			shouldMove = false;
		}
	}
}
