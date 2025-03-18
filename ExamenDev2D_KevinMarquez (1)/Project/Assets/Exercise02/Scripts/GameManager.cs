using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // TODO: Declare OnGameStarted and OnGameFinished Actions
    public static Action OnGameStarted;
    public static Action<DeathCause> OnGameFinished;

    private float _timer;
    private float _gameTime = 5.0f;   // Seconds to death
    private bool _running;
    private bool _dead;

    private void OnEnable()
    {
        // TODO: Subscribe to OnDeath Action
        DeathTrigger.OnDeath += EndGame;
    }

    private void OnDisable()
    {
        // TODO: Unsubscribe from OnDeath Action
        DeathTrigger.OnDeath += EndGame;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadGame();
        }
    }

    private void ReloadGame()
    {
        if (!_dead) return;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void StartGame()
    {
        if (_running) return; 

        _timer = 0;
        _running = true;

        // TODO: Invoke OnGameStarted Action
        OnGameStarted?.Invoke();
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (_timer < _gameTime)
        {
            _timer += Time.deltaTime;
            yield return null;
        }

        EndGame(DeathCause.TimeUp);
    }

    private void EndGame(DeathCause cause)
    {
        if (_dead) return;
        
        _dead = true;

        // TODO: Invoke OnGameFinished Action
        OnGameFinished?.Invoke(cause);
    }
}
