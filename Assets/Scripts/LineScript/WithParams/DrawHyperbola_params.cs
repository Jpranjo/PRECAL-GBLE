using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawHyperbola_params : MonoBehaviour
{
    [SerializeField] private GameObject line1;
    [SerializeField] private GameObject line2;

    private LineRenderer lineRenderer1;
    private LineRenderer lineRenderer2;

    [SerializeField] private float h,k,a,b;

    private float xOffset, yOffset;
    [SerializeField] private int orientation;
    public Transform playerTransform;
    void Start()
    {
        yOffset = Mathf.Floor(playerTransform.position.y);
        xOffset = Mathf.Floor(playerTransform.position.x);
            VerticalHyperbola();

    }

    // Update is called once per frame
    private void HorizontalHyperbola(){  //Makes horizontal hyperbola )(
        lineRenderer1 = line1.GetComponent<LineRenderer>();
        lineRenderer2 = line2.GetComponent<LineRenderer>();
        lineRenderer1.positionCount = 100;
        lineRenderer2.positionCount = 100;
        int position= 0;
        Vector3[] points_line1 = new Vector3[100];
        Vector3[] points_line2 = new Vector3[100];
        for (float i = -5.0f; i <= 5.0f; i += 0.1f)
        {
            
            if (position < 100)
            {
                float y =  Mathf.Sqrt((b*b) * ( (i *i ) / (a*a)));
                float x = Mathf.Sqrt((a*a) * (1 + ( (i * i) / (b*b) )));
                if(i < 0){
                     x = x*-1;

                    points_line2[position] = new Vector3(x,y,0);
                    points_line1[position] = new Vector3((x*-1),(y*-1),0);
                }
                else{
                    points_line1[position] = new Vector3(x,y,0);
                    points_line2[position] = new Vector3((x*-1),(y*-1),0);
                } 
                 
                
                //colliderPoints[position] = new Vector2( (i + h + centerX), (a * (i * i)) + k + centerY);
                
                position = position + 1;
            }
        }

        lineRenderer1.SetPositions(points_line1);
        lineRenderer2.SetPositions(points_line2);
    }

    private void VerticalHyperbola(){
        lineRenderer1 = line1.GetComponent<LineRenderer>();
        lineRenderer2 = line2.GetComponent<LineRenderer>();
        lineRenderer1.positionCount = 100;
        lineRenderer2.positionCount = 100;
        int position= 0;
        Vector3[] points_line1 = new Vector3[100];
        Vector3[] points_line2 = new Vector3[100];
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
                x = x + xOffset;
                y = y + yOffset;   
                points_line1[position] = new Vector3(x,y,0);

                x = (line2X * -1) + xOffset;
                y = (line2Y * -1) + yOffset;

                points_line2[position] = new Vector3(x,y,0);
                
                position = position + 1;
            }
        }

        lineRenderer1.SetPositions(points_line1);
        lineRenderer2.SetPositions(points_line2);
    }

    public float[] GetParams(){
        float[] ret = {h,k,a,b};
        return ret;
    }
}
