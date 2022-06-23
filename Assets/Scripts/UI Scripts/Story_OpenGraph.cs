using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story_OpenGraph : MonoBehaviour
{
    public GameObject graphingTool;
    [SerializeField] private GameObject sliderManager;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private Camera lineCamera;

    [Header("Tool UI")]
    [SerializeField] private RectTransform equationTransform;
    [SerializeField] private RectTransform sliderTransform;
    [SerializeField] private RectTransform buttonTransform;
    [SerializeField] private RectTransform visualTransform;

    [Header("Open Transforms")]
    [SerializeField] private RectTransform openEquationTransform;
    [SerializeField] private RectTransform openSliderTransform;
    [SerializeField] private RectTransform openButtonTransform;
    [SerializeField] private RectTransform openVisualTransform;
 
    [Header("Hidden Transforms")]
    [SerializeField] private RectTransform hiddenEquationTransform;
    [SerializeField] private RectTransform hiddenSliderTransform;
    [SerializeField] private RectTransform hiddenButtonTransform;
    [SerializeField] private RectTransform hiddenVisualTransform;

    [Header("Other")]
    [SerializeField] private Material shader;
    [SerializeField] private Material defaultShader;
    public Text buttonText;
    private bool toolOpen = false;

    private bool interactable = false;
    private bool uiMoving = false;
    private int curConic;
    private GameObject grid = null;
    

    private void Update() {

        if(Input.GetKeyDown(KeyCode.I) && interactable){
            OpenGraphingTool();
        }
    }

    private void Awake() {
        graphingTool.GetComponent<Button>().interactable = false;

    }

    public void OpenGraphingTool()
    {
        if (!toolOpen && !uiMoving)
        {
            // if(curConic == 0)
            //     sliderManager.GetComponent<SliderActivation>().SetActiveParabola();
            // else if(curConic == 1) {
            //      sliderManager.GetComponent<SliderActivation>().SetActiveCircle();
            // }
            // else if(curConic == 2) {
            //      sliderManager.GetComponent<SliderActivation>().SetActiveEllipse();
            // }
            // else if(curConic == 3) {
            //      sliderManager.GetComponent<SliderActivation>().SetActiveHyperbola();
            // }
            if(curConic < 2)
                sliderManager.GetComponent<SliderActivation>().Set3Active();
            else
                sliderManager.GetComponent<SliderActivation>().Set4Active();
            buttonText.text = "Close Tool";
            player.GetComponent<PlayerMovement2>().DisableMovement();
             
            uiMoving = true;

            mainCamera.GetComponent<FollowPlayer>().enabled = false;
            mainCamera.GetComponent<FocusProblem>().enabled = true;
            lineCamera.enabled = true;

            grid.GetComponent<SpriteRenderer>().enabled= true;

            //Hide BackGround
            GameObject[] backgroundObjs = GameObject.FindGameObjectsWithTag("Background");
            foreach (GameObject objs in backgroundObjs){
                objs.GetComponent<SpriteRenderer>().enabled = false;
            }

            //Apply Inverse shader to sprites
             GameObject[] charSprites = GameObject.FindGameObjectsWithTag("CharacterSprite");
             foreach (GameObject objs in charSprites){
                 objs.GetComponent<SpriteRenderer>().material = shader;
             }

            StartCoroutine(OpenUI_Slider());
            StartCoroutine(OpenUI_Equation());
            StartCoroutine(OpenUI_Button());
            if(curConic < 2)
                StartCoroutine(OpenUI_Visual());

            toolOpen = !toolOpen;
        }
        else
        {
            if(!uiMoving){
                uiMoving = true;
                StartCoroutine(CloseUI_Slider());
                StartCoroutine(CloseUI_Equation());
                StartCoroutine(CloseUI_Button());
                if(curConic < 2)
                    StartCoroutine(CloseUI_Visual());

                buttonText.text = "Open Tool";

                sliderManager.GetComponent<SliderActivation>().SetAllUnactive();    
                player.GetComponent<PlayerMovement2>().EnableMovement();

                mainCamera.GetComponent<FollowPlayer>().enabled = true;
                mainCamera.GetComponent<FocusProblem>().enabled = false;

                lineCamera.enabled = false;

                toolOpen = !toolOpen;
                GameObject[] backgroundObjs = GameObject.FindGameObjectsWithTag("Background");
                foreach (GameObject objs in backgroundObjs){
                    objs.GetComponent<SpriteRenderer>().enabled = true;
                }

            //Remove Inverse shader to sprites
             GameObject[] charSprites = GameObject.FindGameObjectsWithTag("CharacterSprite");
             foreach (GameObject objs in charSprites){
                 objs.GetComponent<SpriteRenderer>().material = defaultShader;
             }

                grid.GetComponent<SpriteRenderer>().enabled= false;
                
            }

            
        }
        
    }

    public void setCurConic(int type){
        curConic = type;
    }

    public void setPlane(GameObject plane){
        grid = plane;
    }

    public void AllowGraphing(bool b){
        interactable = b;
        graphingTool.GetComponent<Button>().interactable = b;
    }

    
        private IEnumerator OpenUI_Slider(){
        while(Vector3.Distance(sliderTransform.position, openSliderTransform.position) > 0.05f){
            sliderTransform.position = Vector3.Lerp(sliderTransform.position, openSliderTransform.position, 0.05f);
            uiMoving = true;
            yield return null;
        }
        uiMoving = false;
        yield return null;
        
        }

        private IEnumerator OpenUI_Equation(){
        while(Vector3.Distance(equationTransform.position, openEquationTransform.position) > 0.05f){
            equationTransform.position = Vector3.Lerp(equationTransform.position, openEquationTransform.position, 0.05f);
            uiMoving = true;
            yield return null;
        }
        uiMoving = false;
        yield return null;
        
    }

        private IEnumerator OpenUI_Button(){
        while(Vector3.Distance(buttonTransform.position, openButtonTransform.position) > 0.05f){
            buttonTransform.position = Vector3.Lerp(buttonTransform.position, openButtonTransform.position, 0.05f);
            uiMoving = true;
            yield return null;
        }
        uiMoving = false;
        yield return null;
        
    }

        private IEnumerator OpenUI_Visual(){
        while(Vector3.Distance(visualTransform.position, openVisualTransform.position) > 0.05f){
            visualTransform.position = Vector3.Lerp(visualTransform.position, openVisualTransform.position, 0.05f);
            uiMoving = true;
            yield return null;
        }
        uiMoving = false;
        yield return null;
        
    }

        private IEnumerator CloseUI_Slider(){
        while(Vector3.Distance(sliderTransform.position, hiddenSliderTransform.position) > 0.05f){
            sliderTransform.position = Vector3.Lerp(sliderTransform.position, hiddenSliderTransform.position, 0.05f);
            uiMoving = true;
            yield return null;
        }
        uiMoving = false;
        yield return null;
        
    }

        private IEnumerator CloseUI_Equation(){
        while(Vector3.Distance(equationTransform.position, hiddenEquationTransform.position) > 0.05f){
            equationTransform.position = Vector3.Lerp(equationTransform.position, hiddenEquationTransform.position, 0.05f);
            uiMoving = true;
            yield return null;
        }
        uiMoving = false;
        yield return null;
        
    }

        private IEnumerator CloseUI_Button(){
        while(Vector3.Distance(buttonTransform.position, hiddenButtonTransform.position) > 0.05f){
            buttonTransform.position = Vector3.Lerp(buttonTransform.position, hiddenButtonTransform.position, 0.05f);
            uiMoving = true;
            yield return null;
        }
        uiMoving = false;
        graphingTool.GetComponent<Button>().interactable = true;
        yield return null;
        
    }

        private IEnumerator CloseUI_Visual(){
        while(Vector3.Distance(visualTransform.position, hiddenVisualTransform.position) > 0.05f){
            visualTransform.position = Vector3.Lerp(visualTransform.position, hiddenVisualTransform.position, 0.05f);
            uiMoving = true;
            yield return null;
        }
        uiMoving = false;
        yield return null;
        
    }
        

}
