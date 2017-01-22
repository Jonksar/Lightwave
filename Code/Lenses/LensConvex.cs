using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensConvex : Lens {

	public Transform LeftPivot;
	public Transform RightPivot; 

	// Use this for initialization
	void Start () {
		transform.position = LeftPivot.position + RightPivot.position / 2;
		transform.eulerAngles = new Vector3 (0f, 0f, Vector3.Angle(LeftPivot.position, RightPivot.position));
	}

	// Update is called once per frame
	void Update () {
		Vector3 vecDifference = LeftPivot.position - RightPivot.position;
		transform.eulerAngles = new Vector3 (0f, 0f, Mathf.Atan(vecDifference.y / vecDifference.x) * Mathf.Rad2Deg);
		transform.position = (LeftPivot.position + RightPivot.position) / 2;

	}

	protected override void Init() {
		// DO INIT STUFF IN HERE
		base.Init();
	}
		

	override protected float getFocalDist() {
		float f = 1 / power;
		return  f;
	}


	override protected List<LineSegment> drawLine(Vector2 hitPoint, Vector2 focalPoint, int maxLevels = 100){
		Vector2 dirToFocal = (focalPoint - hitPoint).normalized; // direction from focal point to hit
		Debug.DrawRay(hitPoint, dirToFocal, Color.yellow, 2000);
		return DrawLaser(hitPoint, dirToFocal, maxLevels);
	}

}
