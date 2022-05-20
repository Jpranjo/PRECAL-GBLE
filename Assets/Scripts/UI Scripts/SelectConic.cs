using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectConic : MonoBehaviour
{
    [SerializeField] private GameObject parabolaPrefab;
    [SerializeField] private GameObject circlePrefab;
    [SerializeField] private GameObject parentObject;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject sliderManager;
 
    private GameObject conicLine; 

    public void parabolaGraph()
    {
        setUpNewConic();
        conicLine = Instantiate(parabolaPrefab);
        conicLine.transform.parent = parentObject.transform;
        conicLine.GetComponent<DrawScript>().playerTransform = playerTransform;
        sliderManager.GetComponent<SliderDraw>().line = conicLine;

        sliderManager.GetComponent<SliderActivation>().SetActiveParabola();
    }

    public void circleGraph() 
    { 
    }

    private void setUpNewConic() 
    { 
        if(conicLine != null)
        {
            Destroy(conicLine);
        }
        sliderManager.GetComponent<SliderDraw>().centerX = playerTransform.position.x;
        sliderManager.GetComponent<SliderDraw>().centerY = playerTransform.position.y;
    }
}
