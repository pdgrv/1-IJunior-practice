using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject _eagle;
    [SerializeField] private float _respawnDelay = 0f;

    private float _respawnTime = 0f;

    private void Update()
    {
        _respawnTime += Time.deltaTime;

        if (_respawnTime >= 2f + _respawnDelay)
        {
            GameObject newEagle = Instantiate(_eagle, transform.position, Quaternion.identity);
            _respawnTime = 0f + _respawnDelay;
        }
    }
}
