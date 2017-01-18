using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatCheck : MonoBehaviour {
	public bool isColliding = false;
	public GameObject collidingObject;


	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Movable" && other.gameObject.layer != 8) {
			isColliding = false;
		}
	}

	void OnTriggerStay(Collider other) {
		if (!isColliding && collidingObject == null && other.gameObject.tag == "Movable" && other.gameObject.layer != 8) {
			isColliding = true;
			collidingObject = other.gameObject;
		}
	}
}
