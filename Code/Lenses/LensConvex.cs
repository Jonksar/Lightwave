using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensConvex : Lens {
	

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
		return DrawLaser(hitPoint * (1 + colliderWidth), dirToFocal, maxLevels);
	}

}
