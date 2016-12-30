using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIScript : MonoBehaviour {
	public Texture2D crosshair;

	void OnGUI() {
		GUI.DrawTexture (new Rect ((Screen.width / 2)-25, (Screen.height / 2) - 50, 50, 50), crosshair);
	}
}
