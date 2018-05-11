using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRotations : MonoBehaviour {

	public GameObject[] shapes;

	public float rotationSpeed;
	public float moveSpeed;

	public Vector2 pointA;
	public Vector2 pointB;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		foreach (GameObject shape in shapes)
		{
			shape.transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);
		}
		
	}
}
