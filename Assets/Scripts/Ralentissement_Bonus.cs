using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ralentissement_Bonus : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _slowMultiplier;
    private bool _active;
    private float _startTime;
    private GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        _active = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _active = true;
            _startTime = Time.fixedTime;
            gameObject.SetActive(false);
            // Animation fadeout

            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players)
            {
                if (collision.gameObject.GetComponent<PlayerMovement>().get_player() != player.GetComponent<PlayerMovement>().get_player() && player.GetComponent<BoxCollider2D>().enabled)
                {
                    player.GetComponent<PlayerMovement>().set_speed(player.GetComponent<PlayerMovement>().get_speed() / _slowMultiplier);
                    player.GetComponent<PlayerMovement>().isSlowed = true;
                }
            }
        }
    }

    void Update()
    {
        if (_active && Time.fixedTime - _startTime > _delay)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players)
            {
                if (player.GetComponent<BoxCollider2D>().enabled && player.GetComponent<PlayerMovement>().isSlowed == true)
                {
                    player.GetComponent<PlayerMovement>().set_speed(player.GetComponent<PlayerMovement>().get_speed() * _slowMultiplier);
                }
            }

            Destroy(gameObject);
        }
    }
}
