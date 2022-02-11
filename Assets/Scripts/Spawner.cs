using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{ 
    [SerializeField] private Transform _points;
    [SerializeField] private Coin _coin;
    
    private Transform[] _spawnPoints;
    private int _nextPoint;
    
    private void Start()
    {
        _spawnPoints = new Transform[_points.childCount];
        
        for (int i = 0; i < _points.childCount; i++)
        {
            _spawnPoints[i] = _points.GetChild(i);
        }
        
        foreach (var transform in _spawnPoints)
        {
            if (_nextPoint >= _spawnPoints.Length) continue;
            Transform nextSpawnPoint = _spawnPoints[_nextPoint];
            Instantiate(_coin, nextSpawnPoint.transform.position, Quaternion.identity);
            _nextPoint++;
        }
    }
}
