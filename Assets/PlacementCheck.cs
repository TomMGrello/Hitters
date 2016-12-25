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

	void OnTriggerEnter(Collider other) {
		if (shouldSet) {
			if (other.tag == "Movable" && GameObjectManager.buildSnap.GetSnappable() && other.gameObject.GetComponent<SpawnedPositionCorrection> ().canPlaceOnTop) {
				CanPlace ();
			} else {
				CannotPlace ();
			}
		}
	}

	void OnTriggerStay(Collider other) {
		if (canPlace && shouldSet && !(GameObjectManager.buildSnap.GetSnappable() && other.gameObject.GetComponent<SpawnedPositionCorrection> ().canPlaceOnTop)) {
			CannotPlace ();
		}
	}

	void CannotPlace() {
		GetComponent<MeshRenderer> ().material = cannotPlaceMat;
		canPlace = false;
		shouldSet = false;
		//Debug.Log ("Colliding with " + other.gameObject.ToString ());
	}

	void CanPlace(){
		GetComponent<MeshRenderer> ().material = canPlaceMat;
		canPlace = true;
		shouldSet = true;
	}

	void OnTriggerExit(Collider other) {
		if (!shouldSet) {
			CanPlace ();
		}
	}

	public bool isPlaceable() {
		return canPlace;
	}
}
