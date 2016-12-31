using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAim : MonoBehaviour
{
    private bool rotating = false;
    private Vector3 rotatePos;
    public float rotatingSpeed = 0.15f;
	public bool developerMode = false;
	public Vector3 originalRotation;
	public float verticalRotationClampAngle = 15f;

	void Start() {
		originalRotation = transform.rotation.eulerAngles;
	}

    // Update is called once per frame
    void Update()
    {
        if (GameObjectManager.buildModeScript.enabled == false)
        {
			if (developerMode)
				LookToClick ();
			else
				ButtonsToRotate ();
        }
    }

    void LookToClick()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                rotatePos = hit.point;
                rotating = true;
            }
        }
        if (rotating)
        {
			Vector3 targetDir = rotatePos - transform.position;
			float step = rotatingSpeed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
			Debug.DrawRay(transform.position, newDir, Color.red);
			transform.rotation = Quaternion.LookRotation(newDir);
            Debug.Log("ROTATING");
            /*Quaternion rotationNeeded = Quaternion.FromToRotation(transform.position, rotatePos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationNeeded, rotatingSpeed);
            if (transform.rotation.Equals(rotationNeeded))
            {
                rotating = false;
                // Debug.Log("Finished");
            }*/
        }
    }

	void ButtonsToRotate() {
		float resultH = Input.GetAxis ("Horizontal");
		float resultV = Input.GetAxis ("Vertical");
		if (resultH > 0)
			transform.RotateAround (transform.position, Vector3.up, rotatingSpeed);
		else if(resultH < 0)
			transform.RotateAround (transform.position, Vector3.up, -rotatingSpeed);
		float angle = transform.eulerAngles.x;
		angle = (angle > 180) ? angle - 360 : angle;
		if (resultV > 0 && angle < 0)
			transform.RotateAround (transform.position, transform.right, rotatingSpeed);
		else if (resultV < 0 && angle > -verticalRotationClampAngle) {
			Debug.Log ("Rotate up: " + transform.rotation.eulerAngles.x);
			transform.RotateAround (transform.position, transform.right, -rotatingSpeed);
		}
		/*if (transform.rotation.eulerAngles.x < 0)
			transform.rotation = Quaternion.Euler(new Vector3 (0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
		else if (Mathf.Abs (originalRotation.x - transform.rotation.eulerAngles.x) > verticalRotationClampAngle)
			transform.rotation = Quaternion.Euler(new Vector3 (verticalRotationClampAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));*/
	}
}