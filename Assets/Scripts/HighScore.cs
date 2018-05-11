using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	public Text yourScore;
	public Text highScore;

	// Use this for initialization
	void Start () {

		yourScore.text = "Score: " + PlayerPrefs.GetInt("playerScore", 0).ToString();
		highScore.text = "HighScore: " + PlayerPrefs.GetInt("highScore", 0).ToString();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
