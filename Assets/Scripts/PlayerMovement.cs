using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedMovement;
    [SerializeField] private float _speedJump;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Vector3 _movement;
    private bool _isGround;
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Jump = Animator.StringToHash("Jump");

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        _animator.SetFloat(Horizontal, _movement.x);
        _animator.SetFloat(Speed, _movement.sqrMagnitude);
        _spriteRenderer.flipX = _movement.x < 0;
    }

    private void FixedUpdate()
    {
        transform.Translate(_movement * _speedMovement * Time.fixedDeltaTime);

        switch (_isGround)
        {
            case true when Input.GetAxis("Jump") > 0:
                _rigidbody2D.AddForce(Vector2.up * _speedJump, ForceMode2D.Impulse);
                _animator.SetBool(Jump, true);
                break;
            case true:
                _animator.SetBool(Jump, false);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        collision2D.collider.TryGetComponent(out Ground ground);
        transform.parent = collision2D.transform;
        _isGround = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        other.collider.TryGetComponent(out Ground ground);
        transform.parent = null;
        _isGround = false;
    }
}