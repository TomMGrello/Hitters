using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterContactAndTime : MonoBehaviour {
	public float time = 10f;
	public GameObject hit;
	private float counter = 0.0f;
	private bool shouldCountDown = false;
	private GameObject instantiatedHit;
	public GameObject parentCannon;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if (shouldCountDown) {
			if (counter >= time) {
				Destroy (gameObject);
				Destroy (instantiatedHit);
			}
			counter += Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.Equals (parentCannon))
			return;
		Debug.Log ("Trajectory hit");
		if (!shouldCountDown) {
			shouldCountDown = true;
			instantiatedHit = (GameObject)Instantiate (hit, transform.position, Quaternion.identity);
		}
	}
}
