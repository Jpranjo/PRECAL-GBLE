using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircle_params : MonoBehaviour
{
    [Header("Line Renderer")]
    [SerializeField] private LineRenderer circleRenderer;

    [Header("Center Point")]
    [SerializeField] private Transform playerTransform;

    [Header("Premade Params")]
    [SerializeField] private float h,k,a;

    private float xOffset, yOffset;
    // Start is called before the first frame update
    void Start()
    {
        yOffset = playerTransform.position.y;
        xOffset = playerTransform.position.x;
        CircleDrawer(100, a);
    }

    public float[] GetParams(){
        float[] retParams ={h ,k ,a };
        return retParams;
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

            Vector3 currentPosition = new Vector3(x + xOffset + h, y + yOffset + k, 0);

            circleRenderer.SetPosition(curStep, currentPosition);
        }
    }
}
