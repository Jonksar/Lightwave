using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Lens : CLightInteractive, LightInteractive  {
	public float power = 5.0f;
	public float angleError = 10.0f;
	public float focalDist;

	private LineRenderer lineRenderer;
	public float colliderWidth;

	// Use this for initialization
	void Start () {
		Init();
	}

	protected virtual void Init(){
		Debug.Log ("Initing");
		focalDist = getFocalDist();
		Debug.Log (transform.position);
		Debug.Log (transform.up);

		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.useWorldSpace = true;
		colliderWidth = GetComponent<BoxCollider2D>().size.y;
	}
		

	// Update is called once per frame
	void Update () {
		focalDist = getFocalDist();
	}


	public List<LineSegment> Interact(Vector2 origin, RaycastHit2D hit, int maxLevels = 100)
	{

		Vector2 originToLensMid = (Vector2)transform.position - origin;
		float l = focalDist/originToLensMid.magnitude;
		Vector2 originThroughMid = originToLensMid * (1 + l);
		Vector2 focalPoint = origin + originThroughMid;


		Debug.DrawRay(origin, originThroughMid, Color.red, 2000);
		Debug.DrawLine(hit.point, focalPoint, Color.green, 2000);

		return drawLine(hit.point * (1 + colliderWidth), focalPoint, maxLevels);
    }


	abstract protected float getFocalDist();

	abstract protected List<LineSegment> drawLine (Vector2 hitPoint, Vector2 focalPoint, int maxLevels = 100);

}
