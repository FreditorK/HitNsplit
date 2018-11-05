using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

	public Button restartGame;
	public Button resumeButton;
	public GameObject thePauseMenu;

	void Start ()
	{
		thePauseMenu.SetActive (false);//pause menu invisible

		restartGame.onClick.AddListener (RestartGame);
		resumeButton.onClick.AddListener (ResumeGame);

		this.gameObject.GetComponent<Button> ().onClick.AddListener (PauseGame);
	}

	void RestartGame ()
	{
		SceneManager.LoadScene (0);	//load endless1 scene
		Time.timeScale = 1;
	}

	void ResumeGame ()
	{
		this.gameObject.GetComponent<Button> ().gameObject.SetActive (true);
		thePauseMenu.SetActive (false);
		Time.timeScale = 1;//resume game	
	}

	void PauseGame ()
	{
		this.gameObject.GetComponent<Button> ().gameObject.SetActive (false);
		thePauseMenu.SetActive (true);
		Time.timeScale = 0;//pause game
	}
}
