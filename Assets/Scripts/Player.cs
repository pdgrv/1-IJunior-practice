using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{    
    private Transform _playerTransform;

    private int _gemCount;
    private Vector3 _startPosition;

    private void Start()
    {
        _playerTransform = GetComponent<Transform>();

        _startPosition = _playerTransform.position;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Gem gem))
        {
            _gemCount++;
            Debug.Log("Total gem count: " + _gemCount);
            Destroy(collision.gameObject);
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PatrolMovement enemy))
        {
            Debug.Log("Придется начинать сначала.");
            _playerTransform.position = _startPosition;

        }
    }
}
