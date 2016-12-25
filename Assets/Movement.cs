using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float movementSpeed = 1f;
	// Update is called once per frame
	void Start() {
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () {
		transform.Translate ((Input.GetAxis ("Vertical") * transform.forward + Input.GetAxis ("Horizontal") * transform.right) * movementSpeed);
			
	}
}
