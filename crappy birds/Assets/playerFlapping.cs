using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFlapping : MonoBehaviour
{

    private Rigidbody2D _rb;
    private const float JumpForce = 5f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Jump"))
        {
            _rb.velocity = new Vector2(0, JumpForce);
        }
        
    }
}
