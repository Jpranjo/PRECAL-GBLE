using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectConic : MonoBehaviour
{
    [Header("Conic Prefabs")]
    [SerializeField] private GameObject parabolaPrefab;
    [SerializeField] private GameObject circlePrefab;
    [SerializeField] private GameObject ellipsePrefab;
    [SerializeField] private GameObject hyperbolaPrefab;

    [Header("Other Fields")]
    [SerializeField] private GameObject spawnedObjectList;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject sliderManager;
    [SerializeField] private GameObject equationManager;
 
    private GameObject conicLine; 

    public void parabolaGraph()
    {
        setUpNewConic();
        conicLine = Instantiate(parabolaPrefab);
        conicLine.transform.parent = spawnedObjectList.transform;
        conicLine.GetComponent<DrawScript_Parabola>().playerTransform = playerTransform;
        sliderManager.GetComponent<SliderDraw>().line = conicLine;

        sliderManager.GetComponent<SliderActivation>().SetActiveParabola();
        equationManager.GetComponent<EquationsActivation>().SetActiveParabola();
    }

    public void circleGraph() 
    { 
        setUpNewConic();
        conicLine = Instantiate(circlePrefab);
        conicLine.transform.parent = spawnedObjectList.transform;
        conicLine.GetComponent<DrawCircle>().playerTransform = playerTransform;

        sliderManager.GetComponent<SliderDraw>().line = conicLine;

        sliderManager.GetComponent<SliderActivation>().SetActiveCircle();
        equationManager.GetComponent<EquationsActivation>().SetActiveCircle();
    }

    public void ellipseGraph(){
        setUpNewConic();
        conicLine = Instantiate(ellipsePrefab);
        conicLine.transform.parent = spawnedObjectList.transform;
        conicLine.GetComponent<DrawEllipse>().playerTransform = playerTransform;
        sliderManager.GetComponent<SliderDraw>().line = conicLine;

        sliderManager.GetComponent<SliderDraw>().SetEllipseVariables();

        sliderManager.GetComponent<SliderActivation>().SetActiveEllipse();
        equationManager.GetComponent<EquationsActivation>().SetActiveEllipse();
    }

    public void hyperbolaGraph(){
        setUpNewConic();
        conicLine = Instantiate(hyperbolaPrefab);
        conicLine.transform.parent = spawnedObjectList.transform;
        conicLine.GetComponent<DrawHyperbola>().playerTransform = playerTransform;

        sliderManager.GetComponent<SliderDraw>().line = conicLine;

        sliderManager.GetComponent<SliderActivation>().SetActiveHyperbola();
        equationManager.GetComponent<EquationsActivation>().SetActiveHyperbola();
    }

    private void setUpNewConic() 
    { 
        if(conicLine != null)
        {
            Destroy(conicLine);
        }
        sliderManager.GetComponent<SliderDraw>().centerX = Mathf.Round(Mathf.Floor(playerTransform.position.x));
        sliderManager.GetComponent<SliderDraw>().centerY =Mathf.Round(Mathf.Floor(playerTransform.position.y));
    }
}
