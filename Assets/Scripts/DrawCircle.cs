using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircle : MonoBehaviour
{
    public LineRenderer circleRenderer;
    // Start is called before the first frame update
    void Start()
    {
        CircleDrawer(100, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

            Vector3 currentPosition = new Vector3(x, y, 0);

            circleRenderer.SetPosition(curStep, currentPosition);
        }
    }
}
