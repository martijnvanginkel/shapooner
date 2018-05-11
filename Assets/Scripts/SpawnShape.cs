using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnShape : MonoBehaviour {

	private PlayerTouch playerTouch;
	private Score score;

	public Shape[] shapes;

	private int currentShape;

	public float timeToSpawn;
	public float spawnTimer;
	private float increaseRate;

	private int lastShape;

	// Use this for initialization
	void Start () {

		playerTouch = FindObjectOfType<PlayerTouch>();
		score = FindObjectOfType<Score>();

		increaseRate = 0.15f;
		spawnTimer = timeToSpawn;
	}
	
	// Update is called once per frame
	void Update () {

		spawnTimer -= Time.deltaTime;

		if (spawnTimer <= 0) {
			
			Spawn();
		}
		
	}

	void Spawn()
	{

		spawnTimer = timeToSpawn;
		currentShape = Random.Range(0, 2);
		int[] shapePositions = {-2, 0, 2};
		int randomIndex = Random.Range(0, shapePositions.Length);
		Vector3 shapePos = new Vector3(shapePositions[randomIndex], transform.position.y, transform.position.z);
		Shape newShape = Instantiate(shapes[currentShape], shapePos, Quaternion.identity);
		newShape.shapeNum = currentShape;
		playerTouch.posList.Add(newShape.GetComponent<Transform>().position);

		if (timeToSpawn >= 0.5f) {

			if (score.score > 8)
			{
				increaseRate = increaseRate / 2;
			}

			timeToSpawn -= increaseRate;
			playerTouch.moveSpeed = playerTouch.moveSpeed + increaseRate;
		}

	}

}
