using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensConcave : Lens {



	protected override void Init() {
		// DO INIT STUFF IN HERE
		base.Init();
	}


	override protected Vector2 getFocalPoint() {		
		float f = 1 / power * -1;
		return  transform.position +  transform.up * f;
	}

	override protected void drawLine(Vector2 origin,RaycastHit2D raycastHit, LineRenderer renderer){
		// for concave lens the focal point is on the wrong side, so we need to draw in the opposite dir
		Vector2 hit = raycastHit.point;
		Vector2 norm = (hit-focalPoint).normalized; // direction from focal point to hit
		Vector2 projection = hit + norm; // project in opposite dir

		//DrawLaserBetween(origin, raycastHit.point, renderer);
		DrawLaser(raycastHit.point * (1 + colliderWidth), projection, renderer);
	}

}
