using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserBeam : MonoBehaviour
{

	public int laserDistance;
	public LineRenderer mLineRenderer;
	public string bounceTag;
	public int maxBounce;
	private float timer = 0;
	int lengthOfLineRenderer = 10;
	// Use this for initialization

	LineRenderer line;
	int hitCount;
	Vector3 curPos;
	Vector3 curRot;

	void Start ()
	{
		hitCount = 1;
		line = transform.GetComponent<LineRenderer> ();
		line.startWidth = 0.02f;
		line.startColor = Color.red;
		Debug.Log (transform.forward);
	}

	// Update is called once per frame
	void Update ()
	{
		line.SetVertexCount (2);
		curPos = transform.position;
		curRot = transform.forward;
		line.SetPosition (0, transform.position);
		line.SetPosition (1, transform.forward);


		RaycastHit laserHit;
		if (Physics.Raycast (curPos, curRot, out laserHit)) {
			
		}


	}

}