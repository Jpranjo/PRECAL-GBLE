using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private float cameraSpeed = 0.1f;

    private Vector3 minValues, maxValues;
    private GameObject bounds;

    public bool followingPlayer = true;

    void Start()
    {
        transform.position = player.position + cameraOffset;
        
    }

    private void Awake() {
        float n,s,e,w;
        bounds = GameObject.FindGameObjectWithTag("Border");
        n = bounds.transform.Find("N").gameObject.transform.position.y;
        s = bounds.transform.Find("S").gameObject.transform.position.y;
        e = bounds.transform.Find("E").gameObject.transform.position.x;
        w = bounds.transform.Find("W").gameObject.transform.position.x;
        minValues = new Vector3(w,s,-10);
        maxValues = new Vector3(e,n,-10);
    }

    void FixedUpdate()
    {
        float n,s,e,w;
        n = bounds.transform.Find("N").gameObject.transform.position.y;
        s = bounds.transform.Find("S").gameObject.transform.position.y;
        e = bounds.transform.Find("E").gameObject.transform.position.x;
        w = bounds.transform.Find("W").gameObject.transform.position.x;
        minValues = new Vector3(w,s,-10);
        maxValues = new Vector3(e,n,-10);
        Follow();
        
        
    }

    private void Follow()
    {
        if (followingPlayer)
        {
            Vector3 finalPosition = player.position + cameraOffset;

            ///
            Vector3 boundPosition = new Vector3(
                Mathf.Clamp(finalPosition.x, minValues.x, maxValues.x),
                Mathf.Clamp(finalPosition.y, minValues.y, maxValues.y),
                Mathf.Clamp(finalPosition.z, minValues.z, maxValues.z));

            Vector3 lerpPosition = Vector3.Lerp(transform.position, boundPosition, cameraSpeed);
            transform.position = lerpPosition;

        }
    }
}   
