using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : CLightInteractive
{
    private LineRenderer lineRenderer;
    private bool firing = false;
    private List<LineSegment> oldPath;

    // Use this for initialization
    void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;

        oldPath = DrawLaser(transform.position, transform.up);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.S))
        {
            List<LineSegment> path = DrawLaser(transform.position, transform.up);
            bool pathChanged = PathChanged(path);

            if (!firing || pathChanged)
            {
                lineRenderer.numPositions = 0;
                lineRenderer.numPositions = path.Count * 2;
                int count = 0;
                foreach (LineSegment element in path)
                {
                    lineRenderer.SetPosition(count, element.start);
                    lineRenderer.SetPosition(count + 1, element.end);
                    count += 2;
                }
                lineRenderer.enabled = true;
                firing = true;
                oldPath = path;
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            lineRenderer.numPositions = 0;
            lineRenderer.enabled = false;
            firing = false;
        }
    }

    bool PathChanged(List<LineSegment> path)
    {
        if (oldPath.Count != path.Count)
        {
            return true;
        }

        int i = 0;
        foreach (LineSegment element in oldPath)
        {
            if (!element.CompareTo(path[i]))
            {
                return true;
            }
            i++;
        }
        return false;
    }
}
