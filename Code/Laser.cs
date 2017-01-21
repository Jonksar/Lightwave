using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : CLightInteractive
{

    private LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        SetRenderer(lineRenderer);
        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;
	}
	
	// Update is called once per frame
	void Update () {
        
        //if (hit)
        //{
        //    LightInteractive target = hit.collider.GetComponent<LightInteractive>();
        //    if (target != null)
        //    {
        //        target.Interact(transform.position, hit);
        //    }
        //}
        //Debug.DrawLine(transform.position, hit.point);
        //laserHit.position = hit.point;
        //lineRenderer.SetPosition(0, transform.position);
        //lineRenderer.SetPosition(1, laserHit.position);
        //lineRenderer.enabled = true;
        if (Input.GetKey(KeyCode.S))
        {
            DrawLaser(transform.position, transform.up);
            lineRenderer.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            lineRenderer.numPositions = 0;
            lineRenderer.enabled = false;
        }
    }

    //void DrawLaser()
    //{
    //    int laserReflected = 1; //How many times it got reflected
    //    int vertexCounter = 1; //How many line segments are there
    //    bool loopActive = true; //Is the reflecting loop active?
    //    Vector2 laserDirection = transform.up; //direction of the next laser
    //    Vector2 lastLaserPosition = transform.position; //origin of the next laser

    //    lineRenderer.numPositions = 1;
    //    lineRenderer.SetPosition(0, transform.position);
    //    int count = 0;

    //    while (loopActive)
    //    {
    //        Debug.Log("Raycast");
    //        RaycastHit2D hit = Physics2D.Raycast(lastLaserPosition, laserDirection);

    //        if (hit)
    //        {
    //            Debug.DrawLine(lastLaserPosition, hit.point);
    //            laserReflected++;
    //            vertexCounter += 3;
    //            lineRenderer.numPositions = vertexCounter;
    //            lineRenderer.SetPosition(vertexCounter - 3, Vector3.MoveTowards(hit.point, lastLaserPosition, 0.01f));
    //            lineRenderer.SetPosition(vertexCounter - 2, hit.point);
    //            lineRenderer.SetPosition(vertexCounter - 1, hit.point);
    //            lastLaserPosition = hit.point;
    //            laserDirection = Vector3.Reflect(laserDirection, hit.normal);
    //            Debug.Log(hit.collider.name);
    //        }
    //        else
    //        {
    //            laserReflected++;
    //            vertexCounter++;
    //            lineRenderer.numPositions = vertexCounter;
    //            lineRenderer.SetPosition(vertexCounter - 1, lastLaserPosition + (laserDirection.normalized * 10000));

    //            loopActive = false;
    //            Debug.Log("lõpmatu");
    //        }
    //        if (count > 100)
    //        {
    //            loopActive = false;
    //        }
    //        count++;
    //    }
    //}
}
