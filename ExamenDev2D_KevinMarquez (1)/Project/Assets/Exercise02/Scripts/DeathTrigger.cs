using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField]
    DeathCause DeathCause;

    // TODO: Declare Action OnDeath

    private void OnEnable()
    {
        // TODO: Subscribe to GameManager Actions
    }

    private void OnDisable()
    {
        // TODO: Unsubscribe from GameManager Actions
    }

    private void OnGameStarted()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }

    private void OnGameFinished(DeathCause cause)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        DeathCause = cause;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // TODO: Invoke OnDeath Action with DeathCause parameter
        }
    }
}
