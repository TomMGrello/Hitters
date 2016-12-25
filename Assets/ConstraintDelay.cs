using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstraintDelay : MonoBehaviour {
	public float delay = 1f; //1 second, can be changed
	private float counter = 0.0f;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if (counter >= delay) {
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
			GetComponent<ConstraintDelay> ().enabled = false;
		}
	}
}
