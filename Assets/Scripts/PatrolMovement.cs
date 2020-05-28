using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PatrolMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform _targetPoint;
        
    private SpriteRenderer _sprite;
    private Vector3 _startPosition;

    private void Start()
    {        
        _sprite = GetComponent<SpriteRenderer>();

        _startPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPoint.position, speed * Time.deltaTime);

        if (transform.position == _targetPoint.position)
        {
            _targetPoint.position = _startPosition;
            _startPosition = transform.position;

            _sprite.flipX = !_sprite.flipX;
        }
    }
}
