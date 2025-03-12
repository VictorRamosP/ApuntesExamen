using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericPool<T> : MonoBehaviour where T : Component
{
    private Queue<T> _pooledObjects;

    public T Prefab;
    public int AmountInPool;

    public static GenericPool<T> Instance;
    public bool ShouldExpand;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        // Fill pool with objects
        _pooledObjects = new Queue<T>();
        for (int i = 0; i < AmountInPool; i++)
        {
            AddNewObject();
        }
    }

    private T AddNewObject()
    {
        T go = Instantiate(Prefab) as T;
        go.gameObject.SetActive(false);
        _pooledObjects.Enqueue(go);
        return go;
    }

    public static T GetObject()
    {
        return Instance._GetObject();
    }

    private T _GetObject()
    {
        if (_pooledObjects.Count > 0) return _pooledObjects.Dequeue();
        if (ShouldExpand) return Instantiate(Prefab);

        return null;
    }

    public static void BackToPool(T poolObject)
    {
        Instance._backToPool(poolObject);
    }

    private void _backToPool(T poolObject)
    {
        poolObject.gameObject.SetActive(false);
        _pooledObjects.Enqueue(poolObject);
    }
}
