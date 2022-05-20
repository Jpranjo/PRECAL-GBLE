using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        sliderParabola.SetActive(false);
        sliderCircle.SetActive(false);
      //  sliderEllipse.SetActive(false);
      //  sliderHyperbola.SetActive(false);
    }

}
