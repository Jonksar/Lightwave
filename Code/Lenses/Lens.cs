using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Lens : CLightInteractive, LightInteractive  {
	public float power = 5.0f;
	public float angleError = 10.0f;
	public Vector2 focalPoint;

	private LineRenderer lineRenderer;
	public float colliderWidth;

	// Use this for initialization
	void Start () {
		Init();
	}

	protected virtual void Init(){
		Debug.Log ("Initing");
		focalPoint = getFocalPoint();
		Debug.Log (transform.position);
		Debug.Log (transform.up);

		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.useWorldSpace = true;
		Debug.DrawLine(transform.position, focalPoint, Color.yellow, 2000);

		colliderWidth = GetComponent<BoxCollider2D>().size.y;
	}
		

	// Update is called once per frame
	void Update () {
		focalPoint = getFocalPoint();
	}


	public void Interact(Vector2 origin, RaycastHit2D hit, LineRenderer renderer)
	{
		Debug.Log ("Hit "+ transform.name);

		float angle = getLaserAngleFromNormal (hit);
		//allow small angle error
		if (angle < angleError) {
			//drawLine (origin, hit, renderer);
		} else {

		}
		Vector2 reflectVec = Vector2.Reflect(hit.point, hit.normal*-1);
		Debug.Log ("hit normal"+ hit.normal * -5);

		Debug.DrawLine(hit.point, hit.normal, Color.blue, 200);
		//DrawLaser(hit.point * (1 + colliderWidth), reflectVec, renderer);
	}


	abstract protected Vector2 getFocalPoint();

	abstract protected void drawLine (Vector2 origin, RaycastHit2D raycastHit, LineRenderer renderer);

	protected float getLaserAngleFromNormal(RaycastHit2D hit){
		Vector2 normalAtHit = hit.point - hit.normal;
		float angle = Vector2.Angle (normalAtHit, hit.point); 
		Debug.Log ("angle "+ angle);
		return angle;
	}
}
