using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamenPatrol : MonoBehaviour
{
    // Referencias a los puntos de patrulla
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    // Velocidad de movimiento del objeto
    public float Speed = 5.0f;

    // Objetivo actual al que se mueve el objeto
    private Vector3 target;

    private void Start()
    {
        // Inicializa la posición en el punto A y establece el objetivo en el punto B
        transform.position = pointA.position;
        target = pointB.position;
    }

    private void Update()
    {
        // Mueve el objeto hacia el objetivo actual
        MoveTowardsTarget();

        // Verifica si se debe cambiar la dirección de patrulla
        CheckPatrolSwitch();

        // Maneja la entrada del mouse para cambiar los puntos de patrulla
        HandleMouseInput();
    }

    private void MoveTowardsTarget()
    {
        // Mueve el objeto de manera gradual hacia el objetivo con una velocidad definida
        transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);
    }

    private void CheckPatrolSwitch()
    {
        // Si el objeto ha llegado al objetivo, cambia al otro punto de patrulla
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = target == pointA.position ? pointB.position : pointA.position;
        }
    }

    private void HandleMouseInput()
    {
        // Si el jugador presiona el botón izquierdo del mouse, mueve el punto A a la posición del mouse
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 newPos = GetMouseWorldPosition();
            pointA.position = newPos;
            target = pointA.position;
        }
        // Si el jugador presiona el botón derecho del mouse, mueve el punto B a la posición del mouse
        else if (Input.GetMouseButtonDown(1))
        {
            Vector3 newPos = GetMouseWorldPosition();
            pointB.position = newPos;
            target = pointB.position;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Obtiene la posición del mouse en la pantalla
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;

        // Convierte la posición de pantalla a coordenadas del mundo
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        // Devuelve la posición con el eje Z del objeto actual
        return new Vector3(worldPosition.x, worldPosition.y, transform.position.z);
    }
}