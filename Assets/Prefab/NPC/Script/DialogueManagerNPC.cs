using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.U2D.Animation;

public class DialogueManagerNPC : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Animator portraitAnimator;

    [Header ("Choices UI")]
    [SerializeField] private GameObject[] choices;

    [Header("Load Globals Ink File")]
    [SerializeField] private TextAsset globalsInkFile;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    public bool dialogueIsPlaying {get; private set;} //Variable is public but it cannot be set by other scripts.

    private static DialogueManagerNPC instance;
    private GameObject player;

    private bool makingDecision;

    private DialogueVariables dialogueVariables;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";

    private void Awake() {
        if(instance != null){
            Debug.LogWarning("More than one dialogue manager in scene");
        }
        instance = this;

        dialogueVariables =  new DialogueVariables(globalsInkFile);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public static DialogueManagerNPC GetInstance(){
        return instance;
    }

    private void Start() {
        makingDecision = false;
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        //get choices
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject choice in choices){
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

    }

    private void Update() {
        if(!dialogueIsPlaying){
            return;
        }
        if(Input.GetKeyDown(KeyCode.E) && !makingDecision){
            
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        player.GetComponent<PlayerMovement2>().DisableMovement();
        dialogueVariables.StartListening(currentStory);
        
        //Keep just incase, Commented out because first line of dialogue is skipped if included
       ContinueStory();
    }


    private IEnumerator ExitDialogueMode(){
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        //Debug.Log("EXIT DialogueMode");

        yield return new WaitForSeconds(0.2f);

        dialogueVariables.StopListening(currentStory);

        dialogueIsPlaying = false;
        player.GetComponent<PlayerMovement2>().EnableMovement();
    }

    private void ContinueStory(){
        if(currentStory.canContinue){
            string text = currentStory.Continue();
            dialogueText.text = text;

            DisplayChoices();
            
            HandleTags(currentStory.currentTags);
        }
        else{
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void HandleTags(List<string> currentTags){

        foreach(string tag in currentTags){
            string[] splitTag =tag.Split(':');
            if(splitTag.Length != 2){
                Debug.LogError("Tag could not be properly parsed " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();
            
            switch(tagKey){
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag is not being handled " + tag);
                    break;
            }
        }
    }


    private void DisplayChoices(){
        List<Choice> currentChoices = currentStory.currentChoices;

        //Disable the continue button while dialogue has a choice to be made
        if(currentChoices.Count > 0){
            makingDecision = true;
        }


        //Defensive Check if the UI can support the number of choices given 
        if(currentChoices.Count > choices.Length){
            Debug.LogError("More choices given than the UI can support");
        }

        int index = 0;

        //Enable and initialize the choices

        foreach(Choice choice in currentChoices){
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        //go through the rest of choices the ui can support and hide them
        for (int i = index; i < choices.Length; i++){
            choices[i].gameObject.SetActive(false);
        }
        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice(){
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    private IEnumerator MakeChoice2(){
        ContinueStory();
        yield return new WaitForSeconds(0.2f);
        makingDecision = false;
       
    }

    public void MakeChoice(int choiceIndex){
        currentStory.ChooseChoiceIndex(choiceIndex);
        StartCoroutine(MakeChoice2());
        
    }


    public Ink.Runtime.Object GetVariableState(string variableName){
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if(variableValue == null){
            Debug.LogWarning("Ink variable is null: " + variableName);
        }
        return variableValue;
    }

    public void SetVariableState(string variableName, string value){
            LoadStory();
            currentStory.variablesState[variableName] = value;
            dialogueVariables.StopListening(currentStory);
    }

    private void LoadStory(){
        currentStory = new Story(globalsInkFile.text);
        dialogueVariables.StartListening(currentStory);
    }
}
