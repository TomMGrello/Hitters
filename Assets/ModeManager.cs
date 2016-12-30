using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour {
	public KeyCode buildModeKey = KeyCode.B;
	public KeyCode playModeKey = KeyCode.G;
	// Use this for initialization
	void Start () {
		GameObjectManager.buildModeScript.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (buildModeKey))
			BuildMode ();
		if (Input.GetKeyDown (playModeKey))
			GameMode();
	}

	void BuildMode() {
		GameObjectManager.buildModeScript.SetEnabled ();
		GameObjectManager.player.SetActive (false);
		Camera.main.GetComponent<SimpleSmoothMouseLook> ().enabled = true;
		Camera.main.GetComponent<GhostFreeRoamCamera> ().enabled = true;
		Camera.main.GetComponent<SmoothFollowCSharp> ().enabled = false;
	}

	void GameMode() {
		GameObjectManager.buildModeScript.SetDisabled ();
		GameObjectManager.player.SetActive (true);
		Camera.main.GetComponent<SimpleSmoothMouseLook> ().enabled = false;
		Camera.main.GetComponent<GhostFreeRoamCamera> ().enabled = false;
		Camera.main.GetComponent<SmoothFollowCSharp> ().enabled = true;
	}
}
