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
        if(sliderParabola.activeSelf){
            sliderParabola.SetActive(false);
            ResetSliders(sliderParabola);
        }
        if(sliderCircle.activeSelf){
            sliderCircle.SetActive(false);
            ResetSliders(sliderCircle);
        }
        if(sliderEllipse.activeSelf){
            sliderEllipse.SetActive(false);
             ResetSliders(sliderEllipse);
        }
        if(sliderHyperbola.activeSelf){
            sliderHyperbola.SetActive(false);
             ResetSliders(sliderHyperbola);
        }
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

}
