using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CLightInteractive: MonoBehaviour
{
    public void DrawLaser(Vector2 origin, Vector2 direction, LineRenderer renderer)
    {
        int vertexes = renderer.numPositions;
        renderer.numPositions = vertexes + 1;
        renderer.SetPosition(vertexes, origin);

        vertexes += 1;
        //Debug.Log(vertexes);
        renderer.numPositions = vertexes + 1;

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, Mathf.Infinity);
        //Debug.Log(gameObject.name);
        //Debug.DrawRay(origin, direction);
        if (hit)
        {
            //Debug.DrawLine(origin, hit.point);
            //Debug.Log(hit.collider.name);
            renderer.SetPosition(vertexes, hit.point);
            if (vertexes < 100)
            {
                LightInteractive target = hit.collider.GetComponent<LightInteractive>();
                if (target != null)
                {
                    target.Interact(transform.position, hit, renderer);
                }
            }
        }
        else
        {
            renderer.SetPosition(vertexes, origin + (direction.normalized * 10000));
            //Debug.Log("lõpmatu");
        }
    }
}

interface LightInteractive {
    void Interact(Vector2 origin, RaycastHit2D hit, LineRenderer renderer);
}
