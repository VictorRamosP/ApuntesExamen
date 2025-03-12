using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameText : MonoBehaviour
{
    TextMeshPro textDeath;
    TextMeshPro textInfo;

    private void OnEnable()
    {
        // TODO: Subscribe to GameManager Actions
    }

    private void OnDisable()
    {
        // TODO: Unsubscribe from GameManager Actions
    }

    void Start()
    {
        textDeath = GameObject.Find("TextDeath").GetComponent<TextMeshPro>();
        textInfo = GameObject.Find("TextInfo").GetComponent<TextMeshPro>();
        textInfo.text = "Fase pre-juego: Pulsa ESPACIO para empezar";
    }

    private void OnGameStarted()
    {
        textInfo.text = "Fase juego: El jugador esta vivo";
    }

    private void OnGameFinished(DeathCause cause)
    {
        textInfo.text = "Fase post-juego: El jugador ha muerto\nPulsa R para reiniciar";
        textDeath.text = "Causa muerte: " + cause.ToString();
    }
}
