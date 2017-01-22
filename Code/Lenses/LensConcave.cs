using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensConcave : Lens {



	protected override void Init() {
		// DO INIT STUFF IN HERE
		base.Init();
	}


	override protected float getFocalDist() {
		float f = 1 / power * -1;
		return  f;
	}

	override protected List<LineSegment> drawLine(Vector2 hitPoint, Vector2 focalPoint, int maxLevels = 100){
		Vector2 dir = hitPoint - focalPoint; // direction from focal point to hit
		Debug.DrawRay(hitPoint, dir, Color.yellow, 2000);

		return DrawLaser(hitPoint, dir, maxLevels);
	}

}
