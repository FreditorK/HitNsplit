using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTaker : MonoBehaviour {

	public Text scoreText;

	public PlayerControl thePlayers;

	private float score;

	// Update is called once per frame
	void Update () {
		score = 0;
		foreach (GameObject o in thePlayers.getPlayerList()) {
			score += o.GetComponent<PlayersMesh> ().GetVolume ();
		}
		scoreText.text = score.ToString ("F2");
	}
}
