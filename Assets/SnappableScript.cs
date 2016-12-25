using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnappableScript : MonoBehaviour {
	public bool snappable = false;
	public Vector3 snappablePosition;
	public Quaternion snappableRotation;
	public GameObject snapObject;
	private bool snapMode = false;
	public KeyCode snapModeKey = KeyCode.LeftShift;

	void Update() {
		if (Input.GetKey (snapModeKey))
			snapMode = false;
		else
			snapMode = true;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Movable" && other.gameObject.layer != 8) {
			if (snappable) {
				if(Vector3.Distance(transform.position,other.transform.position) > Vector3.Distance(transform.position,snappablePosition))
					return;
			}
			snappable = true;
			snappablePosition = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y + other.gameObject.transform.localScale.y,other.gameObject.transform.position.z);
			snappableRotation = other.transform.rotation;
			snapObject = other.gameObject;
		}
	}

	public bool GetSnappable() {
		return snapMode && snappable;
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Movable" && other.gameObject.layer != 8 && !(other.transform.position.Equals(snappablePosition))) 
			snappable = false;
	}
}
