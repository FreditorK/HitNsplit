using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{

	public Button restartGame;
	//overlay over whole screen, press to restart game
	public Button rightButton;
	//button to rotate to the right
	public Button leftButton;
	//button to rotate to the left
	public Button PauseButton;
	//Button to pause the game
	public Text highscore;
	// displays the highscore

	void Start ()
	{
		this.gameObject.SetActive (false);//Death Menu invisible 
		restartGame.onClick.AddListener (RestartGame);
		highscore.text = "best: 0";//set the text of highscore
		//hide console
		rightButton.gameObject.SetActive (false);
		leftButton.gameObject.SetActive (false);
		PauseButton.gameObject.SetActive (false);
	}

	void RestartGame ()
	{
		SceneManager.LoadScene (0);	//load endless1 scene
		Time.timeScale = 1;
	}
}
