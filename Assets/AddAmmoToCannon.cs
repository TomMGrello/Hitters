using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAmmoToCannon : MonoBehaviour {
	public int amount = 5;
	public bool gaveAmmo = false;
	Collider cannon;
	void OnTriggerEnter(Collider other) {
		if (!gaveAmmo && other.tag == "Cannon") {
			cannon = other;
			gaveAmmo = true;
		}
	}

	void Update() {
		if (gaveAmmo) {
			gaveAmmo = false;
			cannon.gameObject.GetComponent<FireCannon> ().ammo += amount;
			Destroy (gameObject);
		}
	}
}
