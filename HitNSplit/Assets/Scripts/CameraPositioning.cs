using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositioning : MonoBehaviour {
	void Awake() {
		float factor = (((float) Screen.height) / 1280) * (720/ ((float) Screen.width));
		Camera.main.orthographicSize = 11.1f * factor;
	}
}
