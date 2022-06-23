using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizationScript : MonoBehaviour
{
    [SerializeField] private GameObject plane;

    private float a,b;
    private int lineType;
    private float new_yPos;
    private Vector3 originalTransform;

    private void Start() {
        originalTransform = plane.transform.position;
    }
    public void SetVariables(float[] values){
        a = values[2];
        try{
            b = values[3];
        } catch{

        }
        
    }

    public void SetType(int type){
        lineType = type;
        if(type == 1)//Circle
        {
            
            plane.transform.eulerAngles= new Vector3(0f,0f, 0f);
        }
        else if(type == 0)//Parabola
        {
            plane.transform.eulerAngles = new Vector3(0f,0f, -62f);
        }
        UpdatePlane();
    }

    public void UpdateVariable(float value){
        a = Mathf.Round(value * 10.0f) *0.1f;
        UpdatePlane();
    }

    private void UpdatePlane(){
        //new_yPos = originalTransform.y + (a*0.19f);
        if(lineType == 1)//Circle
        {
            plane.transform.localPosition = new Vector3(0, (a*0.19f) ,0);
        }
        else if(lineType == 0)//Parabola
        {
            plane.transform.localPosition = new Vector3(0, (a*0.19f) ,0);;
        }
    }

}
