using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAim : MonoBehaviour {
	private bool rotating = false;
	private Vector3 rotatePos;
	public float rotatingSpeed = 0.5f;
	// Update is called once per frame
	void Update () {
		if (GameObjectManager.buildModeScript.enabled == false) {
			LookToClick ();
		}
	}

	void LookToClick() {
		if (Input.GetMouseButton (1)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				rotatePos = hit.point;
				rotating = true;
			}
		}
		if (rotating) {
			Quaternion rotationNeeded = Quaternion.FromToRotation (transform.position, rotatePos);
			Quaternion.RotateTowards (transform.rotation, rotationNeeded, rotatingSpeed);
			if (transform.rotation.Equals(rotationNeeded))
				rotating = false;
		}
	}
}
