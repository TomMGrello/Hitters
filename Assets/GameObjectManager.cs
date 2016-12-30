using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour {
	public static GameObject buildCursor;
	public static GameObject buildGhost;
	public static SnappableScript buildSnap;
	public static PlacementCheck placementCheck;
	public static ClickToAddBlock buildModeScript;
	private bool check = true;
	// Use this for initialization
	void Update () {
		if (check && (buildSnap == null || buildGhost == null || buildCursor == null || placementCheck == null || buildModeScript == null)) {
			if (buildCursor == null)
				buildCursor = GameObject.FindGameObjectWithTag ("Cursor");
			if (buildGhost == null)
				buildGhost = GameObject.FindGameObjectWithTag ("Ghost");
			if (buildSnap == null)
				buildSnap = buildCursor.GetComponent<SnappableScript> ();
			if (placementCheck == null)
				placementCheck = buildGhost.GetComponent<PlacementCheck> ();
			if (buildModeScript == null)
				buildModeScript = Camera.main.GetComponent<ClickToAddBlock> ();
		} else
			check = false;
	}

}
