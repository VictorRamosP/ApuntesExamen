using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EntityManager : MonoBehaviour
{
    [SerializeField]
    private List<ColorEntity> AllEntities;
    private int _currentIndex;

    public ColorEntity CurrentEntity => AllEntities[_currentIndex];
    public static EntityManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        AllEntities = GetComponentsInChildren<ColorEntity>().ToList();
    }
    public void SetNext()
    {      
        _currentIndex++;
        _currentIndex = _currentIndex % AllEntities.Count;
    }

    public static ColorEntity[] GetRandomEntities(int n)
    {
        return Instance._GetRandomEntities(n);
    }

    private ColorEntity[] _GetRandomEntities(int n)
    {
        List<int> chosen = new List<int>();
        int rdm = 0;

        for (int i = 0; i < n; i++)
        {
            do
            {
                rdm = Random.Range(0, AllEntities.Count);
                
            } while (chosen.Contains(rdm));

            chosen.Add(rdm);
        }

        List<ColorEntity> entities = new List<ColorEntity>();
        for (int i = 0; i < n; i++)
        {
            entities.Add(AllEntities[chosen[i]]);
        }

        return entities.ToArray();
    }
}
