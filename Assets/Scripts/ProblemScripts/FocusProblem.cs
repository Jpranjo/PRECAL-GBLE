using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusProblem : MonoBehaviour
{
    private Transform problemFocus;
    private Vector3 cameraOffset;
    private void Awake() {
        gameObject.GetComponent<Camera>().orthographicSize =10f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCamera();
    }

    public void SetFocus(Transform focus){
        problemFocus = focus;
    }

    private void MoveCamera(){
        Vector3 lerpPosition = Vector3.Lerp(transform.position, new Vector3(problemFocus.position.x,problemFocus.position.y, -10f), 0.05f);
        transform.position = lerpPosition;
    }
}
