using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	private Vector3 rotation;
	private float velocity;
	private Pooler pooler;
	private PlayerControl thePlayers;

	void Awake(){
		pooler = FindObjectOfType<Pooler> ();
		thePlayers = pooler.gameObject.GetComponent<PlayerControl> ();

	}

	void Start(){
		rotation = new Vector3 (Random.Range (-1, 1), Random.Range (-1, 1), Random.Range (-1, 1));		
	}

	void Update () {
		this.gameObject.transform.Rotate (rotation, 80f * Time.deltaTime);
		this.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3(this.gameObject.GetComponent<Rigidbody> ().velocity.x, velocity, this.gameObject.GetComponent<Rigidbody> ().velocity.z);
		CheckHeight ();
	}
	void CheckHeight(){
		if (this.gameObject.transform.position.y < -6 || this.gameObject.transform.position.y > 33) {
			this.gameObject.SetActive (false);
		}
	}

	public void setVelocity(float v){
		velocity = v;
	}

	void OnCollisionEnter(Collision c){
		if (c.collider.gameObject.GetComponent<PlayersMesh> () != null) {
			Vector3 hitPoint = c.contacts [0].point;
			GameObject newPoof = pooler.GetPooledPoof ();
			newPoof.transform.position = this.gameObject.transform.position;
			newPoof.SetActive (true);
			PlayersMesh p = c.collider.gameObject.GetComponent<PlayersMesh> ();
			WallStatus.wallPos hitSide = p.GetHitSide (hitPoint);
			this.gameObject.SetActive (false);

			if (hitSide == WallStatus.wallPos.Splitx) {
				if (p.IsLegalSize (hitSide)) {
					p.gameObject.SetActive (false);
					GameObject newPlayerr = thePlayers.getNewPlayer ();
					GameObject newPlayerl = thePlayers.getNewPlayer ();
					newPlayerr.transform.position = c.collider.gameObject.transform.position + new Vector3 (0.07f, 0, 0);
					newPlayerl.transform.position = c.collider.gameObject.transform.position - new Vector3 (0.07f, 0, 0);

					newPlayerr.GetComponent<PlayersMesh> ().xr = p.xr;
					newPlayerr.GetComponent<PlayersMesh> ().xl = 0.14f;
					newPlayerr.GetComponent<PlayersMesh> ().zr = p.zr;
					newPlayerr.GetComponent<PlayersMesh> ().zl = p.zl;
					newPlayerr.GetComponent<PlayersMesh> ().Revive (WallStatus.wallPos.Left);

					newPlayerl.GetComponent<PlayersMesh> ().xr = 0.14f;
					newPlayerl.GetComponent<PlayersMesh> ().xl = p.xl;
					newPlayerl.GetComponent<PlayersMesh> ().zr = p.zr;
					newPlayerl.GetComponent<PlayersMesh> ().zl = p.zl;
					newPlayerl.GetComponent<PlayersMesh> ().Revive (WallStatus.wallPos.Right);

					newPlayerr.GetComponent<Rigidbody> ().velocity += new Vector3 (0.5f, 0, 0);
					newPlayerl.GetComponent<Rigidbody> ().velocity -= new Vector3 (0.5f, 0, 0);
					thePlayers.removePlayer (p.gameObject);
				}
			} else if (hitSide == WallStatus.wallPos.Splitz) {
				if (p.IsLegalSize (hitSide)) {
					p.gameObject.SetActive (false);
					GameObject newPlayerr = thePlayers.getNewPlayer ();
					GameObject newPlayerl = thePlayers.getNewPlayer ();
					newPlayerr.transform.position = c.collider.gameObject.transform.position + new Vector3 (0, 0, 0.07f);
					newPlayerl.transform.position = c.collider.gameObject.transform.position - new Vector3 (0, 0, 0.07f);

					newPlayerr.GetComponent<PlayersMesh> ().xr = p.xr;
					newPlayerr.GetComponent<PlayersMesh> ().xl = p.xl;
					newPlayerr.GetComponent<PlayersMesh> ().zr = p.zr;
					newPlayerr.GetComponent<PlayersMesh> ().zl = 0.14f;
					newPlayerr.GetComponent<PlayersMesh> ().Revive (WallStatus.wallPos.Front);

					newPlayerl.GetComponent<PlayersMesh> ().xr = p.xr;
					newPlayerl.GetComponent<PlayersMesh> ().xl = p.xl;
					newPlayerl.GetComponent<PlayersMesh> ().zr = 0.14f;
					newPlayerl.GetComponent<PlayersMesh> ().zl = p.zl;
					newPlayerl.GetComponent<PlayersMesh> ().Revive (WallStatus.wallPos.Back);

					newPlayerr.GetComponent<Rigidbody> ().velocity += new Vector3 (0, 0, 0.5f);
					newPlayerl.GetComponent<Rigidbody> ().velocity -= new Vector3 (0, 0, 0.5f);
					thePlayers.removePlayer (p.gameObject);
				}
			} else {
				if (p.IsLegalSize (hitSide)) {
					p.Shrink (hitSide);
					foreach (GameObject o in thePlayers.getPlayerList()) {
						if (o != p.gameObject) {
							o.GetComponent<PlayersMesh> ().Grow ();
						}
					}
				} else {
					p.gameObject.SetActive (false);
				}
			}
		}
	}
}
