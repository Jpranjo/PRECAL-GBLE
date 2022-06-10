using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Prologue : MonoBehaviour
{
    [SerializeField] private GameObject window;
    [SerializeField] private LevelChanger levelChanger;
    public List<string> dialogues;
    public TMP_Text dialogueText;
    public float writingSpeed = 0.03f;

    private int index;
    private int charIndex;
    private bool started;
    private bool waitForNext = false;

    private void Awake() {
        dialogueText.text = "";
        StartCoroutine(Wait(1f));
        
    }
    public void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    private IEnumerator Wait(float time){
        yield return new WaitForSeconds(time);
        StartDialogue();
    }

    //Start Dialogue
    public void StartDialogue()
    {

        if(started)
            return;
        started = true;
        ToggleWindow(true);

        GetDialogue(0);
    }

    private void GetDialogue(int i)
    {
        //Start index at zero
        index = i;

        charIndex = 0;

        dialogueText.text = string.Empty;
        //Start Writing
        StartCoroutine(Writing());
    }


    //End Dialogue
    public void EndDialogue()
    {
        ToggleWindow(false);
        started = false;
        StopAllCoroutines();
        levelChanger.FadeToLevel("Tutorial");
        
    }

    //Writing logic

    IEnumerator Writing()
    {
        yield return new WaitForSeconds(writingSpeed);
        string curDialogue = dialogues[index];
        //Write the character
        dialogueText.text += curDialogue[charIndex];
        //Increase the character index
        charIndex++;
        //Check end of sentence
        if(charIndex < curDialogue.Length){
                //Wait X seconds
                yield return new WaitForSeconds(writingSpeed);
                //Restart process
                StartCoroutine(Writing());
                waitForNext = false;
        }
        else{
            //Next Sentence
            //Show Next Dialog Indicator
            waitForNext = true;
        }
       
    }

    private void  Update() {
        if(!started)
            return;

        if(waitForNext && Input.GetKeyDown(KeyCode.E))
        {
            waitForNext = false;
            index++;

            //Check if we are in the scope of dialogues list
            if(index < dialogues.Count){
                //Get Next Dialog
                 GetDialogue(index);
            }
            else{
                //End dialogue process
                EndDialogue();
            }
           
        }
    }
}
