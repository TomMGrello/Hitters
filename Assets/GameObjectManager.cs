using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour {
	public static GameObject buildCursor;
	public static GameObject buildGhost;
	public static SnappableScript buildSnap;
	public static PlacementCheck placementCheck;
	public static ClickToAddBlock buildModeScript;
	public static KeyCode useKey = KeyCode.E;
	public static GameObject player;
	public static Transform cameraTargetPlayer;
	private bool check = true;
	// Use this for initialization
	void Update () {
		if (check && (buildSnap == null || buildGhost == null || buildCursor == null || placementCheck == null || buildModeScript == null || player == null || cameraTargetPlayer == null)) {
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
			if (player == null)
				player = GameObject.FindGameObjectWithTag ("Player");
			if (cameraTargetPlayer == null && player != null) {
				cameraTargetPlayer = GameObject.FindGameObjectWithTag ("CameraTargetPlayer").transform;
				player.SetActive (false);
			}
		} else
			check = false;
	}

}
