using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float JumpHeight;
    public float TimeToMaxHeight;

    private CollisionDetection _collisionDetection;
    private Rigidbody2D _rigidbody;

    // TODO: Add variables to track number of jumps
    private int _jumpsLeft = 4;
    private float _gravityMultiplier = 1f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collisionDetection = GetComponent<CollisionDetection>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryJump();
        }
    }

    void TryJump()
    {
        if (CanJump()) OnJump();
    }

    bool CanJump()
    {
        // TODO: Check also number of jumps
        //return _collisionDetection.IsGrounded; 
        return _jumpsLeft > 0;
    }

    public void OnJump()
    {
        SetGravity();
        var vel = new Vector2(_rigidbody.velocity.x, GetJumpForce());
        _rigidbody.velocity = vel;
        
        // TODO: Count number of jumps
        _jumpsLeft--;
    }

    private float GetJumpForce()
    {
        return (2 * JumpHeight / TimeToMaxHeight);
    }

    private void SetGravity()
    {
        // TODO: Scale gravity by jumps done
        var grav = 2 * JumpHeight * _gravityMultiplier / (TimeToMaxHeight * TimeToMaxHeight);
        _rigidbody.gravityScale = grav / 9.81f;
    }

    void OnLanding()
    {
        // TODO: Reset jumps and gravity
        _jumpsLeft=4;
        _gravityMultiplier = 1f;
    }
}
