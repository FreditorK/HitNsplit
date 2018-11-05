using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerControl : MonoBehaviour
{
	private RotButtonManager rbManager;
	//rotation script
	private List <GameObject> thePlayers = new List<GameObject> ();
	//list of all players
	private List <GameObject> theInactivePlayers = new List<GameObject> ();
	//list of all inactive players for recycling
	private List<GameObject> thePlayersSorted = new List<GameObject> ();
	//sorted according to touch (nearest to touch come first)
	private Vector2 fp;
	//first touch
	private Vector2 lp;
	//last touch
	public GameObject starter;
	//starting player cuboid

	void Start ()
	{
		rbManager = FindObjectOfType<RotButtonManager> ();
		thePlayersSorted = thePlayers;
		GameObject player1 = (GameObject) Instantiate (starter);
		GameObject player2 = (GameObject) Instantiate (starter);
		player2.transform.position = player2.transform.position + new Vector3 (0, 5, 0);
		thePlayers.Add (player1);
		thePlayers.Add (player2);
	}

	void Update ()
	{
		if (Input.touchCount == 1) { // user is touching the screen with a single touch
			Touch touch = Input.GetTouch (0); // get the touch
			if (touch.phase == TouchPhase.Began) { //check for the first touch
				fp = touch.position;
				lp = touch.position;
			} else if (touch.phase == TouchPhase.Moved) { // update the last position based on where they moved
				lp = touch.position;
			} else if (touch.phase == TouchPhase.Ended) { //check if the finger is removed from the screen
				lp = touch.position;  //last touch position. Ommitted if you use list
			}
			//sorting the players according to the first touch, nearest first
			thePlayersSorted = thePlayers.OrderBy (o => Mathf.Sqrt (Mathf.Pow (Camera.main.WorldToViewportPoint (o.transform.position).x - Camera.main.ScreenToViewportPoint (fp).x, 2) + Mathf.Pow (Camera.main.WorldToViewportPoint (o.transform.position).y - Camera.main.ScreenToViewportPoint (fp).y, 2))).ToList ();
			//registering whether the swipe was intended to be vertically or horizontal
			if (Mathf.Abs (fp.x - lp.x) >= Mathf.Abs (fp.y - lp.y)) {
				movePlayersX ();
			} else {
				movePlayerY ();
			}
		}
		//test if there are any players left on the screen
		gameOverTest ();
	}

	public void movePlayersX ()//move player along x-axis/z-axis
	{
		if (rbManager.getposCount () == 0 || rbManager.getposCount () == 2) {
			if (thePlayersSorted.Count != 0) {
				thePlayersSorted [0].GetComponent<Rigidbody> ().velocity = new Vector3 (thePlayersSorted [0].GetComponent<Rigidbody> ().velocity.x + (Camera.main.ScreenToWorldPoint (lp).x - Camera.main.ScreenToWorldPoint (fp).x), 0, 0);
			}
		} else {//movePlayerZ()
			if (thePlayersSorted.Count != 0) {
				thePlayersSorted [0].GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, thePlayersSorted [0].GetComponent<Rigidbody> ().velocity.z + (Camera.main.ScreenToWorldPoint (lp).z - Camera.main.ScreenToWorldPoint (fp).z));
			}
		}
	}

	public void movePlayerY ()//move player along z-axis
	{
		if (thePlayersSorted.Count != 0) {
			thePlayersSorted [0].GetComponent<Rigidbody> ().velocity = new Vector3 (0, thePlayersSorted [0].GetComponent<Rigidbody> ().velocity.y + (Camera.main.ScreenToWorldPoint (lp).y - Camera.main.ScreenToWorldPoint (fp).y), 0);
		}
	}

	public void addPlayer (GameObject o)
	{//add new gameobject to players
		theInactivePlayers.Remove (o);
		thePlayers.Add (o);	
		o.SetActive (true);
	}

	public void removePlayer (GameObject o)
	{//remove gameobject from players and destroy it
		thePlayers.Remove (o);
		theInactivePlayers.Add (o);
		o.SetActive (false);
	}

	public List<GameObject> getPlayerList ()
	{
		return thePlayers;
	}

	public List<GameObject> getInactivePlayerList (){
		return theInactivePlayers;
	}

	public GameObject getNewPlayer(){
		GameObject newPlayer;
		if (theInactivePlayers.Count > 0) {
			newPlayer = theInactivePlayers [0];
			addPlayer (newPlayer);
		} else {
			newPlayer = (GameObject) Instantiate (starter);
			thePlayers.Add (newPlayer);
		}
		return newPlayer;
	}

	void gameOverTest ()
	{
		List<GameObject> playersToRemove = new List<GameObject> ();//List necessary because cannot alter list while iterating through it
		//add all gameobjects that are not on the screen to playersToRemove
		foreach (GameObject o in thePlayers) {
			if (Camera.main.WorldToViewportPoint (o.transform.position).y >= 1 || Camera.main.WorldToViewportPoint (o.transform.position).y <= 0) {
				playersToRemove.Add (o);
			}
		}
		//remove all gameobjects in playersToRemove from the players
		foreach (GameObject o in playersToRemove) {
			this.removePlayer (o);
		}
		//GAME OVER if no players on screen
		if (thePlayers.Count == 0) {
			this.gameObject.GetComponent<GameManager> ().RestartGame ();
		}
	}
}
