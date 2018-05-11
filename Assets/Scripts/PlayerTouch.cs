using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerTouch : MonoBehaviour
{

	private SpriteRenderer playerSprite;
	private Score score;

	public Sprite[] allSprites;
	public int currentSprite;

	public float moveSpeed;

	public GameObject particle;

	public Shape[] shapes;

	public Vector3[] nextPositions;
	public int currentPos;

	public List<Vector3> posList;

	// Use this for initialization
	void Start()
	{
		currentPos = 0;
		playerSprite = GetComponent<SpriteRenderer>();
		score = FindObjectOfType<Score>();
		posList = new List<Vector3>();
	}

	// Update is called once per frame
	void Update()
	{

		if (posList.Count != 0)
		{
			transform.position = Vector3.MoveTowards(transform.position, posList[currentPos], Time.deltaTime * moveSpeed);
		}

		if (Input.GetMouseButtonDown(0))
		{
			ChangeSprite();
		}

	}

	// Go to next sprite in array
	void ChangeSprite()
	{

		if (currentSprite != allSprites.Length - 1)
		{
			currentSprite++;
		}
		else
		{
			currentSprite = 0;
		}

		playerSprite.sprite = allSprites[currentSprite];
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.CompareTag("Shape"))
		{

			if (currentSprite == other.GetComponent<Shape>().shapeNum)
			{
				Instantiate(particle, transform.position, Quaternion.identity);
				currentPos++;
				score.score++;
				Destroy(other.gameObject);
			}
			else
			{
				PlayerPrefs.SetInt("playerScore", currentPos);

				if(currentPos > PlayerPrefs.GetInt("highScore")){

					PlayerPrefs.SetInt("highScore", currentPos);
				}

				SceneManager.LoadScene("Restart");
			}
		}
	}
}


