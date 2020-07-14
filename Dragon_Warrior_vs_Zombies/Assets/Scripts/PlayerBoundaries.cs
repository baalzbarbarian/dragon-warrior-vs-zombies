using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour {


	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, -2f, 43f),
			Mathf.Clamp (transform.position.y, -45f,20f),
			transform.position.z
		);
	}
}
