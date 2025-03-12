using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    [SerializeField] 
    private List<Entity> Entities;
    private int _currentIndex;

    // Expression-bodied members, C# syntactic convenience
    public Entity ActiveEntity => Entities[_currentIndex];

    public void SetNextEntity()
    {
        _currentIndex++;
        //_currentIndex = _currentIndex % Entities.Count; // Only two entities in the example
        if (_currentIndex >= Entities.Count) _currentIndex = 0;
    }
}
