using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollower : MonoBehaviour
{
    // ###############################################
    //             NAME : HongSW                      
    //             MAIL : gkenfktm@gmail.com         
    // ###############################################

    public Transform Player;
    private Vector3 _cameraOffset;

    [Range(0.01f, 1)]
    public float Smoothness = 0.5f;
    
    
    void Start()
    {
        _cameraOffset = transform.position - Player.position;
    }

    private void Update()
    {
        Vector3 newPos = Player.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, Smoothness);
    }
}
