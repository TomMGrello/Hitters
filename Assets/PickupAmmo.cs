using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAmmo : MonoBehaviour {
	public bool canPickUp = false;
	public bool holding = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (canPickUp) {
			if (Input.GetKeyDown (GameObjectManager.pickupKey)) 
				holding = !holding;
		}
		if(holding){
			transform.position = GameObjectManager.playerHands.position;
			transform.rotation = GameObjectManager.playerHands.rotation;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") 
			canPickUp = true;
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player")
			canPickUp = false;
	}
}
