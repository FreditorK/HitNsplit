using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour {

	public GameObject[] pooledObjects;

	public int pooledAmount;

	List<GameObject> objectsInPool;

	public GameObject poof;

	List<GameObject> poofsInPool;

	// Use this for initialization
	void Start () {
		objectsInPool = new List<GameObject> ();
		poofsInPool = new List<GameObject> ();

		for (int i = 0; i < pooledAmount; i++) {
			foreach (GameObject o in pooledObjects) {
				GameObject obj = (GameObject) Instantiate (o);
				obj.SetActive (false);
				objectsInPool.Add (obj);
			}
			GameObject poo = (GameObject) Instantiate (poof);
			poo.SetActive (false);
			poofsInPool.Add (poo);
		}

	}

	public GameObject GetPooledObject(){
		List<GameObject> activeObjects = new List<GameObject> ();
		for (int i = 0; i < objectsInPool.Count; i++) {
			if (!objectsInPool[i].activeInHierarchy) {
				activeObjects.Add(objectsInPool [i]);
			}
		}
		if (activeObjects == null) {
			int k = Random.Range (0, pooledObjects.Length);
			GameObject obj = (GameObject)Instantiate (pooledObjects [k]);
			obj.SetActive (false);
			objectsInPool.Add (obj);
			return obj;
		} else {
			return activeObjects [Random.Range (0, activeObjects.Count)];
		}
	}

	public GameObject GetPooledPoof(){
		List<GameObject> activePoofs = new List<GameObject> ();
		for (int i = 0; i < poofsInPool.Count; i++) {
			if (!poofsInPool[i].activeInHierarchy) {
				activePoofs.Add(poofsInPool [i]);
			}
		}
		if (activePoofs == null) {
			GameObject poo = (GameObject)Instantiate (poof);
			poo.SetActive (false);
			poofsInPool.Add (poo);
			return poo;
		} else {
			return activePoofs [Random.Range (0, activePoofs.Count)];
		}
	}

	public List<GameObject> GetObjectsinPool(){
		return objectsInPool;
	}
}
