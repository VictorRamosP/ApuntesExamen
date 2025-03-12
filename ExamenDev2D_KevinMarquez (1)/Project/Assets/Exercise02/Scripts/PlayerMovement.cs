using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 0.1f;

    private float _horizontal;
    private float _vertical;
    private bool _canMove;

    private void OnEnable()
    {
        // TODO: Subscribe to GameManager Actions
    }

    private void OnDisable()
    {
        // TODO: Unsubscribe from GameManager Actions
    }

    private void OnGameFinished(DeathCause obj)
    {
        _canMove = false;
    }

    private void OnGameStarted()
    {
        _canMove = true;
    }

    void Update()
    {
        GetInputs();
        Move();
    }   

    private void GetInputs()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        if (!_canMove) return;

        Vector2 velocity = new Vector2();
        velocity.x = _horizontal * Speed * Time.deltaTime;
        velocity.y = _vertical * Speed * Time.deltaTime;

        transform.Translate(velocity);
    }
}
