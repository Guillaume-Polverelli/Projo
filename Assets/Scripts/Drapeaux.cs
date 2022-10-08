using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drapeaux : MonoBehaviour
{

    [SerializeField] int _value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(_value);
            Destroy(gameObject);
        }
    }
}
