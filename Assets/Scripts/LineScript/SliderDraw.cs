using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderDraw : MonoBehaviour
{
    public GameObject line;
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;

    private LineRenderer lineRenderer2; //For Hyperbola

    //Static Variables
    private static int steps = 100;

    //Variables modified by sliders and player position
    public float centerX;
    public float centerY;
    private float h = 0;
    private float k = 0;
    private float a = 1;
    private float b = 1;
    private float r = 1;

    public void ResetVariables()
    {
        h = 0;
        k = 0;
        a = 1;
        b = 1;
        r = 1;
        lineRenderer = null;
        lineRenderer2 = null;
    } 
    public void SetEllipseVariables(){
        b = 2;
    }
    // Parabola Sliders
  
    public void Slider_ChangedH(float value)
    {
        h = value;
    }

    public void Slider_ChangedK(float value)
    {
        k = value;  
    }

    public void Slider_ChangedA(float value)
    {
        a = value;
    }
    public void Slider_Changed_CircleR(float value)
    {  
        r = value;
    }
    
    public void Slider_ChangedB(float value){
        b = value;
    }
    private void GraphNewParabola(){
                int position = 0;
        lineRenderer = line.GetComponent<LineRenderer>();
        edgeCollider = line.GetComponent<EdgeCollider2D>();
        lineRenderer.positionCount = 100;
        Vector2[] colliderPoints = new Vector2[100];
        Vector3[] points = new Vector3[100];
        
        for (float i = -10.0f; i <= 10.0f; i += 0.2f)
        {
            if (position < 100)
            {
                points[position] = new Vector3((i + h + centerX), (a * (i * i)) + k + centerY, 0);
                colliderPoints[position] = new Vector2( (i + h + centerX), (a * (i * i)) + k + centerY);

                position = position + 1;
            }
        }

        lineRenderer.SetPositions(points);
        try{
            edgeCollider.points = colliderPoints;
        } catch {
            Debug.Log("No EdgeCollider");
        }
    }

    private void GraphNewCircle(){
        lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.positionCount = steps;
        for(int curStep = 0; curStep < steps; curStep++)
        {
            float circumferenceProgress = (float)curStep / (steps-1);

            float curRadian = circumferenceProgress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(curRadian);
            float yScaled = Mathf.Sin(curRadian);

            float x = xScaled * r;
            float y = yScaled * r;

            Vector3 currentPosition = new Vector3(x + h + centerX, y + k + centerY, 0);

            lineRenderer.SetPosition(curStep, currentPosition);
        }
    }

    private void GraphNewEllipse(){
            lineRenderer = line.GetComponent<LineRenderer>();
            float angle = 0, dangle;
            dangle = 2 * Mathf.PI / steps;

            Vector3 position = new Vector3();
            Vector3[] positions;
            positions = new Vector3[steps + 2]; 
            lineRenderer.positionCount = steps;

            for (int i = 0; i < (steps + 1); i++, angle += dangle){
                position.x = (a * Mathf.Cos(angle)) + centerX + h;
                position.y = (b* Mathf.Sin(angle)) + centerY + k;
                positions[i] = position;
            }
            positions[steps-1] = positions[0];
            lineRenderer.SetPositions(positions);
    }

    private void GraphNewHyperbola(){
        //Vertical
        GameObject line1 = line.transform.GetChild(0).gameObject;
        GameObject line2 = line.transform.GetChild(1).gameObject;
        lineRenderer = line1.GetComponent<LineRenderer>();
        lineRenderer2 = line2.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 100;
        lineRenderer2.positionCount = 100;
        int position= 0;
        Vector3[] points_line1 = new Vector3[100];
        Vector3[] points_line2 = new Vector3[100];
        if(a != 0 && b != 0){
            for (float i = -5.0f; i <= 5.0f; i += 0.1f)
            {
                
                if (position < 100)
                {
                    float x =  Mathf.Sqrt((b*b) * ( (i *i ) / (a*a)));
                    float y = Mathf.Sqrt((a*a) * (1 + ( (i * i) / (b*b) )));

                    if(i < 0){
                        x = x*-1;
                    }
                    float line2X = x;
                    float line2Y = y;
                    x = x + centerX + h;
                    y = y + centerY + k;   
                    points_line1[position] = new Vector3(x,y,0);

                    x = (line2X * -1) + centerX + h;
                    y = (line2Y * -1) + centerY + k;

                    points_line2[position] = new Vector3(x,y,0);
                    
                    position = position + 1;
                }
            }
        }
        else{
            Debug.Log("Hi");
        }

        lineRenderer.SetPositions(points_line1);
        lineRenderer2.SetPositions(points_line2);
    }

    public void Slider_Changed_Update(string conic){
        if(conic == "Parabola")
            GraphNewParabola();
        if(conic == "Circle")
            GraphNewCircle();
        if(conic == "Ellipse")
            GraphNewEllipse();
        if(conic == "Hyperbola")
            GraphNewHyperbola();
    }
}
