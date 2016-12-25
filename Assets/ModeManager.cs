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
			GameObjectManager.buildModeScript.SetEnabled ();
		if (Input.GetKeyDown (playModeKey))
			GameObjectManager.buildModeScript.SetDisabled ();
	}
}
