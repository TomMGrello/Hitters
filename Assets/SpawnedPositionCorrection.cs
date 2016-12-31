using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedPositionCorrection : MonoBehaviour {
	public bool canPlaceOnTop = true;

	/*void OnTriggerStay(Collider other) {
		if (canPlaceOnTop && other.gameObject.layer != 8 && other.gameObject.tag == "Movable")
			canPlaceOnTop = false;
	}*/

	void OnTriggerExit(Collider other) {
	/*	if (!canPlaceOnTop && other.gameObject.tag == "Movable")
			canPlaceOnTop = true;*/
	}
}
