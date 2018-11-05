using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private WallStatus.wallPos playersWallStatus;

	public void setWallStatus (WallStatus.wallPos ws) {
		playersWallStatus = ws;
	}

	public WallStatus.wallPos getWallStatus () {
		return playersWallStatus;
	}
}
