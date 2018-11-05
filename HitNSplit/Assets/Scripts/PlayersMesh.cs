using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(MeshFilter), typeof(MeshRenderer), typeof(BoxCollider))]
public class PlayersMesh : MonoBehaviour {
	private Mesh mesh;
	private RotButtonManager rbManager;
	private Vector3[] vertexset = new Vector3[8];
	public float xr;
	public float xl;
	public float zr;
	public float zl;


	void Awake ()
	{
		mesh = GetComponent<MeshFilter> ().mesh;
		rbManager = FindObjectOfType<RotButtonManager> ();
	}

    void Start(){
		MakeMesh ();
		RecalcBoxcollider ();
		this.gameObject.GetComponentInChildren<Wireframe> ().Rewire ();
	}

	public void Revive(WallStatus.wallPos i){
		MakeMesh ();
		RecalcBoxcollider ();
		this.gameObject.GetComponentInChildren<Wireframe> ().Rewire ();
		this.gameObject.GetComponentInChildren<Wireframe> ().ColorInnerVertices(i);
	}

	void MakeMesh ()
	{
		vertexset [0] = new Vector3(xr, -0.17f, zr);
		vertexset [1] = new Vector3(-xl, -0.17f, zr);
		vertexset [2] = new Vector3(xr, 0.17f, zr);
		vertexset [3] = new Vector3(-xl, 0.17f, zr);
		vertexset [4] = new Vector3(xr, 0.17f, -zl);
		vertexset [5] = new Vector3(-xl, 0.17f, -zl);
		vertexset [6] = new Vector3(xr, -0.17f, -zl);
		vertexset [7] = new Vector3(-xl, -0.17f, -zl);

		mesh.Clear ();

		mesh.vertices = vertexset;

		mesh.triangles = new int[] { 
			0, 6, 4,
			0, 4, 2,

			6, 7, 5,
			6, 5, 4,

			5, 7, 1,
			5, 1, 3,

			1, 0, 3,
			3, 0, 2,

			2, 4, 5,
			2, 5, 3,

			6, 0, 1,
			6, 1, 7
		};

		mesh.RecalculateNormals ();	
	}

	public void Shrink(WallStatus.wallPos hitSide){

		switch (hitSide) {
		case WallStatus.wallPos.Left:
			xl = xl - 0.14f;
			vertexset [1] = new Vector3 (-xl, -0.17f, zr);
			vertexset [3] = new Vector3 (-xl, 0.17f, zr);
			vertexset [5] = new Vector3 (-xl, 0.17f, -zl);
			vertexset [7] = new Vector3 (-xl, -0.17f, -zl);
			break;
		case WallStatus.wallPos.Front:
			zl = zl - 0.14f;
			vertexset [4] = new Vector3 (xr, 0.17f, -zl);
			vertexset [5] = new Vector3 (-xl, 0.17f, -zl);
			vertexset [6] = new Vector3 (xr, -0.17f, -zl);
			vertexset [7] = new Vector3 (-xl, -0.17f, -zl);
			break;
		case WallStatus.wallPos.Right:
			xr = xr - 0.14f;
			vertexset [0] = new Vector3 (xr, -0.17f, zr);
			vertexset [2] = new Vector3 (xr, 0.17f, zr);
			vertexset [4] = new Vector3 (xr, 0.17f, -zl);
			vertexset [6] = new Vector3 (xr, -0.17f, -zl);
			break;
		case WallStatus.wallPos.Back:
			zr = zr - 0.14f;
			vertexset [0] = new Vector3 (xr, -0.17f, zr);
			vertexset [1] = new Vector3 (-xl, -0.17f, zr);
			vertexset [2] = new Vector3 (xr, 0.17f, zr);
			vertexset [3] = new Vector3 (-xl, 0.17f, zr);
			break;
		default:
			throw new UnityException ("Shrinking problem");
			break;	
		}
		mesh.vertices = vertexset;
		this.gameObject.GetComponentInChildren<Wireframe> ().Shrink (hitSide);
		RecalcBoxcollider ();
	}

	public void Grow(){

		switch (rbManager.getposCount()) {
		case 0:
			if (zr + zl <= 10) {
				zr = zr + 0.14f;
				vertexset [0] = new Vector3 (xr, -0.17f, zr);
				vertexset [1] = new Vector3 (-xl, -0.17f, zr);
				vertexset [2] = new Vector3 (xr, 0.17f, zr);
				vertexset [3] = new Vector3 (-xl, 0.17f, zr);
				mesh.vertices = vertexset;
				this.gameObject.GetComponentInChildren<Wireframe> ().Grow (0);
			}
			break;
		case 1:
			if (xr + xl <= 10) {
				xl = xl + 0.14f;
				vertexset [1] = new Vector3 (-xl, -0.17f, zr);
				vertexset [3] = new Vector3 (-xl, 0.17f, zr);
				vertexset [5] = new Vector3 (-xl, 0.17f, -zl);
				vertexset [7] = new Vector3 (-xl, -0.17f, -zl);
				mesh.vertices = vertexset;
				this.gameObject.GetComponentInChildren<Wireframe> ().Grow (1);
			}
			break;
		case 2:
			if (zr + zl <= 10) {
				zl = zl + 0.14f;
				vertexset [4] = new Vector3 (xr, 0.17f, -zl);
				vertexset [5] = new Vector3 (-xl, 0.17f, -zl);
				vertexset [6] = new Vector3 (xr, -0.17f, -zl);
				vertexset [7] = new Vector3 (-xl, -0.17f, -zl);
				mesh.vertices = vertexset;
				this.gameObject.GetComponentInChildren<Wireframe> ().Grow (2);
			}
			break;
		case 3:
			if (xr + xl <= 10) {
				xr = xr + 0.14f;
				vertexset [0] = new Vector3 (xr, -0.17f, zr);
				vertexset [2] = new Vector3 (xr, 0.17f, zr);
				vertexset [4] = new Vector3 (xr, 0.17f, -zl);
				vertexset [6] = new Vector3 (xr, -0.17f, -zl);
				mesh.vertices = vertexset;
				this.gameObject.GetComponentInChildren<Wireframe> ().Grow (3);
			}
			break;
		default:
			throw new UnityException ("Growing problem");
			break;	
		}
		RecalcBoxcollider ();
	}

	public void RecalcBoxcollider(){
		this.gameObject.GetComponent<BoxCollider> ().center = new Vector3((xr-xl)/2, 0, (zr-zl)/2);
		this.gameObject.GetComponent<BoxCollider> ().size = new Vector3(xr+xl, 0.34f, zr+zl);
	}
		
	public bool IsLegalSize(WallStatus.wallPos i){
		bool legal = true;
		bool c = false;   //critical
		switch(i){
		case WallStatus.wallPos.Right:
			legal = xr >= 0.07f;
			c = xr <= 0.28f && legal; 
			break;
		case WallStatus.wallPos.Left:
			legal = xl >= 0.07f;
			c = xl <= 0.28f && legal;
			break;
		case WallStatus.wallPos.Back:
			legal = zr >= 0.07f;
			c = zr <= 0.28f && legal;
			break;
		case WallStatus.wallPos.Front:
			legal = zl >= 0.07f;
			c = zl <= 0.28f && legal;
			break;
		case WallStatus.wallPos.Splitx:
			legal = xr >= 0.14f && xl >= 0.14f;
			break;
		case WallStatus.wallPos.Splitz:
			legal = zr >= 0.14f && zl >= 0.14f;
			break;
		default:
			throw new UnityException ("Incorrect wallpos");
			break;
		}
		if (c) {
			this.gameObject.GetComponentInChildren<Wireframe> ().ColorInnerVertices (i);
		}
		return legal;
	}

	public WallStatus.wallPos GetHitSide(Vector3 p){
		if (rbManager.getposCount () == 0 || rbManager.getposCount () == 2) {
			if (p.x > this.gameObject.transform.position.x + 0.105f) {
				return WallStatus.wallPos.Right;
			} else if (p.x < this.gameObject.transform.position.x - 0.105f) {
				return WallStatus.wallPos.Left;
			} else {
				return WallStatus.wallPos.Splitx;
			}
		} else {
			if (p.z > this.gameObject.transform.position.z + 0.105f) {
				return WallStatus.wallPos.Back;
			} else if (p.z < this.gameObject.transform.position.z - 0.105f) {
				return WallStatus.wallPos.Front;
			} else {
				return WallStatus.wallPos.Splitz;
			}
		}
	}

	public float GetVolume(){
		return ((xr + xl)*(zr + zl));
	}
}
