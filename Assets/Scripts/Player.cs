using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    private int _health;
    private int _gemCount;
    private Vector3 _startPosition;

    public event UnityAction<int> HealthChanged;

    private void Start()
    {
        _startPosition = transform.position;

        _health = _maxHealth;
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
        if (_health >= damage)
            _health -= damage;
        else
            _health = 0;

        HealthChanged?.Invoke(_health);
    }

    public void ApplyHeal(int heal)
    {
        if (_health <= _maxHealth - heal)
            _health += heal;
        else
            _health = _maxHealth;

        HealthChanged?.Invoke(_health);
    }
}
