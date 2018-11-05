using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralGenerator : MonoBehaviour
{

	private RotButtonManager rbManager;
	//rotation script
	private Pooler pooledObstacles;
	private PlayerControl thePlayers;
	//players
	private float generationTime = 5.0f;
	public GameObject middleAxis;

	void Start ()
	{
		//initialising instance variables
		rbManager = FindObjectOfType<RotButtonManager> ();
		pooledObstacles = middleAxis.GetComponent<Pooler> ();
		thePlayers = middleAxis.GetComponent<PlayerControl> ();
	}

	void Update ()
	{
		generationTime += Random.Range (Time.deltaTime, 2 * Time.deltaTime);
		if (generationTime > 6) {
			generationTime = 0;
			GenerateNew ();
			}
	}

	public void GenerateNew ()//has to be public to regenrate Resizer after their death
	{
		GameObject newObstacle = pooledObstacles.GetPooledObject ();
		//coming down from top, coming up from bottom
		float[] randomHeight = new float[] { -6, 33 };
		float height = randomHeight [Random.Range (0, randomHeight.Length)];

		switch (rbManager.getposCount ()) {
		case 0:
			newObstacle.transform.position = new Vector3 (Random.Range (-1, -9), height, -9.55f);
			newObstacle.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
			newObstacle.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionZ;
			newObstacle.GetComponent<Rigidbody> ().velocity = new Vector3 (Random.Range (-5, 5), 0, 0);
			newObstacle.GetComponent<Obstacle> ().setVelocity ((-((height / 3) - 4.5f) / 2.5f) + Random.Range(-1, 1));
			newObstacle.SetActive (true);
			break;
		case 1:
			newObstacle.transform.position = new Vector3 (-0.45f, height, Random.Range (-1, -9));
			newObstacle.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
			newObstacle.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionX;
			newObstacle.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, Random.Range (-5, 5));
			newObstacle.GetComponent<Obstacle> ().setVelocity ((-((height / 3) - 4.5f) / 2.5f) + Random.Range(-1, 1));
			newObstacle.SetActive (true);
			break;
		case 2:
			newObstacle.transform.position = new Vector3 (Random.Range (-1, -9), height, -0.45f);
			newObstacle.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
			newObstacle.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionZ;
			newObstacle.GetComponent<Rigidbody> ().velocity = new Vector3 (Random.Range (-5, 5), 0, 0);
			newObstacle.GetComponent<Obstacle> ().setVelocity ((-((height / 3) - 4.5f) / 2.5f) + Random.Range(-1, 1));
			newObstacle.SetActive (true);
			break;
		case 3:
			newObstacle.transform.position = new Vector3 (-9.55f, height, Random.Range (-1, -9));
			newObstacle.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
			newObstacle.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionX;
			newObstacle.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, Random.Range (-5, 5));
			newObstacle.GetComponent<Obstacle> ().setVelocity ((-((height / 3) - 4.5f) / 2.5f) + Random.Range(-1, 1));
			newObstacle.SetActive (true);
			break;
		}
			
	}
}