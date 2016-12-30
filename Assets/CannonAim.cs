using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAim : MonoBehaviour
{
    private bool rotating = false;
    private Vector3 rotatePos;
    public float rotatingSpeed = 1f;
	public bool developerMode = false;
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
		if (resultH > 0)
			transform.RotateAround (transform.position, Vector3.up, rotatingSpeed);
		else if(resultH < 0)
			transform.RotateAround (transform.position, Vector3.up, -rotatingSpeed);
	}
}