using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CLightInteractive: MonoBehaviour
{
    private LineRenderer lineRenderer;

    public void SetRenderer(LineRenderer renderer)
    {
        lineRenderer = renderer;
    }

    public LineRenderer GetRenderer()
    {
        if (lineRenderer == null)
        {
            SetRenderer(gameObject.AddComponent<LineRenderer>());
        }
        return lineRenderer;
    }

    public void DrawLaser(Vector2 origin, Vector2 direction)
    {
        LineRenderer renderer = GetRenderer();

        int vertexes = lineRenderer.numPositions;
        renderer.numPositions = vertexes + 1;
        renderer.SetPosition(vertexes, transform.position);

        vertexes += 1;
        renderer.numPositions = vertexes + 1;

        RaycastHit2D hit = Physics2D.Raycast(origin, direction);
        if (hit)
        {
            Debug.DrawLine(origin, hit.point);
            renderer.SetPosition(vertexes, hit.point);
            LightInteractive target = hit.collider.GetComponent<LightInteractive>();
            if (target != null)
            {
                target.Interact(transform.position, hit);
            }
            Debug.Log(hit.collider.name);
        }
        else
        {
            renderer.SetPosition(vertexes, origin + (direction.normalized * 10000));
            Debug.Log("lõpmatu");
        }
    }
}

interface LightInteractive {
    void Interact(Vector2 origin, RaycastHit2D hit);
}
