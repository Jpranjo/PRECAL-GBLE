using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNPC : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Awake(){
        visualCue.SetActive(false);

    }

     private void Update() {
        //If player is in interactable range of NPC
        if(playerInRange){
            //Show VisualCue for interaction
            visualCue.SetActive(true);
            //Check if player pressed interact button "E"
            if(Input.GetKeyDown(KeyCode.E) && !DialogueManagerNPC.GetInstance().dialogueIsPlaying){
                DialogueManagerNPC.GetInstance().EnterDialogueMode(inkJSON);

            }

        }else{
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player"){
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player"){
            playerInRange = false;
        }
    }

    public void StartDialogWithNPC(){
         DialogueManagerNPC.GetInstance().EnterDialogueMode(inkJSON);
    }
}
