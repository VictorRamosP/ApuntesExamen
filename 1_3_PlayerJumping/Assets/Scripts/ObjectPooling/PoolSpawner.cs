using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSpawner : MonoBehaviour
{
    //public Bullet BulletPrefab;       // Not needed here, managed by PoolManager.cs
    public Gradient ColorGradient;

    public bool Spawn;                  // Spawning enable

    public float SpawnTime = 1.0f;      // Spawn time in seconds
    public float RotationSpeed = 5;

    private float timeCounter = 0.0f;   // Time counter for next bullet spawn
    //private int counter = 0;            // Bullets counter

    private void Update()
    {
        // NEW: Using an objects pool, activate one bullet at a time

        // Rotate spawner gameobject
        transform.Rotate(new Vector3(0, 0, RotationSpeed * Time.deltaTime));

        if (Spawn)
        {
            timeCounter += Time.deltaTime;

            if (timeCounter > SpawnTime)
            {
                ActivateOneBullet();
                timeCounter = 0.0f;
            }
        }
    }

    void ActivateOneBullet()
    {
        // Activate one bullet object from the pool
        var bullet = PoolManager.GetObject();

        // WARNING: Make sure we got a valid object from pool!
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.SetActive(true);

            // Get a color based on its spawner rotation
            Color col = ColorGradient.Evaluate(transform.eulerAngles.z / 360f);

            // Init bullet with a velocity and a color (based on spawner rotation)
            bullet.GetComponent<Bullet>().Init(transform.right * 2, col);
        }
    }
}
