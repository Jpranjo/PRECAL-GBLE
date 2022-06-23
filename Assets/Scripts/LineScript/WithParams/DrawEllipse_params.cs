using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawEllipse_params : MonoBehaviour
{



    [SerializeField] private LineRenderer lineRenderer;

    [SerializeField] private float h,k,a,b;

    private float xOffset, yOffset;
    public Transform playerTransform;

    private int divisions = 101; //number of divisions/positions of the line
    // Start is called before the first frame update
    void Start()
    {
        yOffset = Mathf.Floor(playerTransform.position.y);
        xOffset = Mathf.Floor(playerTransform.position.x);
        draw_ellipse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void draw_ellipse(){
            float angle = 0, dangle;
            dangle = 2 * Mathf.PI / divisions;

            Vector3 position = new Vector3();
            Vector3[] positions;
            positions = new Vector3[divisions + 2]; 
            lineRenderer.positionCount = divisions;

            for (int i = 0; i < (divisions + 1); i++, angle += dangle){
                 position.x = (a * Mathf.Cos(angle)) + xOffset;
                 position.y = (b* Mathf.Sin(angle)) + yOffset;
                positions[i] = position;
            }
            positions[divisions-1] = positions[0];
            lineRenderer.SetPositions(positions);
    }

    public float[] GetParams(){
        float[] ret = {h,k,a,b};
        return ret;
    }
}
