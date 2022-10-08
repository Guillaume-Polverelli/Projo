using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration_Bonus : MonoBehaviour
{

    [SerializeField] private float _delay;
    [SerializeField] private float _speedMultiplier;

    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject.GetComponent<PlayerMovement>();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            player.set_speed(player.get_speed() * _speedMultiplier);
            player.set_smoothing(player.get_speed() * 0.01f);
            StartCoroutine(Timer());
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(_delay);
        player.set_speed(player.get_speed() / _speedMultiplier);
        player.set_smoothing(player.get_speed() * 0.01f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
