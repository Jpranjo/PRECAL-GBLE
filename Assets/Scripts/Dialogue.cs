using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogue : MonoBehaviour
{
    public GameObject window;
    public GameObject indicator;
    public List<string> dialogues;
    public TMP_Text dialogueText;
    public float writingSpeed;

    private int index;
    private int charIndex;
    private bool started;
    private bool waitForNext;

    private void Awake() {
        ToggleIndicator(false);
        ToggleWindow(false);
    }
    public void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }

    //Start Dialogue
    public void StartDialogue()
    {
        if(started)
            return;
        //
        started = true;
        //Show Window
        ToggleWindow(true);
        //Hide Indicator
        ToggleIndicator(false);

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
        started = false;
        StopAllCoroutines();
        //Hide Window
        ToggleWindow(false);
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
        }
        else{
            //Next Sentence
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
                ToggleIndicator(true);
                EndDialogue();
            }
           
        }
    }
}
