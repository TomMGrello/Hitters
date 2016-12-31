using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementCheck : MonoBehaviour {

	private bool shouldSet = false;
	private bool canPlace = true;
	public Material cannotPlaceMat;
	public Material canPlaceMat;
	// Update is called once per frame

	void Start() {
		GetComponent<MeshRenderer> ().material = canPlaceMat;
	}

	void Update () {
		
	}

	void DebugCol(Collider other) {
		if (other.tag != "SnapPoint")
			Debug.Log ("Not a snap point: " + other.tag);
		if (other.tag != "Movable")
			Debug.Log ("Not moveable: " + other.tag);
		else {
			if (!(other.gameObject.GetComponent<SpawnedPositionCorrection> ().canPlaceOnTop))
				Debug.Log ("Cannot place on top");
		}
	}

	/*void OnTriggerEnter(Collider other) {
		if (shouldSet) {
			if (other.tag == "SnapPoint" || other.tag == "Movable" && other.gameObject.GetComponent<SpawnedPositionCorrection> ().canPlaceOnTop) {
				CanPlace ();
			} else {
				CannotPlace (other);
			}
		}
	}*/

	void OnTriggerStay(Collider other) {
		//if (canPlace && shouldSet && !(other.gameObject.GetComponent<SpawnedPositionCorrection> ().canPlaceOnTop)) {
		if (other.tag == "SnapPoint" || other.tag == "FloatCheck") {
			CanPlace ();
		} else
			CannotPlace (other);
		//}
	}

	void CannotPlace(Collider other) {
		GetComponent<MeshRenderer> ().material = cannotPlaceMat;
		canPlace = false;
		shouldSet = false;
		DebugCol (other);
		//Debug.Log ("Colliding with " + other.gameObject.ToString ());
	}

	void CanPlace(){
		GetComponent<MeshRenderer> ().material = canPlaceMat;
		canPlace = true;
		shouldSet = true;
	}

	void OnTriggerExit(Collider other) {
		//if (!shouldSet) {
			CanPlace ();
		//}
	}

	public bool isPlaceable() {
		return canPlace;
	}
}
