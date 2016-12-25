using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRigidbodies : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.Equals (gameObject))
			return;
		Debug.Log ("Trigger Entered");
		Collider[] cols = Physics.OverlapSphere (transform.position, transform.localScale.x * 3);
		foreach (Collider current in cols)
			if (current.tag == "Movable" && current.gameObject.layer != 8) {
				Rigidbody crb = current.GetComponent<Rigidbody> ();
				crb.useGravity = true;
				crb.constraints = RigidbodyConstraints.None;
			}
	}
}
