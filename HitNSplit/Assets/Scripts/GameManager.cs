using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject theDeathMenu;

	public void RestartGame ()
	{
		theDeathMenu.SetActive (true);
		StartCoroutine ("RestartGameCo");
	}

	IEnumerator RestartGameCo ()
	{		
		yield return new WaitForSeconds (1f); //Wait for restart
		Time.timeScale = 0;
	}
}
