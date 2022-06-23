using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquationsActivation : MonoBehaviour
{
    [SerializeField] private GameObject equationParabola;
    [SerializeField] private GameObject equationCircle;
    [SerializeField] private GameObject equationEllipse;
    [SerializeField] private GameObject equationHyperbola;


    public void SetActiveParabola()
    {
        SetAllUnactive();
        equationParabola.SetActive(true);
    }

    public void SetActiveCircle()
    {
        SetAllUnactive();
        equationCircle.SetActive(true);
    }

    public void SetActiveEllipse()
    {
        SetAllUnactive();
        equationEllipse.SetActive(true);
    }

    public void SetActiveHyperbola()
    {
        SetAllUnactive();
        equationHyperbola.SetActive(true);
    }

    public void SetActive(int type){
        if(type == 0 )
            SetActiveParabola();
        else if(type == 1)
            SetActiveCircle();
        else if(type == 2)
            SetActiveEllipse();
        else if(type == 3)
            SetActiveHyperbola();
    }
    public void SetAllUnactive()
    {
        if(equationParabola.activeSelf){
            equationParabola.SetActive(false);
        }
        if(equationCircle.activeSelf){
            equationCircle.SetActive(false);
        }
        if(equationEllipse.activeSelf){
            equationEllipse.SetActive(false);
        }
        if(equationHyperbola.activeSelf){
            equationHyperbola.SetActive(false);
        }
    }

}
