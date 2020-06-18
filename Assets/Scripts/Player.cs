using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 100;

    private int _maxHealth;
    private int _gemCount;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;

        _maxHealth = _health;
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
        if (collision.gameObject.TryGetComponent(out Opossum opossum) || collision.gameObject.TryGetComponent(out Eagle eagle))
        {
            Debug.Log("Придется начинать сначала.");
            transform.position = _startPosition;
        }
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
    }

    public void ApplyHeal(int heal)
    {
        if (_health <= _maxHealth-heal)
        {
            _health += heal;
        }
        else
        {
            _health = _maxHealth;
        }
    }
}
