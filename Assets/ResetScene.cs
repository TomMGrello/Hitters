using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetScene : MonoBehaviour {
	public KeyCode key = KeyCode.R;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (key))
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
