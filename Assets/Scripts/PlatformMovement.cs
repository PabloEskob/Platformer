using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private Vector3[] _breakPoints;
    [SerializeField] private float _speed;
    
    private void Start()
    {
        Tween tween = transform.DOPath(_breakPoints, _speed, PathType.Linear,PathMode.TopDown2D).SetOptions(true);
        tween.SetEase(Ease.Linear).SetLoops(-1);
    }
}
