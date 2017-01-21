using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CLightInteractive: MonoBehaviour
{
    public List<LineSegment> DrawLaser(Vector2 origin, Vector2 direction, int maxLevels = 100)
    {
        List<LineSegment> path = new List<LineSegment>();
        LineSegment segment = new LineSegment();
        path.Add(segment);
        segment.start = origin;

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, Mathf.Infinity);
        if (hit)
        {
            segment.end = hit.point;
            if (maxLevels > 0)
            {
                LightInteractive target = hit.collider.GetComponent<LightInteractive>();
                if (target != null)
                {
                    path.AddRange(target.Interact(transform.position, hit, maxLevels - 1));
                }
            }
        }
        else
        {
            segment.end = hit.point;
        }

        return path;
    }
}

public class LineSegment
{
    public Vector2 start;
    public Vector2 end;

    public bool CompareTo(LineSegment other)
    {
        return start == other.start && end == other.end;
    }
}

interface LightInteractive {
    List<LineSegment> Interact(Vector2 origin, RaycastHit2D hit, int maxLevels);
}
