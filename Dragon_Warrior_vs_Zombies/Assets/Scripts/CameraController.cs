using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	[SerializeField] GameObject player;

	[SerializeField] float timeOffset;

	[SerializeField] Vector2 posOffSet;

	[SerializeField]
	float leftLimit;
	[SerializeField]
	float rightLimit;
	[SerializeField]
	float bottomLimit;
	[SerializeField]
	float topLimit;

	private Vector3 velocity;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {

		//Cameras current position
		Vector3 startPos = transform.position;

		//Player current position
		Vector3 endPos = player.transform.position;

		endPos.x += posOffSet.x;
		endPos.y += posOffSet.y;
		endPos.z = -10;

		//Smoothly move the camera towards the players position
		transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);

		//Limit screen with Clamp
		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, leftLimit, rightLimit),
			Mathf.Clamp (transform.position.y, bottomLimit, topLimit),
			transform.position.z
		);


	}


}
