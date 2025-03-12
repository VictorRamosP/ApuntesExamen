using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // OPTION 1: Use a queue
    private Queue<GameObject> _pool;    // Queue containing all objects (pool)

    // OPTION 2: Use an array
    //private GameObject[] _pool;         // Array containing all objects (pool)

    public static PoolManager Instance; // Make sure we only have one PoolManaged (Pattern: Singleton)

    public GameObject Prefab;           // Game object to for the pool
    public int Capacity;                // Pool capacity (max objects)
    private int counter = 0;            // Objects currently active in the pool

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        // Fill the pool with all required objects
        
        // OPTION 1: Using a queue
        _pool = new Queue<GameObject>();

        // OPTION 2: Using an array
        //_pool = new GameObject[Capacity];

        // Initialize pool
        for (int i = 0; i < Capacity; i++)
        {
            AddNewObject();
            counter++;
        }
    }

    private GameObject AddNewObject()
    {
        // Create a new instance of one object
        GameObject obj = Instantiate(Prefab);
        obj.name = "Bullet [" + counter.ToString("000") + "]";
        obj.SetActive(false);

        // OPTION 1: Add created object to queue
        _pool.Enqueue(obj);
        
        // OPTION 2: Add created object to array
        //_pool[counter] = obj;

        return obj;
    }

    public static GameObject GetObject()
    {
        GameObject ret = null;

        // OPTION 1: Dequeue one object from queue
        if (Instance._pool.Count > 0) ret = Instance._pool.Dequeue();

        // OPTION 2: Get first object available on array (not active)
        /*
        for (int i = 0; i < Instance.Capacity; i++)
        {
            if (Instance._pool[i].active == false)
            {
                Instance._pool[i].active = true;
                ret = Instance._pool[i];
                break;
            }
        }
        */

        return ret;
    }

    public static void BackToPool(GameObject gameObject)
    {
        // Deactivate object
        gameObject.SetActive(false);

        // OPTION 1: Add object back to queue
        Instance._pool.Enqueue(gameObject);
    }
}
