using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass :  CLightInteractive, LightInteractive {

	public List<LineSegment> Interact(Vector2 origin, RaycastHit2D hit, int count)
	{
		Vector2 laserDirection = (Vector2) hit.point - origin;
		Debug.Log (laserDirection);
		return DrawLaser(hit.point, laserDirection.normalized, count - 1);
	}
}
