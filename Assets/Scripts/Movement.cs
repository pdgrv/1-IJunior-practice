using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpSpeed = 5f;
    [SerializeField] private LayerMask _groundMask = 8;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _sprite;
    private Animator _animator;
    private CapsuleCollider2D _collider;

    private float _horizontalInput;
    private bool _grounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");

        if (_grounded)
        {
            _animator.SetBool("Jump", false);

            if (Input.GetKey(KeyCode.Space))
            {
                _rigidbody.velocity = Vector2.up * _jumpSpeed;
            }
        }
        else _animator.SetBool("Jump", true);
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_horizontalInput * _speed, _rigidbody.velocity.y);

        if (_horizontalInput < 0)
            _sprite.flipX = true;
        else if (_horizontalInput > 0)
            _sprite.flipX = false;

        _animator.SetFloat("Speed", _rigidbody.velocity.magnitude);

        _grounded = Physics2D.OverlapCapsule(_collider.bounds.center, _collider.size * 1.1f, direction: CapsuleDirection2D.Vertical, 0, _groundMask) != null;
        
    }
}
