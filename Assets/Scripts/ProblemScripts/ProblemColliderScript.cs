using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProblemColliderScript : MonoBehaviour
{
    [SerializeField] private string problemName;
    [SerializeField] private DialogueTriggerNPC npcDialogueScript;
    
    [Header("Problm Components")]
    [SerializeField] private GameObject line;
    [SerializeField] private int lineType;
    [SerializeField] private Transform centerPoint;
    [SerializeField] private GameObject grid;
    [SerializeField] private GameObject smokeFX;
    [SerializeField] private GameObject oldObj;
    [SerializeField] private GameObject newObj;

    [Header("FX Parameters")]
    [SerializeField] private int fxType, numObjects;
    [SerializeField] private float width, height, radius;
    
    [Header("Problm Solution")]
    [SerializeField] private float h,k,a,b;
    private GameObject problemManager;
    private GameObject dialogueManager;
    private GameObject mainCamera;
    private bool solved = false;
    private bool inside = false;
    public float[] lineParams;
    private void Awake() {
        problemManager = GameObject.FindGameObjectWithTag("ProblemManager");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        dialogueManager = GameObject.FindGameObjectWithTag("DialogueManager");
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {

        if(!solved){
            DrawCircle_params checkScript = line.GetComponent<DrawCircle_params>();
            if(checkScript != null)
                lineParams = line.GetComponent<DrawCircle_params>().GetParams();
            DrawScript_Parabola_params checkScript2 = line.GetComponent<DrawScript_Parabola_params>();
            if(checkScript2 != null)
                lineParams = line.GetComponent<DrawScript_Parabola_params>().GetParams();
             DrawEllipse_params checkScript3 = line.GetComponent<DrawEllipse_params>();
             if(checkScript3 != null)
                 lineParams = line.GetComponent<DrawEllipse_params>().GetParams();
             DrawHyperbola_params checkScript4 = line.GetComponent<DrawHyperbola_params>();
             if(checkScript4 != null)
                 lineParams = line.GetComponent<DrawHyperbola_params>().GetParams();


            problemManager.GetComponent<ProblemManagerScript>().EnterProblem(lineType, line, centerPoint, lineParams, grid);
            mainCamera.GetComponent<FocusProblem>().SetFocus(centerPoint);
        }


        inside = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        problemManager.GetComponent<ProblemManagerScript>().ExitProblem();
        inside = false;
    }

    private void Update() {
        
        if(!solved && inside){
            GetParams();
            if((h <= lineParams[0]+.2 && h >= lineParams[0]-.2) && 
                (k <= lineParams[1]+.2 && k >= lineParams[1]-.2) && 
                (a <= lineParams[2]+.2 && a >= lineParams[2]-.2)
                ){
                    if(lineType >= 3 && (a <= lineParams[2]+.2 && a >= lineParams[2]-.2)){
                        Solved();
                    }
                    if(lineType < 3){
                        Solved();
                    }

            }
        }
    }

    private void Solved(){
        Debug.Log("Solved!");
        solved = true;
        problemManager.GetComponent<ProblemManagerScript>().openGraphManager.GetComponent<Story_OpenGraph>().OpenGraphingTool();
        if(fxType == 1)
            smokeFX.GetComponent<DisappearSCript>().SmokeCircle(numObjects, radius);
        else
            smokeFX.GetComponent<DisappearSCript>().SmokeRectangle(numObjects, width, height);
        problemManager.GetComponent<ProblemManagerScript>().ExitProblem();
        oldObj.SetActive(false);
        newObj.SetActive(true);
        line.SetActive(false);
        
        DialogueManagerNPC.GetInstance().SetVariableState(problemName + "_state", "Solved");
        npcDialogueScript.StartDialogWithNPC();
    }

    private void GetParams(){
        
       lineParams = problemManager.GetComponent<ProblemManagerScript>().GetVariables();
    }
}
