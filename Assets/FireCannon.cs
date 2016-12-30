using System.Collections;
using System.Collections.Generic;
//using System.Collections.ArrayList;
using UnityEngine;

public class FireCannon : MonoBehaviour {
	public KeyCode fireButton = KeyCode.Space;
	public GameObject cannonball;
	public GameObject cannonballGhost;
	public Transform instantiatePos;
	public float power = 500f;
	public KeyCode toggleTrajectoryButton = KeyCode.LeftShift;
	public KeyCode fireTrajectory = KeyCode.F;
	public bool showTrajectory = false;
	private Rigidbody crb;
	private LineRenderer lr = new LineRenderer ();
	private AudioSource sound;
	public float reloadTime = 10f;
	public bool reloading = false;
	public float count = 0.0f;
	public int ammo = 5;

	void Start() {
		crb = cannonball.GetComponent<Rigidbody> ();
		sound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (reloading) {
			count += Time.deltaTime;
			if (count >= reloadTime)
				reloading = false;
		}
		if (Input.GetKeyDown (fireButton)) 
			Fire ();
		if (Input.GetKeyDown (toggleTrajectoryButton))
			showTrajectory = !showTrajectory;
		if (showTrajectory)
		if (Input.GetKeyDown (fireTrajectory))
			FireGhost ();
		CheckPowerChange ();
	}

	void Fire() {
		if (!reloading && ammo > 0) {
			sound.Play ();
			GameObject fired = (GameObject)Instantiate (cannonball, instantiatePos.position, Quaternion.identity);
			Rigidbody frb = fired.GetComponent<Rigidbody> ();
			frb.AddForce (instantiatePos.forward * power, ForceMode.Impulse);
			reloading = true;
			count = 0.0f;
			ammo--;
		}
	}

	void DrawTrajectory() {
		/*float initVeloc = power / crb.mass;
		float angle = Vector3.Angle (Vector3.up, instantiatePos.forward);
		float maxDistance = ((initVeloc * initVeloc) * ((Mathf.Sin((-angle * Mathf.Deg2Rad) *2))))/Physics.gravity;
		float numVertices = 25f;
		float interval = maxDistance / numVertices;
		ArrayList positions = new ArrayList ();
		float[] xPoints = new float[numVertices+1];
		float[] yPoints = new float[numVertices+1];
		for (int i = 0; i < numVertices; i++) {
			Vector3 prevPos;
			if (positions.Count <= 0)
				prevPos = instantiatePos.position;
			else
				prevPos = positions [positions.Count - 1];
			xPoints [i] = prevPos.x + interval;
			yPoints[i] = instantiatePos.position.y + (xPoints[i] * (Mathf.Tan(-angle * Mathf.Deg2Rad))) -	((Physics.gravity * (xPoints[i]*xPoints[i])) /(((Mathf.Cos(-angle * Mathf.Deg2Rad) * initVeloc)  * (Mathf.Cos(-angle * Mathf.Deg2Rad) * initVeloc)) *2));
			positions.Add(new Vector3(xPoints[i],yPoints[i],
		}*/
	}

	void FireGhost() {
		GameObject fired = (GameObject)Instantiate (cannonballGhost, instantiatePos.position, Quaternion.identity);
		fired.GetComponent<DestroyAfterContactAndTime> ().parentCannon = gameObject;
		Rigidbody frb = fired.GetComponent<Rigidbody> ();
		frb.AddForce (instantiatePos.forward * power,ForceMode.Impulse);
	}

	void CheckPowerChange() {
		float movement = Input.GetAxis ("Mouse ScrollWheel");
		if (movement > 0) {
			power++;
		} else if (movement < 0)
			power--;
	}
}