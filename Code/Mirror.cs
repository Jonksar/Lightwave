using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : CLightInteractive
{

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

    public void Interact(Vector2 origin, RaycastHit2D hit)
    {
        Vector2 laserDirection = Vector3.Reflect(origin, hit.normal);
        DrawLaser(hit.point, laserDirection);
    }
}
