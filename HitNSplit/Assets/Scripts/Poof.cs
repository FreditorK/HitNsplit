using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poof : MonoBehaviour {

	void OnEnable(){
		StartCoroutine (Poofer());
	}

	IEnumerator Poofer(){
		yield return new WaitForSeconds (1f);
		this.gameObject.SetActive (false);
	}
}
