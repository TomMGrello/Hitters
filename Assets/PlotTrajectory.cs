using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotTrajectory : MonoBehaviour {
	LineRenderer lr;
	public float timeIntervaleBetweenPlots = 0.1f;
	public float lastTime = 0.0f;
	private List<Vector3> positions;
	public bool shouldDraw = true;
	// Use this for initialization
	void Start () {
		lr = GetComponent<LineRenderer> ();
		positions = new List<Vector3> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (shouldDraw) {
			//if (Time.time - lastTime >= timeIntervaleBetweenPlots)
			AddPointToLineRenderer ();
			//lastTime = Time.time;
		}
	}

	void AddPointToLineRenderer() {
		positions.Add (transform.position);
		lr.numPositions = positions.Count;
		lr.SetPositions (positions.ToArray ());
	}

	void OnCollisionEnter(Collision other) {
		shouldDraw = false;
	}
}
