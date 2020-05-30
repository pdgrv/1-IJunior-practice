using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HouseAlarm : MonoBehaviour
{
    [SerializeField] private float _minVolume = 0.2f;
    [SerializeField] private float _maxVolume = 1f;
    [SerializeField] private float _volumeChangeSpeed = 0.1f;

    private AudioSource _siren;

    private Coroutine _volumeJob;

    private void Start()
    {
        _siren = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _siren.Play();

            if (_volumeJob != null) StopCoroutine(_volumeJob);
            _volumeJob = StartCoroutine(VolumeUp());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            if (_volumeJob != null) StopCoroutine(_volumeJob);
            _volumeJob = StartCoroutine(VolumeDown());
        }
    }

    private IEnumerator VolumeUp()
    {
        var waitForOneSecond = new WaitForSeconds(1f);

        while (_siren.volume < _maxVolume)
        {
            _siren.volume += _volumeChangeSpeed;

            yield return waitForOneSecond;
        }
    }

    private IEnumerator VolumeDown()
    {
        var waitForOneSecond = new WaitForSeconds(1f);

        while (_siren.volume > _minVolume)
        {
            _siren.volume -= _volumeChangeSpeed;

            if (_siren.volume < _minVolume) _siren.volume = _minVolume;
            yield return waitForOneSecond;
        }
        _siren.Stop();
    }
}
