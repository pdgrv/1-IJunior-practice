using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;

    private float _destructionTimer = 0f;

    private void Update()
    {
        _destructionTimer += Time.deltaTime;
        if (_destructionTimer >= 5f)
        {
            Destroy(gameObject);
        }

        transform.position += Vector3.down * _speed * Time.deltaTime;
    }
}
