using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueVariables
{
    public Dictionary<string, Ink.Runtime.Object> variables {get; private set;}

    public DialogueVariables(TextAsset globalsFilePath){
        Story globalVariableStory = new Story(globalsFilePath.text);

        variables = new Dictionary<string, Ink.Runtime.Object> ();
        foreach(string name in globalVariableStory.variablesState){
            Ink.Runtime.Object value = globalVariableStory.variablesState.GetVariableWithName(name);
            variables.Add(name,value);
            Debug.Log("Instantiate global dialogue var: " + name + " = " + value);
        }
    }
    public void StartListening(Story story){

        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story){
        story.variablesState.variableChangedEvent -= VariableChanged;
    }
    
    private void VariableChanged(string name, Ink.Runtime.Object value){
        //Debug.Log("varchanged "+ name +" = " + value );
        if (variables.ContainsKey(name)){
            variables.Remove(name);
            variables.Add(name, value);
        }
    }

    private void VariablesToStory(Story story){
        foreach(KeyValuePair<string, Ink.Runtime.Object> variable in variables){
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }

    private void Update() {
        
    }
}
