using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotButtonManager : MonoBehaviour
{

	public Button rightButton;//rotation button right

	public Button leftButton;//rotation button left

	public GameObject generationPoint;//generation point for resizers, destroyers and obstacles

	public WallScript[] walls = new WallScript[4];//scripts of all walls, wallstati

	private Vector3 startPos;

	private Vector3 right90;

	private Vector3 left90;

	private Vector3 start180;

	private int posCount;//what position am I in 0 front, 1 right, 2 back, 3 left (mod 4)

	private Quaternion startRot;

	private Quaternion changedRot;//generation point rotated to side

	void Start ()
	{
		startRot = generationPoint.transform.rotation;
		changedRot = generationPoint.transform.rotation * Quaternion.Euler (0, 90, 0);
		posCount = 0;
		//register all camera posrot
		startPos = Camera.main.transform.position;
		for (int i = 1; i < 4; i++) {
			Camera.main.gameObject.transform.RotateAround (this.gameObject.transform.position, Vector3.down, 90);
			switch (i) {
			case 1:
				right90 = Camera.main.transform.position;
				break;
			case 2:
				start180 = Camera.main.transform.position;
				break;
			case 3:
				left90 = Camera.main.transform.position;
				break;
			}
		}
		Camera.main.gameObject.transform.RotateAround (this.gameObject.transform.position, Vector3.down, 90);//return to front position
		Camera.main.transform.LookAt (this.gameObject.transform.position);//focus on middleaxis

		rightButton.onClick.AddListener (TaskOnClickright);
		leftButton.onClick.AddListener (TaskOnClickleft);
	}

	void TaskOnClickright ()
	{
		//set all obstacles to inactive
		List<GameObject> toSetInactive = new List<GameObject> ();
		foreach (GameObject o in this.gameObject.GetComponent<Pooler>().GetObjectsinPool()) {
			toSetInactive.Add (o);
		}
		foreach (GameObject o in toSetInactive) {
			o.SetActive (false);
		}
		//destroy all players not touching the right wall
		List<GameObject> toDestroy = new List<GameObject> ();
		foreach (GameObject o in this.gameObject.GetComponent<PlayerControl>().getPlayerList()) {
			if (o.GetComponent<Player> ().getWallStatus () != WallStatus.wallPos.Right) {
				toDestroy.Add (o);
			} 
		}
		foreach (GameObject o in toDestroy) {
			this.gameObject.GetComponent<PlayerControl> ().removePlayer (o);	
		}
		//new front
		posCount = mod (posCount + 1, 4);

		//assign new wallstati
		foreach (GameObject o in this.gameObject.GetComponent<PlayerControl>().getPlayerList()) {
			if (o.GetComponent<Player> ().getWallStatus () == WallStatus.wallPos.Right) {
				o.GetComponent<Player> ().setWallStatus (WallStatus.wallPos.Left);
				o.GetComponentInChildren<Wireframe> ().Rewire ();
			} else {
				o.GetComponent<Player> ().setWallStatus (WallStatus.wallPos.Right);
				o.GetComponentInChildren<Wireframe> ().Rewire ();
			}
		}

		Camera.main.transform.LookAt (this.gameObject.transform);//focus on middleaxis
		StartCoroutine (CoroutineRight ());

		
	}

	void TaskOnClickleft ()
	{
		List<GameObject> toSetInactive = new List<GameObject> ();
		foreach (GameObject o in this.gameObject.GetComponent<Pooler>().GetObjectsinPool()) {
			toSetInactive.Add (o);
		}
		foreach (GameObject o in toSetInactive) {
			o.SetActive (false);
		}
		List<GameObject> toDestroy = new List<GameObject> ();
		foreach (GameObject o in this.gameObject.GetComponent<PlayerControl>().getPlayerList()) {
			if (o.GetComponent<Player> ().getWallStatus() != WallStatus.wallPos.Left) {
				toDestroy.Add (o);
			}
		}
		foreach (GameObject o in toDestroy) {
			this.gameObject.GetComponent<PlayerControl> ().removePlayer (o);	
		}

		posCount = mod (posCount - 1, 4);
		foreach (GameObject o in this.gameObject.GetComponent<PlayerControl>().getPlayerList()) {
			if (o.GetComponent<Player> ().getWallStatus () == WallStatus.wallPos.Right) {
				o.GetComponent<Player> ().setWallStatus (WallStatus.wallPos.Left);
				o.GetComponentInChildren<Wireframe> ().Rewire ();
			} else {
				o.GetComponent<Player> ().setWallStatus (WallStatus.wallPos.Right);
				o.GetComponentInChildren<Wireframe> ().Rewire ();
			}
		}
		Camera.main.transform.LookAt (this.gameObject.transform);
		StartCoroutine (CoroutineLeft ());
	
	}

	IEnumerator CoroutineRight ()
	{
		//change stati of all walls
		foreach (WallScript w in walls) {
			w.RotateRight ();
		}
		//rotate 90 degrees to the right
		float elapsedTime = 0;
		while (elapsedTime < 1f) {
			Camera.main.gameObject.transform.RotateAround (this.gameObject.transform.position, Vector3.down, 90 * Time.deltaTime);
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}

		switch (posCount) {
		case 0:
			Camera.main.transform.position = startPos;
			Camera.main.transform.LookAt (this.gameObject.transform.position);
			generationPoint.transform.rotation = startRot;
			break;
		case 1:
			Camera.main.transform.position = right90;
			Camera.main.transform.LookAt (this.gameObject.transform.position);
			generationPoint.transform.rotation = changedRot;
			break;
		case 2:
			Camera.main.transform.position = start180;
			Camera.main.transform.LookAt (this.gameObject.transform.position);
			generationPoint.transform.rotation = startRot;
			break;
		case 3:
			Camera.main.transform.position = left90;
			Camera.main.transform.LookAt (this.gameObject.transform.position);
			generationPoint.transform.rotation = changedRot;
			break;
		}
	}

	IEnumerator CoroutineLeft ()
	{
		
		foreach (WallScript w in walls) {
			w.RotateLeft ();
		}

		float elapsedTime = 0;
		while (elapsedTime < 1f) {
			Camera.main.gameObject.transform.RotateAround (this.gameObject.transform.position, Vector3.up, 90 * Time.deltaTime);
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}

		switch (posCount) {
		case 0:
			Camera.main.transform.position = startPos;
			Camera.main.transform.LookAt (this.gameObject.transform.position);
			generationPoint.transform.rotation = startRot;
			break;
		case 1:
			Camera.main.transform.position = right90;
			Camera.main.transform.LookAt (this.gameObject.transform.position);
			generationPoint.transform.rotation = changedRot;
			break;
		case 2:
			Camera.main.transform.position = start180;
			Camera.main.transform.LookAt (this.gameObject.transform.position);
			generationPoint.transform.rotation = startRot;
			break;
		case 3:
			Camera.main.transform.position = left90;
			Camera.main.transform.LookAt (this.gameObject.transform.position);
			generationPoint.transform.rotation = changedRot;
			break;
		}
	}

	int mod (int x, int m)
	{//mod function
		return (x % m + m) % m;
	}
		
	public int getposCount(){
		return posCount;
	}
}
