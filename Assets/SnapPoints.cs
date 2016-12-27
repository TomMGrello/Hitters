using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapPoints : MonoBehaviour {
	public GameObject front;
	public GameObject back;
	public GameObject top;
	public GameObject bottom;
	public GameObject left;
	public GameObject right;

	public GameObject GetClosestSnapPoint(GameObject cursor) {
		float min = Vector3.Distance (front.transform.position, cursor.transform.position);
		GameObject point = front;
		float temp = Vector3.Distance (back.transform.position, cursor.transform.position);
		if (temp < min) {
			min = temp;
			point = back;
		}

		temp = Vector3.Distance (top.transform.position, cursor.transform.position);
		if (temp < min) {
			min = temp;
			point = top;
		}

		temp = Vector3.Distance (bottom.transform.position, cursor.transform.position);
		if (temp < min) {
			min = temp;
			point = bottom;
		}

		temp = Vector3.Distance (left.transform.position, cursor.transform.position);
		if (temp < min) {
			min = temp;
			point = left;
		}

		temp = Vector3.Distance (right.transform.position, cursor.transform.position);
		if (temp < min) {
			min = temp;
			point = right;
		}

		return point;
	}
}
