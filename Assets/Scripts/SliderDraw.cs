using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderDraw : MonoBehaviour
{
    public GameObject line;
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;
    private float h = 0;
    private float k = 0;
    private float a = 1;

    public void Slider_ChangedH(float value)
    {
        int position = 0;
        lineRenderer = line.GetComponent<LineRenderer>();
        edgeCollider = line.GetComponent<EdgeCollider2D>();
        lineRenderer.positionCount = 100;
        Vector2[] colliderPoints = new Vector2[100];
        Vector3[] points = new Vector3[100];

        h = value;
        for (float i = -10.0f; i <= 10.0f; i += 0.2f)
        {
            if (position < 100)
            {
                points[position] = new Vector3((i + value), (a * (i * i)) + k, 0);
                colliderPoints[position] = new Vector2( (i + value), (a * (i * i)) + k);

                position = position + 1;
            }
        }

        lineRenderer.SetPositions(points);
        edgeCollider.points = colliderPoints;
    }

    public void Slider_ChangedK(float value)
    {
        int position = 0;
        lineRenderer = line.GetComponent<LineRenderer>();
        edgeCollider = line.GetComponent<EdgeCollider2D>();
        lineRenderer.positionCount = 100;
        Vector2[] colliderPoints = new Vector2[100];
        Vector3[] points = new Vector3[100];
        k = value;
        for (float i = -10.0f; i <= 10.0f; i += 0.2f)
        {
            if (position < 100)
            {
                points[position] = new Vector3( (i + h), (a * (i * i)) + value, 0);
                colliderPoints[position] = new Vector2( (i + h), (a*(i * i)) + value);

                position = position + 1;
            }
        }

        lineRenderer.SetPositions(points);
        edgeCollider.points = colliderPoints;
    }

    public void Slider_ChangedA(float value)
    {
        int position = 0;
        lineRenderer = line.GetComponent<LineRenderer>();
        edgeCollider = line.GetComponent<EdgeCollider2D>();
        lineRenderer.positionCount = 100;
        Vector2[] colliderPoints = new Vector2[100];
        Vector3[] points = new Vector3[100];
        a = value;
        for (float i = -10.0f; i <= 10.0f; i += 0.2f)
        {
            if (position < 100)
            {
                points[position] = new Vector3((i + h), (value * (i * i)) + k, 0);
                colliderPoints[position] = new Vector2( (i + h), (value * (i * i)) + k);

                position = position + 1;
            }
        }

        lineRenderer.SetPositions(points);
        edgeCollider.points = colliderPoints;
    }

}
