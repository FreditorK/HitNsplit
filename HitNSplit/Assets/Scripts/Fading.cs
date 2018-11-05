using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour {

	public Texture2D fadeOutTexture; //texture that overlays the screen
	public float fadeSpeed = 0.8f; // fading speed

	private int drawDepth = -1000; // order in draw hierarchy
	private float alpha = 0.5f; //texture's initial value (0, 1)
	private int fadeDir = -1; // direction to fade in -1 fade in, 1 fade out

	void OnGUI(){
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
	}

	public float BeginFade (int direction){
		fadeDir = direction;
		return (fadeSpeed);
	}
}
