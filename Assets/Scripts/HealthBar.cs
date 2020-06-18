using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _healthBar;

    private Coroutine _healthBarJob;

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
        _healthBar.value = _healthBar.maxValue;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }

    private void OnValueChanged(int value)
    {
        if (_healthBarJob != null) StopCoroutine(_healthBarJob);
        _healthBarJob = StartCoroutine(HealthBarChange(value));
    }

    private IEnumerator HealthBarChange(int value)
    {
        var waitForFixedUpdate = new WaitForFixedUpdate();

        if (_healthBar.value < value)
        {
            while (_healthBar.value < value)
            {
                _healthBar.value++;

                yield return waitForFixedUpdate;
            }
        }
        else if (_healthBar.value > value)
        {
            while (_healthBar.value > value)
            {
                _healthBar.value--;

                yield return waitForFixedUpdate;
            }
        }
    }
}
