using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform player;
	public Vector3 myPos;

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {

		// Follow the player and add difference
		transform.position = new Vector3(player.position.x, player.position.y, transform.position.z) + myPos;
		
	}
}
