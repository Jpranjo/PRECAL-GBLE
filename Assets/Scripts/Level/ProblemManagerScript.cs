using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemManagerScript : MonoBehaviour
{
    private GameObject sliderManager;
    private GameObject equationsManager;
    public GameObject openGraphManager;
     public GameObject visualizationManager;

    private void Awake() {
       openGraphManager = GameObject.FindGameObjectWithTag("GraphingTool");
       sliderManager = GameObject.FindGameObjectWithTag("SlidersManager");
       equationsManager = GameObject.FindGameObjectWithTag("EquationsManager");
       visualizationManager = GameObject.FindGameObjectWithTag("VisualizationManager");
    }

    public void EnterProblem(int conicType, GameObject line, Transform center, float[] objParams, GameObject grid){
        openGraphManager.GetComponent<Story_OpenGraph>().AllowGraphing(true);

        //This next section of code sends the problem details to each of the managers involved
        openGraphManager.GetComponent<Story_OpenGraph>().setPlane(grid);
        openGraphManager.GetComponent<Story_OpenGraph>().setCurConic(conicType);
        sliderManager.GetComponent<SliderDraw>().SetNewObject(line, conicType);
        sliderManager.GetComponent<SliderDraw>().SetVariables(objParams, center);
        sliderManager.GetComponent<SliderActivation>().SetVariables(objParams);
        equationsManager.GetComponent<EquationsScript>().SetVariables(objParams);
        equationsManager.GetComponent<EquationsScript>().SetType(conicType);
        visualizationManager.GetComponent<VisualizationScript>().SetVariables(objParams);
        visualizationManager.GetComponent<VisualizationScript>().SetType(conicType);

        //equationsManager.GetComponent<EquationsActivation>().SetActive(conicType);
    }
    
    public void ExitProblem(){
        openGraphManager.GetComponent<Story_OpenGraph>().AllowGraphing(false);
    }

    public float[] GetVariables(){
        return sliderManager.GetComponent<SliderDraw>().GetVariables();
    }
}
