using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToAddBlock : MonoBehaviour
{
    public GameObject[] ghosts;
    private GameObject instantiatedGhost;
    public GameObject cursorInvis;
    private GameObject instantiatedCursorInvis;
    public GameObject[] placingObjects;
    public float offset = 1.0001f;
    public float correctionRange = 2f;
	private int selection = 0;

    private Stack<Vector3> buildingBox;
    private Vector3 firstPos;
    private int boxPointCount;
    // Use this for initialization
    void Start()
    {
		instantiatedGhost = (GameObject)Instantiate(ghosts[selection]);
        instantiatedCursorInvis = (GameObject)Instantiate(cursorInvis);
    }

    // Update is called once per frame
    void Update() {          
		CheckForSelectionChange ();
        GhostFollow();
    }

	void CheckForSelectionChange() {
		float result = Input.GetAxis ("Mouse ScrollWheel");
		if (result != 0)
			ChangeSelection (result);
	}

	void ChangeSelection(float result) {
		if (result < 0) 
			selection = ((selection + 1) + ghosts.Length) % ghosts.Length;
		else
			selection = ((selection - 1) + ghosts.Length) % ghosts.Length;
		Destroy (instantiatedGhost.gameObject);
		GameObjectManager.placementCheck = ghosts [selection].GetComponent<PlacementCheck> ();
		instantiatedGhost = (GameObject)Instantiate (ghosts [selection]);
		
	}

    public void SetEnabled()
    {
        enabled = true;
        instantiatedGhost.SetActive(true);
        instantiatedCursorInvis.SetActive(true);
    }

    public void SetDisabled()
    {
        enabled = false;
        instantiatedGhost.SetActive(false);
        instantiatedCursorInvis.SetActive(false);
    }

	void BuildObject(Vector3 pos, Quaternion rot)
    {
        if (GameObjectManager.placementCheck.isPlaceable())
			Instantiate(placingObjects[selection], pos, rot);
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

    void GhostFollow()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
			Vector3 pos;
			Quaternion rot;

			if (hit.collider.tag == "SnapPoint") {
				pos = hit.collider.transform.position;
				rot = hit.collider.transform.rotation;
			} else {
				float newPosY = hit.point.y;
				rot = Quaternion.identity;
				pos = new Vector3 (hit.point.x, newPosY, hit.point.z);
			}

            instantiatedCursorInvis.transform.position = pos;
			instantiatedGhost.transform.position = pos;
			instantiatedGhost.transform.rotation = rot;

			if (Input.GetMouseButtonDown(1))
				BuildObject(instantiatedGhost.transform.position,instantiatedGhost.transform.rotation);
           // }
        }
    }
}