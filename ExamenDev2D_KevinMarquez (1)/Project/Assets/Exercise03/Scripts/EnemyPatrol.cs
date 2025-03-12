using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // TODO: Set patrolling points in the inspector
    public GameObject PatrolPointA;
    public GameObject PatrolPointB;

    public float Speed = 5.0f;
    
    private Vector3 direction;  // Direction AB or BA, normalized

    private void Start()
    {
        // TODO: Position enemy in patrol point A and set direction to start patrolling
        transform.position = PatrolPointA.transform.position;
        direction = (PatrolPointB.transform.position - PatrolPointA.transform.position).normalized;
    }

    private void Update()
    {
        // TODO: Translate enemy in the direction to point B
        transform.Translate(direction * Speed * Time.deltaTime);
        // TODO: Check if enemy has reached point A or B to change direction
        if (Vector3.Distance(transform.position, PatrolPointA.transform.position) < 0.1f)
        {
            direction = (PatrolPointB.transform.position - PatrolPointA.transform.position).normalized;
        }
        else if (Vector3.Distance(transform.position, PatrolPointB.transform.position) < 0.1f)
        {
            direction = (PatrolPointA.transform.position - PatrolPointB.transform.position).normalized;
        }
        // Change patrol points with mouse input
        // NOTE: When a new point is set enemy should to that point
        if (Input.GetMouseButtonDown(0))
        {
            // TODO: Update patrol point A with mouse position
            // NOTE: Screen mouse point must be converted to world point and only x-y coordinates considered
            transform.position = (PatrolPointA.transform.position + PatrolPointB.transform.position) / 2.0f;
            Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPoint.z = transform.position.z;
            PatrolPointA.transform.position = mouseWorldPoint;

            // TODO: Recalculate direction from player to new patrol point A
            direction = -(PatrolPointB.transform.position - PatrolPointA.transform.position).normalized;
            
        }
        else if (Input.GetMouseButtonDown(1))
        {
            // TODO: Update patrol point A with mouse position
            // NOTE: Screen mouse point must be converted to world point and only x-y coordinates considered
            transform.position = (PatrolPointA.transform.position + PatrolPointB.transform.position) / 2.0f;
            Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPoint.z = transform.position.z;
            PatrolPointB.transform.position = mouseWorldPoint;

            // TODO: Recalculate direction from player to new patrol point B
            direction = -(PatrolPointA.transform.position - PatrolPointB.transform.position).normalized;
        }
    }
}
