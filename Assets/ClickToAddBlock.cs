using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToAddBlock : MonoBehaviour {
	public GameObject selectedObjectGhost;
	private GameObject instantiatedGhost;
	public GameObject cursorInvis;
	private GameObject instantiatedCursorInvis;
	public GameObject placingObject;
	public float offset = 1.0001f;
	public float correctionRange = 2f;

	private Stack<Vector3> buildingBox;
	private Stack<GameObject> boxCursors;
	private Vector3 firstPos;
	private int boxPointCount;
	// Use this for initialization
	void Start () {
		instantiatedGhost = (GameObject)Instantiate (selectedObjectGhost);
		instantiatedCursorInvis = (GameObject)Instantiate (cursorInvis);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftControl)) {
			if (Input.GetMouseButtonDown (1)) {

			}
		}
		if (Input.GetMouseButtonUp (1)) 
			BuildObject ();
		GhostFollow ();
	}

	public void SetEnabled() {
		enabled = true;
		instantiatedGhost.SetActive (true);
		instantiatedCursorInvis.SetActive (true);
	}

	public void SetDisabled() {
		enabled = false;
		instantiatedGhost.SetActive (false);
		instantiatedCursorInvis.SetActive (false);
	}



	void BuildObject() {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			if (GameObjectManager.placementCheck.isPlaceable()) {
				Vector3 placePos;
				Quaternion rot;
				if (GameObjectManager.buildSnap.GetSnappable()) {
					placePos = GameObjectManager.buildSnap.snappablePosition;
					rot = GameObjectManager.buildSnap.snappableRotation;
					GameObjectManager.buildSnap.snapObject.GetComponent<SpawnedPositionCorrection> ().canPlaceOnTop = false;
				} else {
					placePos = new Vector3 (hit.point.x, hit.point.y + placingObject.transform.localScale.y, hit.point.z);
					rot = Quaternion.identity;
				}
				Instantiate (placingObject, placePos, rot);
			}
		}
	}

	/*Vector3 GetFinalPlacement(Vector3 placePos) {
		Collider[] cols = Physics.OverlapSphere (instantiatedGhost.transform.position, correctionRange);
		Collider closest = null;
		foreach (Collider current in cols) {
			if (current.gameObject.tag == "Movable" && current.gameObject.layer != 8 && current.gameObject.GetComponent<SpawnedPositionCorrection>().canPlaceOnTop) {
				if (closest == null)
					closest = current;
				else if (Vector3.Distance (current.transform.position, transform.position) < Vector3.Distance (closest.transform.position, transform.position))
					closest = current;
			}
		}
		if(closest == null || closest.gameObject.layer == 8) //is it a floor?
			return placePos;
		Vector3 finalPos = new Vector3 (closest.transform.position.x, closest.transform.position.y + (placingObject.transform.localScale.y), closest.transform.position.z);
		closest.gameObject.GetComponent<SpawnedPositionCorrection> ().canPlaceOnTop = false;
		return finalPos;
	}*/

	void GhostFollow(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			
			//instantiatedGhost.transform.position = hit.point;
			float newPosY = hit.point.y + instantiatedGhost.transform.localScale.y/2;
			Vector3 pos = new Vector3 (hit.point.x, newPosY, hit.point.z);
			instantiatedCursorInvis.transform.position = pos;
			if (GameObjectManager.buildSnap.GetSnappable()) {
				instantiatedGhost.transform.position = GameObjectManager.buildSnap.snappablePosition;
				instantiatedGhost.transform.rotation = GameObjectManager.buildSnap.snappableRotation;
			} else {
				instantiatedGhost.transform.position = pos;
				instantiatedGhost.transform.rotation = Quaternion.identity;
			}
		}
	}
}
