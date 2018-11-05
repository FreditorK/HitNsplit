using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(MeshFilter), typeof(MeshRenderer))]
public class Wireframe : MonoBehaviour {

	private Mesh mesh;
	private RotButtonManager rbManager;
	private Vector3[] extendedvertexset = new Vector3[48];
	private Vector3[] basicvertexset;
	public Color[] colors = new Color[48];
	private int[] left;
	private int[] right;
	private int[] innerright;
	private int[] innerleft;
	private float k = 0.035f;//x
	private float j = 0.035f;//y
	private float l = 0.035f;//z
	private float p = 0.001f;//offset

	void Awake() {
		mesh = GetComponent<MeshFilter> ().mesh;
		rbManager = FindObjectOfType<RotButtonManager> ();
	}

	void WireframeX(){
	    //middle
		extendedvertexset[28] =	new Vector3(k, basicvertexset[0].y, basicvertexset[0].z);//28
		extendedvertexset[29] =	new Vector3(k, basicvertexset[2].y, basicvertexset[2].z);//29
		extendedvertexset[30] =	new Vector3(k, basicvertexset[4].y, basicvertexset[4].z);//30
		extendedvertexset[31] =	new Vector3(k, basicvertexset[6].y, basicvertexset[6].z);//31

		extendedvertexset[32] =	new Vector3 (-k, basicvertexset [0].y, basicvertexset [0].z);//32
		extendedvertexset[33] =	new Vector3(-k, basicvertexset[2].y, basicvertexset[2].z);//33
		extendedvertexset[34] =	new Vector3(-k, basicvertexset[4].y, basicvertexset[4].z);//34
		extendedvertexset[35] =	new Vector3(-k, basicvertexset[6].y, basicvertexset[6].z);//35

		extendedvertexset[36] =	new Vector3 (2 * k, basicvertexset [0].y + j, basicvertexset [0].z);//36
		extendedvertexset[37] =	new Vector3(2*k, basicvertexset[2].y-j, basicvertexset[2].z);//37
		extendedvertexset[38] =	new Vector3(2*k, basicvertexset[4].y-j, basicvertexset[4].z);//38
		extendedvertexset[39] =	new Vector3(2*k, basicvertexset[6].y+j, basicvertexset[6].z);//39

		extendedvertexset[40] =	new Vector3 (-2 * k, basicvertexset [0].y + j, basicvertexset [0].z);//40
		extendedvertexset[41] =	new Vector3(-2*k, basicvertexset[2].y-j, basicvertexset[2].z);//41
		extendedvertexset[42] =	new Vector3(-2*k, basicvertexset[4].y-j, basicvertexset[4].z);//42
		extendedvertexset[43] =	new Vector3(-2*k, basicvertexset[6].y+j, basicvertexset[6].z);//43
		//middle top
		extendedvertexset[44] =	new Vector3(2*k, basicvertexset[2].y, basicvertexset[2].z-l);//44
		extendedvertexset[45] =	new Vector3(-2*k, basicvertexset[3].y, basicvertexset[3].z-l);//45
		extendedvertexset[46] =	new Vector3(2*k, basicvertexset[4].y, basicvertexset[4].z+l);//46
		extendedvertexset[47] =	new Vector3(-2*k, basicvertexset[5].y, basicvertexset[5].z+l);//47

		mesh.Clear ();

		mesh.vertices = extendedvertexset;

		mesh.triangles = new int[] {
			//back
			11, 3, 1,
			1, 9, 11,
			1, 32, 9,
			9, 32, 40,
			40, 32, 33,
			33, 41, 40,
			33, 3, 11,
			11, 41, 33,

			37, 29, 28,
			28, 36, 37,
			28, 0, 36,
			36, 0, 8,
			8, 0, 2,
			2, 10, 8,
			2, 29, 37,
			37, 10, 2,

			//front
			13, 5, 34,
			34, 42, 13,
			34, 35, 43,
			43, 42, 34,
			43, 35, 7,
			7, 15, 43,
			7, 5, 13,
			13, 15, 7,

			38, 30, 4,
			4, 12, 38,
			4, 6, 14,
			14, 12, 4,
			14, 6, 31,
			31, 39, 14,
			31, 30, 38,
			38, 39, 31,

			//top
			3, 33, 45,
			45, 25, 3,
			33, 34, 47,
			47, 45, 33,
			34, 5, 27,
			27, 47, 34,
			5, 3, 25,
			25, 27, 5,

			29, 2, 24,
			24, 44, 29,
			2, 4, 26,
			26, 24, 2,
			4, 30, 46,
			46, 26, 4,
			30, 29, 44,
			44, 46, 30,

			//right
			0, 16, 2,
			16, 17, 2,
			17, 18, 2,
			2, 18, 4,
			4, 18, 19,
			19, 6, 4,
			19, 16, 0,
			0, 6, 19,

			//left
			1, 3, 20,
			20, 3, 21,
			21, 3, 22,
			3, 5, 22,
			5, 23, 22,
			23, 5, 7,
			23, 1, 20,
			1, 23, 7
			
		};
	}

	void WireframeZ(){
		//middle
		extendedvertexset[28] =  new Vector3(basicvertexset[0].x, basicvertexset[0].y, l);//28
		extendedvertexset[29] = new Vector3(basicvertexset[1].x, basicvertexset[1].y, l);//29
		extendedvertexset[30] = new Vector3(basicvertexset[3].x, basicvertexset[3].y, l);//30
		extendedvertexset[31] = new Vector3(basicvertexset[2].x, basicvertexset[2].y, l);//31

		extendedvertexset[32] = new Vector3 (basicvertexset [0].x, basicvertexset [0].y, -l);//32
		extendedvertexset[33] = new Vector3(basicvertexset[1].x, basicvertexset[1].y, -l);//33
		extendedvertexset[34] = new Vector3(basicvertexset[3].x, basicvertexset[3].y, -l);//34
		extendedvertexset[35] = new Vector3(basicvertexset[2].x, basicvertexset[2].y, -l);//35

		extendedvertexset[36] = new Vector3 (basicvertexset [0].x, basicvertexset [0].y + j, 2 * l);//36
		extendedvertexset[37] = new Vector3(basicvertexset[1].x, basicvertexset[1].y+j, 2*l);//37
		extendedvertexset[38] = new Vector3(basicvertexset[3].x, basicvertexset[3].y-j, 2*l);//38
		extendedvertexset[39] = new Vector3(basicvertexset[2].x, basicvertexset[2].y-j, 2*l);//39

		extendedvertexset[40] = new Vector3 (basicvertexset [0].x, basicvertexset [0].y + j, -2 * l);//40
		extendedvertexset[41] = new Vector3(basicvertexset[1].x, basicvertexset[1].y+j, -2*l);//41
		extendedvertexset[42] = new Vector3(basicvertexset[3].x, basicvertexset[3].y-j, -2*l);//42
		extendedvertexset[43] = new Vector3(basicvertexset[2].x, basicvertexset[2].y-j, -2*l);//43
		//middle top
		extendedvertexset[44] = new Vector3(basicvertexset[2].x-k, basicvertexset[2].y, -2*l);//44
		extendedvertexset[45] = new Vector3(basicvertexset[4].x-k, basicvertexset[4].y, 2*l);//45
		extendedvertexset[46] = new Vector3(basicvertexset[5].x+k, basicvertexset[5].y, -2*l);//46
		extendedvertexset[47] = new Vector3(basicvertexset[3].x+k, basicvertexset[3].y, 2*l);//47

		mesh.Clear ();

		mesh.vertices = extendedvertexset;

		mesh.triangles = new int[] {

			//back
			0, 2, 8,
			8, 2, 10,
			10, 2, 11,
			11, 2, 3,
			3, 1, 11,
			11, 1, 9,
			9, 1, 0,
			0, 8, 9,

			//front
			6, 14, 4,
			4, 14, 12,
			12, 13, 4,
			4, 13, 5,
			5, 13, 15,
			15, 7, 5,
			15, 14, 6,
			6, 7, 15,

			//right
			18, 4, 35,
			35, 43, 18,
			35, 32, 43,
			43, 32, 40,
			40, 32, 6,
			6, 19, 40,
			6, 4, 19,
			19, 4, 18,

			31, 2, 17,
			17, 39, 31,
			2, 0, 17,
			17, 0, 16,
			0, 28, 16,
			28, 36, 16,
			28, 31, 39,
			39, 36, 28,

			//left
			5, 22, 34,
			22, 42, 34,
			34, 42, 41,
			41, 33, 34,
			41, 7, 33,
			41, 23, 7,
			23, 22, 5,
			5, 7, 23,

			30, 38, 21,
			21, 3, 30,
			21, 20, 3,
			3, 20, 1,
			20, 37, 1,
			1, 37, 29,
			37, 38, 30,
			30, 29, 37,

			//top
			5, 34, 46,
			46, 27, 5,
			5, 27, 26,
			26, 4, 5,
			26, 44, 4, 
			44, 35, 4,
			44, 46, 34,
			34, 35, 44,

			30, 47, 45,
			45, 31, 30,
			45, 24, 2, 
			2, 31, 45,
			2, 24, 25,
			25, 3, 2,
			3, 25, 47,
			47, 30, 3

		};
	}

	private void Setbasicvertexset(){

		basicvertexset = this.gameObject.transform.parent.GetComponent<MeshFilter> ().mesh.vertices;
		basicvertexset [0] += new Vector3(p, -p, p);
		basicvertexset [1] += new Vector3(-p, -p, p);
		basicvertexset [2] += new Vector3(p, p, p);
		basicvertexset [3] += new Vector3(-p, p, p);
		basicvertexset [4] += new Vector3(p, p, -p);
		basicvertexset [5] += new Vector3(-p, p, -p);
		basicvertexset [6] += new Vector3(p, -p, -p);
		basicvertexset [7] += new Vector3(-p, -p, -p);	
	}

	public void Rewire(){
		
		Setbasicvertexset ();
		
		extendedvertexset [0] =	basicvertexset [0];
		extendedvertexset [1] =	basicvertexset [1];
		extendedvertexset [2] =	basicvertexset [2];
		extendedvertexset [3] =	basicvertexset [3];
		extendedvertexset [4] =	basicvertexset [4];
		extendedvertexset [5] =	basicvertexset [5];
		extendedvertexset [6] =	basicvertexset [6];
		extendedvertexset [7] =	basicvertexset [7];
		//back
		extendedvertexset[8] =	basicvertexset [0] + new Vector3 (-k, j, 0);//8
		extendedvertexset[9] =	basicvertexset [1] + new Vector3 (k, j, 0);//9
		extendedvertexset[10] =	basicvertexset [2] + new Vector3 (-k, -j, 0);//10
		extendedvertexset[11] =	basicvertexset [3] + new Vector3 (k, -j, 0);//11
		//front
		extendedvertexset[12] =	basicvertexset [4] + new Vector3 (-k, -j, 0);//12
		extendedvertexset[13] =	basicvertexset [5] + new Vector3 (k, -j, 0);//13
		extendedvertexset[14] =	basicvertexset [6] + new Vector3 (-k, j, 0);//14
		extendedvertexset[15] =	basicvertexset [7] + new Vector3 (k, j, 0);//15
		//right
		extendedvertexset[16] =	basicvertexset [0] + new Vector3 (0, j, -l);//16
		extendedvertexset[17] =	basicvertexset [2] + new Vector3 (0, -j, -l);//17
		extendedvertexset[18] =	basicvertexset [4] + new Vector3 (0, -j, l);//18
		extendedvertexset[19] =	basicvertexset [6] + new Vector3 (0, j, l);//19
		//left
		extendedvertexset[20] =	basicvertexset [1] + new Vector3 (0, j, -l);//20
		extendedvertexset[21] =	basicvertexset [3] + new Vector3 (0, -j, -l);//21
		extendedvertexset[22] =	basicvertexset [5] + new Vector3 (0, -j, l);//22
		extendedvertexset[23] =	basicvertexset [7] + new Vector3 (0, j, l);//23
		//top
		extendedvertexset[24] =	basicvertexset [2] + new Vector3 (-k, 0, -l);//24
		extendedvertexset[25] =	basicvertexset [3] + new Vector3 (k, 0, -l);//25
		extendedvertexset[26] =	basicvertexset [4] + new Vector3 (-k, 0, l);//26
		extendedvertexset[27] =	basicvertexset [5] + new Vector3 (k, 0, l);//27

		if (rbManager.getposCount () == 0 || rbManager.getposCount () == 2) {
			WireframeX ();
		} else {
			WireframeZ ();
		}

		mesh.RecalculateNormals ();

		ResetColor ();
	}

	public void Shrink(WallStatus.wallPos hitSide){
		Setbasicvertexset ();
		switch (hitSide) {
		case WallStatus.wallPos.Back:
			extendedvertexset [0] =	basicvertexset [0];
			extendedvertexset [1] =	basicvertexset [1];
			extendedvertexset [2] =	basicvertexset [2];
			extendedvertexset [3] =	basicvertexset [3];
			//back
			extendedvertexset[8] =	basicvertexset [0] + new Vector3 (-k, j, 0);//8
			extendedvertexset[9] =	basicvertexset [1] + new Vector3 (k, j, 0);//9
			extendedvertexset[10] =	basicvertexset [2] + new Vector3 (-k, -j, 0);//10
			extendedvertexset[11] =	basicvertexset [3] + new Vector3 (k, -j, 0);//11
			//right
			extendedvertexset[16] =	basicvertexset [0] + new Vector3 (0, j, -l);//16
			extendedvertexset[17] =	basicvertexset [2] + new Vector3 (0, -j, -l);//17
			//left
			extendedvertexset[20] =	basicvertexset [1] + new Vector3 (0, j, -l);//20
			extendedvertexset[21] =	basicvertexset [3] + new Vector3 (0, -j, -l);//21
			//top
			extendedvertexset[24] =	basicvertexset [2] + new Vector3 (-k, 0, -l);//24
			extendedvertexset[25] =	basicvertexset [3] + new Vector3 (k, 0, -l);//25
			break;
		case WallStatus.wallPos.Front:
			extendedvertexset [4] =	basicvertexset [4];
			extendedvertexset [5] =	basicvertexset [5];
			extendedvertexset [6] =	basicvertexset [6];
			extendedvertexset [7] =	basicvertexset [7];
			//front
			extendedvertexset[12] =	basicvertexset [4] + new Vector3 (-k, -j, 0);//12
			extendedvertexset[13] =	basicvertexset [5] + new Vector3 (k, -j, 0);//13
			extendedvertexset[14] =	basicvertexset [6] + new Vector3 (-k, j, 0);//14
			extendedvertexset[15] =	basicvertexset [7] + new Vector3 (k, j, 0);//15
			//right
			extendedvertexset[18] =	basicvertexset [4] + new Vector3 (0, -j, l);//18
			extendedvertexset[19] =	basicvertexset [6] + new Vector3 (0, j, l);//19
			//left
			extendedvertexset[22] =	basicvertexset [5] + new Vector3 (0, -j, l);//22
			extendedvertexset[23] =	basicvertexset [7] + new Vector3 (0, j, l);//23
			//top
			extendedvertexset[26] =	basicvertexset [4] + new Vector3 (-k, 0, l);//26
			extendedvertexset[27] =	basicvertexset [5] + new Vector3 (k, 0, l);//27
			break;
		case WallStatus.wallPos.Left:
			extendedvertexset [1] =	basicvertexset [1];
			extendedvertexset [3] =	basicvertexset [3];
			extendedvertexset [5] =	basicvertexset [5];
			extendedvertexset [7] =	basicvertexset [7];
			//back
			extendedvertexset[9] =	basicvertexset [1] + new Vector3 (k, j, 0);//9
			extendedvertexset[11] =	basicvertexset [3] + new Vector3 (k, -j, 0);//11
			//front
			extendedvertexset[13] =	basicvertexset [5] + new Vector3 (k, -j, 0);//13
			extendedvertexset[15] =	basicvertexset [7] + new Vector3 (k, j, 0);//15
			//left
			extendedvertexset[20] =	basicvertexset [1] + new Vector3 (0, j, -l);//20
			extendedvertexset[21] =	basicvertexset [3] + new Vector3 (0, -j, -l);//21
			extendedvertexset[22] =	basicvertexset [5] + new Vector3 (0, -j, l);//22
			extendedvertexset[23] =	basicvertexset [7] + new Vector3 (0, j, l);//23
			//top
			extendedvertexset[25] =	basicvertexset [3] + new Vector3 (k, 0, -l);//25
			extendedvertexset[27] =	basicvertexset [5] + new Vector3 (k, 0, l);//27
			break;
		case WallStatus.wallPos.Right:
			extendedvertexset [0] =	basicvertexset [0];
			extendedvertexset [2] =	basicvertexset [2];
			extendedvertexset [4] =	basicvertexset [4];
			extendedvertexset [6] =	basicvertexset [6];
			//back
			extendedvertexset[8] =	basicvertexset [0] + new Vector3 (-k, j, 0);//8
			extendedvertexset[10] =	basicvertexset [2] + new Vector3 (-k, -j, 0);//10
			//front
			extendedvertexset[12] =	basicvertexset [4] + new Vector3 (-k, -j, 0);//12
			extendedvertexset[14] =	basicvertexset [6] + new Vector3 (-k, j, 0);//14
			//right
			extendedvertexset[16] =	basicvertexset [0] + new Vector3 (0, j, -l);//16
			extendedvertexset[17] =	basicvertexset [2] + new Vector3 (0, -j, -l);//17
			extendedvertexset[18] =	basicvertexset [4] + new Vector3 (0, -j, l);//18
			extendedvertexset[19] =	basicvertexset [6] + new Vector3 (0, j, l);//19
			//top
			extendedvertexset[24] =	basicvertexset [2] + new Vector3 (-k, 0, -l);//24
			extendedvertexset[26] =	basicvertexset [4] + new Vector3 (-k, 0, l);//26
			break;
		default:
			throw new UnityException ("Shrinkage problem with wireframe");
			break;
		}

		mesh.vertices = extendedvertexset;
	}

	public void Grow(int i){
		Setbasicvertexset ();
		switch (i) {
		case 0:
			extendedvertexset [0] =	basicvertexset [0];
			extendedvertexset [1] =	basicvertexset [1];
			extendedvertexset [2] =	basicvertexset [2];
			extendedvertexset [3] =	basicvertexset [3];
			//back
			extendedvertexset[8] =	basicvertexset [0] + new Vector3 (-k, j, 0);//8
			extendedvertexset[9] =	basicvertexset [1] + new Vector3 (k, j, 0);//9
			extendedvertexset[10] =	basicvertexset [2] + new Vector3 (-k, -j, 0);//10
			extendedvertexset[11] =	basicvertexset [3] + new Vector3 (k, -j, 0);//11
			//right
			extendedvertexset[16] =	basicvertexset [0] + new Vector3 (0, j, -l);//16
			extendedvertexset[17] =	basicvertexset [2] + new Vector3 (0, -j, -l);//17
			//left
			extendedvertexset[20] =	basicvertexset [1] + new Vector3 (0, j, -l);//20
			extendedvertexset[21] =	basicvertexset [3] + new Vector3 (0, -j, -l);//21
			//top
			extendedvertexset[24] =	basicvertexset [2] + new Vector3 (-k, 0, -l);//24
			extendedvertexset[25] =	basicvertexset [3] + new Vector3 (k, 0, -l);//25
			//middle top
			extendedvertexset[44] =	new Vector3(2*k, basicvertexset[2].y, basicvertexset[2].z-l);//44
			extendedvertexset[45] =	new Vector3(-2*k, basicvertexset[3].y, basicvertexset[3].z-l);//45
			//middle back
			extendedvertexset[28] =	new Vector3(k, basicvertexset[0].y, basicvertexset[0].z);//28
			extendedvertexset[29] =	new Vector3(k, basicvertexset[2].y, basicvertexset[2].z);//29
			extendedvertexset[32] =	new Vector3 (-k, basicvertexset [0].y, basicvertexset [0].z);//32
			extendedvertexset[33] =	new Vector3(-k, basicvertexset[2].y, basicvertexset[2].z);//33
			extendedvertexset[36] =	new Vector3 (2 * k, basicvertexset [0].y + j, basicvertexset [0].z);//36
			extendedvertexset[37] =	new Vector3(2*k, basicvertexset[2].y-j, basicvertexset[2].z);//37
			extendedvertexset[40] =	new Vector3 (-2 * k, basicvertexset [0].y + j, basicvertexset [0].z);//40
			extendedvertexset[41] =	new Vector3(-2*k, basicvertexset[2].y-j, basicvertexset[2].z);//41
			break;
		case 1:
			extendedvertexset [1] =	basicvertexset [1];
			extendedvertexset [3] =	basicvertexset [3];
			extendedvertexset [5] =	basicvertexset [5];
			extendedvertexset [7] =	basicvertexset [7];
			//left
			extendedvertexset[20] =	basicvertexset [1] + new Vector3 (0, j, -l);//20
			extendedvertexset[21] =	basicvertexset [3] + new Vector3 (0, -j, -l);//21
			extendedvertexset[22] =	basicvertexset [5] + new Vector3 (0, -j, l);//22
			extendedvertexset[23] =	basicvertexset [7] + new Vector3 (0, j, l);//23
			//back
			extendedvertexset[9] =	basicvertexset [1] + new Vector3 (k, j, 0);//9
			extendedvertexset[11] =	basicvertexset [3] + new Vector3 (k, -j, 0);//11
			//front
			extendedvertexset[13] =	basicvertexset [5] + new Vector3 (k, -j, 0);//13
			extendedvertexset[15] =	basicvertexset [7] + new Vector3 (k, j, 0);//15
			//top
			extendedvertexset[25] =	basicvertexset [3] + new Vector3 (k, 0, -l);//25
			extendedvertexset[27] =	basicvertexset [5] + new Vector3 (k, 0, l);//27
			//middle top
			extendedvertexset[46] = new Vector3(basicvertexset[5].x+k, basicvertexset[5].y, -2*l);//46
			extendedvertexset[47] = new Vector3(basicvertexset[3].x+k, basicvertexset[3].y, 2*l);//47
			//middle left
			extendedvertexset[29] = new Vector3(basicvertexset[1].x, basicvertexset[1].y, l);//29
			extendedvertexset[30] = new Vector3(basicvertexset[3].x, basicvertexset[3].y, l);//30
			extendedvertexset[37] = new Vector3(basicvertexset[1].x, basicvertexset[1].y+j, 2*l);//37
			extendedvertexset[38] = new Vector3(basicvertexset[3].x, basicvertexset[3].y-j, 2*l);//38
			extendedvertexset[33] = new Vector3(basicvertexset[1].x, basicvertexset[1].y, -l);//33
			extendedvertexset[34] = new Vector3(basicvertexset[3].x, basicvertexset[3].y, -l);//34
			extendedvertexset[41] = new Vector3(basicvertexset[1].x, basicvertexset[1].y+j, -2*l);//41
			extendedvertexset[42] = new Vector3(basicvertexset[3].x, basicvertexset[3].y-j, -2*l);//42
			break;
		case 2:
			extendedvertexset [4] =	basicvertexset [4];
			extendedvertexset [5] =	basicvertexset [5];
			extendedvertexset [6] =	basicvertexset [6];
			extendedvertexset [7] =	basicvertexset [7];
			//front
			extendedvertexset[12] =	basicvertexset [4] + new Vector3 (-k, -j, 0);//12
			extendedvertexset[13] =	basicvertexset [5] + new Vector3 (k, -j, 0);//13
			extendedvertexset[14] =	basicvertexset [6] + new Vector3 (-k, j, 0);//14
			extendedvertexset[15] =	basicvertexset [7] + new Vector3 (k, j, 0);//15
			//right
			extendedvertexset[18] =	basicvertexset [4] + new Vector3 (0, -j, l);//18
			extendedvertexset[19] =	basicvertexset [6] + new Vector3 (0, j, l);//19
			//left
			extendedvertexset[22] =	basicvertexset [5] + new Vector3 (0, -j, l);//22
			extendedvertexset[23] =	basicvertexset [7] + new Vector3 (0, j, l);//23
			//top
			extendedvertexset[26] =	basicvertexset [4] + new Vector3 (-k, 0, l);//26
			extendedvertexset[27] =	basicvertexset [5] + new Vector3 (k, 0, l);//27
			//middle top
			extendedvertexset[46] =	new Vector3(2*k, basicvertexset[4].y, basicvertexset[4].z+l);//46
			extendedvertexset[47] =	new Vector3(-2*k, basicvertexset[5].y, basicvertexset[5].z+l);//47
			//middle front
			extendedvertexset[30] =	new Vector3(k, basicvertexset[4].y, basicvertexset[4].z);//30
			extendedvertexset[31] =	new Vector3(k, basicvertexset[6].y, basicvertexset[6].z);//31
			extendedvertexset[34] =	new Vector3(-k, basicvertexset[4].y, basicvertexset[4].z);//34
			extendedvertexset[35] =	new Vector3(-k, basicvertexset[6].y, basicvertexset[6].z);//35
			extendedvertexset[38] =	new Vector3(2*k, basicvertexset[4].y-j, basicvertexset[4].z);//38
			extendedvertexset[39] =	new Vector3(2*k, basicvertexset[6].y+j, basicvertexset[6].z);//39
			extendedvertexset[42] =	new Vector3(-2*k, basicvertexset[4].y-j, basicvertexset[4].z);//42
			extendedvertexset[43] =	new Vector3(-2*k, basicvertexset[6].y+j, basicvertexset[6].z);//43
			break;
		case 3:
			extendedvertexset [0] =	basicvertexset [0];
			extendedvertexset [2] =	basicvertexset [2];
			extendedvertexset [4] =	basicvertexset [4];
			extendedvertexset [6] =	basicvertexset [6];
			//right
			extendedvertexset[16] =	basicvertexset [0] + new Vector3 (0, j, -l);//16
			extendedvertexset[17] =	basicvertexset [2] + new Vector3 (0, -j, -l);//17
			extendedvertexset[18] =	basicvertexset [4] + new Vector3 (0, -j, l);//18
			extendedvertexset[19] =	basicvertexset [6] + new Vector3 (0, j, l);//19
			//back
			extendedvertexset[8] =	basicvertexset [0] + new Vector3 (-k, j, 0);//8
			extendedvertexset[10] =	basicvertexset [2] + new Vector3 (-k, -j, 0);//10
			//front
			extendedvertexset[12] =	basicvertexset [4] + new Vector3 (-k, -j, 0);//12
			extendedvertexset[14] =	basicvertexset [6] + new Vector3 (-k, j, 0);//14
			//top
			extendedvertexset[24] =	basicvertexset [2] + new Vector3 (-k, 0, -l);//24
			extendedvertexset[26] =	basicvertexset [4] + new Vector3 (-k, 0, l);//26
			//middle top
			extendedvertexset[44] = new Vector3(basicvertexset[2].x-k, basicvertexset[2].y, -2*l);//44
			extendedvertexset[45] = new Vector3(basicvertexset[4].x-k, basicvertexset[4].y, 2*l);//45
			//middle right
			extendedvertexset[28] =  new Vector3(basicvertexset[0].x, basicvertexset[0].y, l);//28
			extendedvertexset[31] = new Vector3(basicvertexset[2].x, basicvertexset[2].y, l);//31
			extendedvertexset[36] = new Vector3 (basicvertexset [0].x, basicvertexset [0].y + j, 2 * l);//36
			extendedvertexset[39] = new Vector3(basicvertexset[2].x, basicvertexset[2].y-j, 2*l);//39
			extendedvertexset[32] = new Vector3 (basicvertexset [0].x, basicvertexset [0].y, -l);//32
			extendedvertexset[35] = new Vector3(basicvertexset[2].x, basicvertexset[2].y, -l);//35
			extendedvertexset[40] = new Vector3 (basicvertexset [0].x, basicvertexset [0].y + j, -2 * l);//40
			extendedvertexset[43] = new Vector3(basicvertexset[2].x, basicvertexset[2].y-j, -2*l);//43
			break;
		default:
			throw new UnityException ("Growing problem with wireframe");
			break;
		}
		mesh.vertices = extendedvertexset;
	}

	public void ResetColor(){
		print ("hi");
		for (int i = 0; i < 48; i++) {
			colors [i] = Color.cyan;
		}
		this.gameObject.transform.GetComponent<MeshFilter> ().mesh.colors = colors;
	}

	public void ColorInnerVertices(WallStatus.wallPos w){

		if (rbManager.getposCount () == 0 || rbManager.getposCount () == 2) {
			innerright = new int[] { 28, 29, 30, 31, 36, 37, 38, 39, 44, 46};
			innerleft = new int[] { 32, 33, 34, 35, 40, 41, 42, 43, 45, 47};
		} else {
			innerleft = new int[] { 28, 29, 30, 31, 36, 37, 38, 39, 45, 47};
			innerright = new int[] { 32, 33, 34, 35, 40, 41, 42, 43, 44, 46};
		}

		if (w == WallStatus.wallPos.Front || w == WallStatus.wallPos.Right) {
			foreach (int i in innerright) {
				colors [i] = Color.red;
			}
		} else if (w == WallStatus.wallPos.Back || w == WallStatus.wallPos.Left) {
			foreach (int i in innerleft) {
				colors [i] = Color.red;
			}
		} else {
			foreach (int i in innerright) {
				colors [i] = Color.red;
			}
			foreach (int i in innerleft) {
				colors [i] = Color.red;
			}
		}
		this.gameObject.transform.GetComponent<MeshFilter> ().mesh.colors = colors;	
		print (this.gameObject.transform.GetComponent<MeshFilter> ().mesh.colors[28].ToString());
	}

	public void ColorOuterVertices(WallStatus.wallPos w){
		
		switch (rbManager.getposCount ()) {
		case 0:
			left = new int[] { 1, 3, 5, 7, 9, 11, 13, 15, 20, 21, 22, 23, 25, 27 };
			right = new int[] { 0, 2, 4, 6, 8, 10, 12, 14, 16, 17, 18, 19, 24, 26 };
			break;
		case 1:
			left = new int[] { 4, 5, 6, 7, 12, 13, 14, 15, 18, 19, 22, 23, 26, 27 };
			right = new int[] { 0, 1, 2, 3, 8, 9, 10, 11, 16, 17, 20, 21, 24, 25 };
			break;
		case 2:
			right = new int[] { 1, 3, 5, 7, 9, 11, 13, 15, 20, 21, 22, 23, 25, 27 };
			left = new int[] { 0, 2, 4, 6, 8, 10, 12, 14, 16, 17, 18, 19, 24, 26 };
			break;
		case 3:
			right = new int[] { 4, 5, 6, 7, 12, 13, 14, 15, 18, 19, 22, 23, 26, 27 };
			left = new int[] { 0, 1, 2, 3, 8, 9, 10, 11, 16, 17, 20, 21, 24, 25 };
			break;
		}		
		switch (w) {
		case WallStatus.wallPos.Front:
			foreach (int i in left) {
				colors [i] = Color.cyan;
			}
			foreach (int i in right) {
				colors [i] = Color.cyan;
			}
			break;
		case WallStatus.wallPos.Left:
			foreach (int i in left) {
				colors [i] = Color.green;
			}
			break;
		case WallStatus.wallPos.Right:
			foreach (int i in right) {
				colors [i] = Color.green;
			}
			break;
		default:
			throw new UnityException ("Error while colouring");
			break;
		}
		this.gameObject.transform.GetComponent<MeshFilter> ().mesh.colors = colors;
	}
}
