using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

	public Button rightButton;
	public Button leftButton;
	public Button PauseButton;
	public Image scoreMultiplier;
	public Image score;
	public Text highscore;
	public GameObject generationPoint;
	public GameObject firstPlayer;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("Tutorial", 0);
		highscore.text = "best: " + PlayerPrefs.GetFloat ("HighScore");
		rightButton.gameObject.SetActive (false);
		leftButton.gameObject.SetActive (false);
		PauseButton.gameObject.SetActive (false);
		generationPoint.SetActive (false);
		
	}
	void Update ()
	{
		if (Input.touchCount == 0) { // user is touching the screen with a single touch
			StartGame();
		}
	}
	
	void StartGame ()
	{
		this.gameObject.SetActive (false);
		rightButton.gameObject.SetActive (true);
		leftButton.gameObject.SetActive (true);
		PauseButton.gameObject.SetActive (true);
		generationPoint.SetActive (true);
	}
}
