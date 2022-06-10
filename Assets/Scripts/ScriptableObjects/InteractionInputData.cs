using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "InteractionInputData", menuName = "InteractionSystem/InputData")] 
public class InteractionInputData : ScriptableObject
{
    private bool interactedPressedE;
    private bool interactedReleasedE;

    public bool InteractedPressedE{
       get => interactedPressedE;
       set => interactedPressedE = value;
    }

    public bool InteractedReleasedE{
        get => interactedReleasedE;
       set => interactedReleasedE = value;
    }

    public void Reset(){
        interactedPressedE = false;
        interactedReleasedE = false;
    }

}
