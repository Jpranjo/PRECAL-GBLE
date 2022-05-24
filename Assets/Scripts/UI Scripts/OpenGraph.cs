using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenGraph : MonoBehaviour
{
    public GameObject graphingTool;
    [SerializeField] private GameObject sliderManager;
    public Text buttonText;
    private bool toolOpen = false;

    public void OpenGraphingTool()
    {
        if (!toolOpen)
        {
            graphingTool.SetActive(true);
            buttonText.text = "Close Tool";
            
        }
        else
        {
            graphingTool.SetActive(false);
            buttonText.text = "Open Tool";
            sliderManager.GetComponent<SliderActivation>().SetAllUnactive();
        }
        toolOpen = !toolOpen;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.I)){
            OpenGraphingTool();
        }
    }
}
