using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _respawnDelay = 0f;
    [SerializeField] private float _respawnLoopTime = 2f;

    private float _respawnTime = 0f;

    private void Update()
    {
        _respawnTime += Time.deltaTime;

        if (_respawnTime >= _respawnLoopTime + _respawnDelay)
        {
            GameObject newTemplate = Instantiate(_template, transform.position, Quaternion.identity);
            _respawnTime = _respawnDelay;
        }
    }
}
