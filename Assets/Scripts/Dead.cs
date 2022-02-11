using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Dead : MonoBehaviour
{ 
    [SerializeField] private float _fallDistance;
    
    private void Update()
    {
        if (transform.position.y<_fallDistance)
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
