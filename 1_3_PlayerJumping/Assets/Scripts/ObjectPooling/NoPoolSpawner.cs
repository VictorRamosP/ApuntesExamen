using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoPoolSpawner : MonoBehaviour
{
    public Bullet BulletPrefab;
    public Gradient ColorGradient;

    public bool Spawn;                  // Spawning enable

    public float SpawnTime = 1.0f;      // Spawn time in seconds
    public float RotationSpeed = 5;

    private float timeCounter = 0.0f;   // Time counter for next bullet spawn
    private int counter = 0;            // Bullets counter

    private void Update()
    {
        // OLD: Not using a pool, just instantiate one new object every certain time
        // and removing it from memory automaticallly once out of visibility range (check Bullet.cs)

        // Rotate spawner gameobject
        transform.Rotate(new Vector3(0, 0, RotationSpeed * Time.deltaTime));

        if (Spawn)
        {
            timeCounter += Time.deltaTime;

            if (timeCounter > SpawnTime)
            {
                CreateOneBullet();
                timeCounter = 0.0f;
                counter++;
            }
        }
    }

    void CreateOneBullet()
    {
        // Instantiate one new bullet object
        var bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity) as Bullet;

        // Assign and object name for reference
        bullet.name = "Bullet [" + counter.ToString("000") + "]";

        // Get a color based on its spawner rotation
        Color color = ColorGradient.Evaluate(transform.eulerAngles.z / 360f);

        // Init bullet with a velocity and a color (based on spawner rotation)
        bullet.Init(transform.right*2, color);
    }
}
