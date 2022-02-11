using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    [SerializeField] private float _position;
    private void Update()
    {
        if (transform.position.y<_position)
        {
            FinishGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.TryGetComponent(out EnemyPatrol enemy))
        {
            FinishGame();
        }
    }

    private void FinishGame()
    {
        Debug.Log("The End!");
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
