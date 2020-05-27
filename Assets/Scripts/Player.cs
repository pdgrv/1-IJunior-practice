using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _gemCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Gem gem))
        {
            _gemCount++;
            Debug.Log("Total gem count: " + _gemCount);
            Destroy(collision.gameObject);
        }
    }    
}
