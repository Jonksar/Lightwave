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

        RaycastHit2D hit = Physics2D.Raycast(origin, direction);

        if (hit)
        {
			float passThroughMagnitude = 1f;
			bool haveHit2 = false;

			while (true) {
				if (hit.point != origin) {
					break;
				} else {
					RaycastHit2D hit2 = Physics2D.Raycast (origin + direction.normalized * passThroughMagnitude, direction);
					hit = hit2;
					passThroughMagnitude += 1f;
				}
			}

            segment.end = hit.point;
            if (maxLevels > 0)
            {
                LightInteractive target = hit.collider.GetComponent<LightInteractive>();
                if (target != null)
                {
					path.AddRange(target.Interact(origin, hit, maxLevels - 1));
                }
            }
        }
        else
        {	
			
			segment.end = 10000f * direction;
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

	public void DrawLaserBetween(Vector2 origin, Vector2 destination, LineRenderer renderer)
	{
		int vertexes = renderer.numPositions;
		renderer.numPositions = vertexes + 2;
		renderer.SetPosition(vertexes, origin);
		renderer.SetPosition(vertexes+1, destination);
	}
}

interface LightInteractive {
    List<LineSegment> Interact(Vector2 origin, RaycastHit2D hit, int maxLevels);
}
