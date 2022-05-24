using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private float cameraSpeed = 0.1f;

    [SerializeField] private Vector3 minValues, maxValues;

    public bool followingPlayer = true;

    void Start()
    {
        transform.position = player.position + cameraOffset;
        
    }

    void FixedUpdate()
    {


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
