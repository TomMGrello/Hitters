using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeScript : MonoBehaviour {
	private float explosionRadius;
	public float explosionModifier = 20f;
	public float explosionForce = 200f;
	public GameObject explosion;

	void Start() {
		explosionRadius = transform.localScale.x * explosionModifier;
	}
	void OnCollisionEnter(Collision other) {
		Instantiate (explosion, transform.position, Quaternion.identity);
		Collider[] cols = Physics.OverlapSphere (transform.position, explosionRadius);
		foreach (Collider col in cols) {
			if (col.gameObject.tag == "Movable" && col.gameObject.layer != 8)
				col.gameObject.GetComponent<Rigidbody> ().AddExplosionForce (explosionForce, transform.position, explosionRadius);
		}
		Destroy (gameObject);
	}
}
