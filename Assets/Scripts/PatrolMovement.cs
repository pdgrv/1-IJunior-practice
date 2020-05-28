using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PatrolMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform _targetPoint;

    private Transform _currentPoint;
    private SpriteRenderer _sprite;

    private Vector3 _startPosition;

    private void Start()
    {
        _currentPoint = GetComponent<Transform>();
        _sprite = GetComponent<SpriteRenderer>();

        _startPosition = _currentPoint.position;
    }

    private void Update()
    {
        _currentPoint.position = Vector3.MoveTowards(_currentPoint.position, _targetPoint.position, speed * Time.deltaTime);

        if (_currentPoint.position == _targetPoint.position)
        {
            _targetPoint.position = _startPosition;
            _startPosition = _currentPoint.position;

            _sprite.flipX = !_sprite.flipX;
        }
    }
}
