using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration_Bonus : MonoBehaviour
{

    [SerializeField] private float _delay;
    [SerializeField] private float _speedMultiplier;

    private PlayerMovement player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            player = collision.gameObject.GetComponent<PlayerMovement>();
          
            Destroy(gameObject);

            player.acceleration = true;

            
        }
    }
}
