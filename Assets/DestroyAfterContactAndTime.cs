using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterContactAndTime : MonoBehaviour {
	public float time = 10f;
	private float counter = 0.0f;
	private bool shouldCountDown = false;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if (shouldCountDown) {
			if (counter >= time)
				Destroy (gameObject);
			counter += Time.deltaTime;
		}
	}

	void OnCollisionEnter(Collision other) {
		shouldCountDown = true;
	}
}
