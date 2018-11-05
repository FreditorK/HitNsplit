using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{

	private Collision thecoll;

	public WallStatus.wallPos wallPos;

	public void RotateRight ()
	{
		if (wallPos == WallStatus.wallPos.Front) {
			wallPos = WallStatus.wallPos.Left;
			this.gameObject.SetActive (true);
		} else if (wallPos == WallStatus.wallPos.Right) {
			wallPos = WallStatus.wallPos.Front;
			this.gameObject.SetActive (false);
			OnCollisionExit (thecoll);
		} else if (wallPos == WallStatus.wallPos.Back) {
			wallPos = WallStatus.wallPos.Right;
			this.gameObject.SetActive (true);
		} else if (wallPos == WallStatus.wallPos.Left) {
			wallPos = WallStatus.wallPos.Back;
			this.gameObject.SetActive (true);
		}	
	}

	public void RotateLeft ()
	{
		if (wallPos == WallStatus.wallPos.Front) {
			wallPos = WallStatus.wallPos.Right;
			this.gameObject.SetActive (true);
		} else if (wallPos == WallStatus.wallPos.Right) {
			wallPos = WallStatus.wallPos.Back;
			this.gameObject.SetActive (true);
		} else if (wallPos == WallStatus.wallPos.Back) {
			wallPos = WallStatus.wallPos.Left;
			this.gameObject.SetActive (true);
		} else if (wallPos == WallStatus.wallPos.Left) {
			wallPos = WallStatus.wallPos.Front;
			this.gameObject.SetActive (false);
			OnCollisionExit (thecoll);
		}	
	}

	void OnCollisionStay (Collision collision)
	{
		thecoll = collision;
		if (collision.collider.gameObject.GetComponent<Player>() != null) {
			collision.collider.gameObject.GetComponentInChildren<Wireframe>().ColorOuterVertices(wallPos);//wireframe glows green when touching wall
			collision.collider.gameObject.GetComponent<Player> ().setWallStatus (wallPos);
		}
	}

	void OnCollisionExit (Collision collision)
	{
		if (collision.collider.gameObject.GetComponent<Player>() != null) {
			collision.collider.gameObject.GetComponentInChildren<Wireframe>().ColorOuterVertices(WallStatus.wallPos.Front);//wireframes returns Touch normal color
			collision.collider.gameObject.GetComponent<Player> ().setWallStatus (WallStatus.wallPos.Front);
		}
	}
}
