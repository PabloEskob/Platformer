using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour
{
    [SerializeField] private float _movementHeight;
    [SerializeField] private float _speed;

    private Vector3 _startingPosition;
    private Vector3 _direction;
    private static int _count;

    private void Start()
    {
        _direction = Vector3.up;
        _startingPosition = transform.position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);

        if (transform.position.y >= _startingPosition.y + _movementHeight)
        {
            _direction = Vector3.down;
        }

        if (transform.position.y <= _startingPosition.y)
        {
            _direction = Vector3.up;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out PlayerMovement player))
        {
            _count ++;
            Debug.Log($"Игрок подобрал: {_count}монет");
            Destroy(gameObject);
        }
    }
}