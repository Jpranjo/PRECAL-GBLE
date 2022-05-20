using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private float cameraSpeed = 0.1f;
    public bool followingPlayer = true;

    void Start()
    {
        transform.position = player.position + cameraOffset;
        
    }

    void FixedUpdate()
    {
        if (followingPlayer)
        {
            Vector3 finalPosition = player.position + cameraOffset;
            Vector3 lerpPosition = Vector3.Lerp(transform.position, finalPosition, cameraSpeed);
            transform.position = lerpPosition;
            
        }
        
    }
}
