using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ObstaclesMovement : MonoBehaviour
{
    [SerializeField] private float mapSpeed = -0.0000000002f;
    
    private void FixedUpdate()
    {
        transform.position += new Vector3(mapSpeed*Time.deltaTime,0,0) ;
    }
}
