using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircle : MonoBehaviour
{
    public LineRenderer circleRenderer;

    public Transform playerTransform;

    private float xOffset, yOffset;
    // Start is called before the first frame update
    void Start()
    {
        yOffset = Mathf.Floor(playerTransform.position.y);
        xOffset = Mathf.Floor(playerTransform.position.x);
        CircleDrawer(100, 1);
    }

    // Update is called once per frame


    void CircleDrawer(int steps, float radius)
    {
        circleRenderer.positionCount = steps;

        for(int curStep = 0; curStep < steps; curStep++)
        {
            float circumferenceProgress = (float)curStep / (steps-1);

            float curRadian = circumferenceProgress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(curRadian);
            float yScaled = Mathf.Sin(curRadian);

            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 currentPosition = new Vector3(x + xOffset, y + yOffset, 0);

            circleRenderer.SetPosition(curStep, currentPosition);
        }
    }
}
