using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderActivation : MonoBehaviour
{
    [SerializeField] private GameObject sliderParabola;
    [SerializeField] private GameObject sliderCircle;
    [SerializeField] private GameObject sliderEllipse;
    [SerializeField] private GameObject sliderHyperbola;

    [SerializeField] private GameObject h;
    [SerializeField] private GameObject k;
    [SerializeField] private GameObject a;
    [SerializeField] private GameObject b;

    private float original_h, original_k, original_a, original_b;

    public void SetActiveParabola()
    {
        SetAllUnactive();
        sliderParabola.SetActive(true);
    }

    public void SetActiveCircle()
    {
        SetAllUnactive();
        sliderCircle.SetActive(true);
    }

    public void SetActiveEllipse()
    {
        SetAllUnactive();
        sliderEllipse.SetActive(true);
    }

    public void SetActiveHyperbola()
    {
        SetAllUnactive();
        sliderHyperbola.SetActive(true);
    }
    public void SetAllUnactive()
    {
        GetComponent<SliderDraw>().SetActive(false); //set false so that when resetting values on the sliders it does not affect the interactable object
        // if(sliderParabola.activeSelf){
        //     sliderParabola.SetActive(false);
        //     ResetSliders(sliderParabola);
        // }
        // if(sliderCircle.activeSelf){
        //     sliderCircle.SetActive(false);
        //     ResetSliders(sliderCircle);
        // }
        // if(sliderEllipse.activeSelf){
        //     sliderEllipse.SetActive(false);
        //      ResetSliders(sliderEllipse);
        // }
        // if(sliderHyperbola.activeSelf){
        //     sliderHyperbola.SetActive(false);
        //      ResetSliders(sliderHyperbola);
        // }
        h.GetComponent<Slider>().interactable = false;
        k.GetComponent<Slider>().interactable = false;
        a.GetComponent<Slider>().interactable = false;
        a.GetComponent<Slider>().interactable = false;

        GetComponent<SliderDraw>().SetActive(true);
    }

    private void ResetSliders(GameObject slider){
            for(int i = 0; i < slider.transform.childCount; i++ ){
                float valueSet = 0;
                GameObject sliderObject = slider.transform.GetChild(i).gameObject;
                if(sliderObject.CompareTag("Slider_A"))
                {
                    valueSet = 1;
                } else if(sliderObject.CompareTag("Slider_B")) {
                    valueSet = 2;
                }

                sliderObject.GetComponent<Slider>().value = valueSet;
            }
    }

    private void ResetSliders2(){
        h.GetComponent<Slider>().value = original_h;
        k.GetComponent<Slider>().value = original_k;
        a.GetComponent<Slider>().value = original_a;
        try{
            b.GetComponent<Slider>().value = original_b;
        } catch {
            Debug.Log("No B value");
        }
        
    }

    public void Set3Active(){
        h.GetComponent<Slider>().interactable = true;
        k.GetComponent<Slider>().interactable = true;
        a.GetComponent<Slider>().interactable = true;
        b.GetComponent<Slider>().interactable = false;
    }

    public void Set4Active(){
        h.GetComponent<Slider>().interactable = true;
        k.GetComponent<Slider>().interactable = true;
        a.GetComponent<Slider>().interactable = true;
        b.GetComponent<Slider>().interactable = true;
    }

    public void SetVariables(float[] value){
        original_h = value[0];
        original_k = value[1];
        original_a = value[2];
        try{
            original_b = value[3];
        } catch{
            //No B value set
        }
        ResetSliders2();
    }
}
