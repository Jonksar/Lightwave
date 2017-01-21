using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensConvex : Lens {
	

	protected override void Init() {
		// DO INIT STUFF IN HERE
		base.Init();
	}
		

	override protected Vector2 getFocalPoint() {
		float f = 1 / power;
		//float f = 1 / power * -1;
		return  transform.position +  transform.up * f;
	}

	private List<LineSegment> doConclave(Vector2 origin,RaycastHit2D raycastHit, int maxLevels = 100){
		Vector2 hit = raycastHit.point;
		//Vector2 normConclave = (hit-focalPoint).normalized;
		//lineRenderer.numPositions = 2;
		//lineRenderer.SetPosition(0, hit);

		Vector2 norm = (hit-focalPoint).normalized;
		//lineRenderer.SetPosition(1, hit+norm*1000);

		Vector2 projectedFocal = hit + norm;
		//DrawLaserBetween(origin, raycastHit.point, renderer);
		return DrawLaser(raycastHit.point * (1 + colliderWidth), projectedFocal, maxLevels);
	}

	override protected List<LineSegment> drawLine(Vector2 origin, RaycastHit2D raycastHit, int maxLevels = 100){
		/*Vector2 hit = raycastHit.point;
		lineRenderer.numPositions = 3;
		lineRenderer.SetPosition(0, hit);
		lineRenderer.SetPosition(1, focalPoint);

		Vector2 norm = (focalPoint-hit).normalized;
		lineRenderer.SetPosition (2, focalPoint+norm*1000);*/
		//Vector2 pointOnOtherSide = new Vector2(raycastHit.point *1.02); 
		//DrawLaserBetween(origin, raycastHit.point, renderer);
		return DrawLaser(raycastHit.point * (1 + colliderWidth), focalPoint, maxLevels);
	}

}
