using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractScript : MonoBehaviour {
	public bool playerInRange = false;
	public bool playerDisabled = false;
	public Transform cameraPosition;
	
	// Update is called once per frame
	void Update () {
		if ((playerInRange && !playerDisabled) && Input.GetKeyDown (GameObjectManager.useKey)) {
			SwapCameraToObject ();
		}
		else if ((playerInRange && playerDisabled) && Input.GetKeyDown (GameObjectManager.useKey)) {
			SwapCameraToPlayer ();
		}
	}

	void SwapCameraToObject() {
		SmoothFollowCSharp script = Camera.main.GetComponent<SmoothFollowCSharp> ();
		script.target = cameraPosition;
		playerDisabled = true;
		GameObjectManager.player.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
		GameObjectManager.player.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
		GameObjectManager.player.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		GameObjectManager.player.GetComponent<Animator> ().Stop ();
		GetComponent<CannonAim> ().enabled = true;
		GetComponent<FireCannon> ().enabled = true;
	}

	void SwapCameraToPlayer() {
		SmoothFollowCSharp script = Camera.main.GetComponent<SmoothFollowCSharp> ();
		script.target = GameObjectManager.cameraTargetPlayer;
		playerDisabled = false;
		GameObjectManager.player.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
		GameObjectManager.player.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
		GameObjectManager.player.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePosition;
		GetComponent<CannonAim> ().enabled = false;
		GetComponent<FireCannon> ().enabled = false;
	}
		

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			playerInRange = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			playerInRange = false;
		}
	}
}
