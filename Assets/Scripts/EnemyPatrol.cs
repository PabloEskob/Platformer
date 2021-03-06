using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    [SerializeField] private float _turn;

    private SpriteRenderer _spriteRenderer;
    private int _nextPoint;
    private Transform[] _pointPatrols;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _pointPatrols = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _pointPatrols[i] = _path.transform.GetChild(i);
        }
    }

    private void Update()
    {
        var target = _pointPatrols[_nextPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _nextPoint++;
            _spriteRenderer.flipX = transform.position.x < _turn;
        }

        if (_nextPoint >= _pointPatrols.Length)
        {
            _nextPoint = 0;
        }
    }
}